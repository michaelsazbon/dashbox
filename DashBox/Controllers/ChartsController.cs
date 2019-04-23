using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using System.Net;
//using System.Linq.Dynamic;
using System.Text;
using AttributeRouting.Web.Http;

using Microsoft.Xrm.Sdk;    // acces au WebService
using Microsoft.Xrm.Sdk.Query;  //acces aux QueryExpressions
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Crm.Sdk.Messages;
using System.Collections;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using System.ServiceModel.Description;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Metadata;

namespace DashBox.Controllers
{
    public class Entite
    {
        public string text { get; set; }
        public string id { get; set; }
    }

    public class DataResult
    {
        public string[] labels { get; set; }
        public DResult[] results { get; set; }
    }

    public class DataResultMulti
    {
        public string[] labels { get; set; }
        public DatasetItem[] results { get; set; }
    }

    public class DResult
    {
        public int[] data { get; set; }
        public string[] backgroundColor { get; set; }
    }

    public class DataGroup
    {
        public string group1 { get; set; }
        public string group2 { get; set; }
        public int value { get; set; }
    }


    public class DatasetItem
    {
        public string label { get; set; }
        public string backgroundColor { get; set; }
        public int[] data { get; set; }
    }


    // Inheriting from the APIController class will designate this as a WebAPI endpoint
    public class ChartsController : ApiController
    {

 
        private Data.DashBoxDataContext _context = new Data.DashBoxDataContext();

        // the current http request being made
        HttpRequest _request = HttpContext.Current.Request;

        private string[] ColorsPalette = new string[] 
        {
          "#455C73",
          "#9B59B6",
          "#BDC3C7",
          "#26B99A",
          "#3498DB"
        };

        private DataResult GetNbRecordsOfCategorie(IOrganizationService _service, string entityName, string attributeIdName, string SerieColumnName, string SerieAgregationType, string attributeName, string attributeType)
        {

            string aggregate = (SerieAgregationType != null) ? SerieAgregationType : "count";

            string fetchXml = @"<fetch mapping='logical' aggregate='true'>
                                      <entity name='" + entityName + @"'>
                                        <attribute groupby='true' alias='groupby_column' name='" + attributeName + @"' />
                                        <attribute alias='aggregate_column' name='" + SerieColumnName + @"' aggregate='" + aggregate + @"' />
                                      </entity>
                                    </fetch>";

            // Build fetch request and obtain results.
            RetrieveMultipleRequest efr = new RetrieveMultipleRequest()
            {
                Query = new FetchExpression(fetchXml)
            };

            EntityCollection entityResults = ((RetrieveMultipleResponse)_service.Execute(efr)).EntityCollection;

            int max = entityResults.Entities.Count;

            int[] datas = new int[max];
            string[] labels = new string[max];
            string[] backgroundColors = new string[max];
            int i = 0;
            Random random = new Random();

            foreach (var c in entityResults.Entities)
            {

                Int32 count = 0;

                if (((AliasedValue)c["aggregate_column"]).Value != null)
                {
                    count = (Int32)((AliasedValue)c["aggregate_column"]).Value;
                }


                string grouplabel = "vide";
                if (c.FormattedValues.Contains("groupby_column") && c.FormattedValues["groupby_column"] != null)
                {
                    grouplabel = c.FormattedValues["groupby_column"].ToString();
                }
                else if (c.Attributes.Contains("groupby_column") && c["groupby_column"] != null && ((AliasedValue)c["groupby_column"]).Value != null)
                {
                    if (((AliasedValue)c["groupby_column"]).Value is EntityReference)
                    {
                        grouplabel = ((EntityReference)((AliasedValue)c["groupby_column"]).Value).Name;
                    }
                    else if (((AliasedValue)c["groupby_column"]).Value is Int32)
                    {
                        grouplabel = ((Int32)((AliasedValue)c["groupby_column"]).Value).ToString();
                    }
                    else if (((AliasedValue)c["groupby_column"]).Value is string)
                    {
                        grouplabel = (string)((AliasedValue)c["groupby_column"]).Value;
                    }
                }
                datas[i] = count;
                labels[i] = grouplabel;
                if (i < ColorsPalette.Length)
                {
                    backgroundColors[i] = ColorsPalette[i];
                }
                else
                {
                    backgroundColors[i] = string.Format("#{0:X6}", random.Next(0x1000000));
                }
                i++;
            }

            return new DataResult
            {
                labels = labels,
                results = new DResult[1] { 
                        new DResult {
                            data = datas,
                            backgroundColor = backgroundColors
                        }
                    }
            };

        }

        private DataResultMulti GetNbRecordsOfMultipleCategorie(IOrganizationService _service, string entityName, string attributeIdName, string SerieColumnName,string SerieAgregationType, string attributeName, string attribute2Name, string attributeType)
        {

            string aggregate = (SerieAgregationType != null) ? SerieAgregationType : "count";

            string fetchXml = @"<fetch mapping='logical' aggregate='true'>
                                      <entity name='" + entityName + @"'>
                                        <attribute groupby='true' alias='groupby_column' name='" + attributeName + @"' />
                                        <attribute groupby='true' alias='groupby2_column' name='" + attribute2Name + @"' />
                                        <attribute alias='aggregate_column' name='" + SerieColumnName + @"' aggregate='"+aggregate+@"' />
                                      </entity>
                                    </fetch>";

            // Build fetch request and obtain results.
            RetrieveMultipleRequest efr = new RetrieveMultipleRequest()
            {
                Query = new FetchExpression(fetchXml)
            };

            EntityCollection entityResults = ((RetrieveMultipleResponse)_service.Execute(efr)).EntityCollection;

            List<int> datas = new List<int>();
            List<string> labels = new List<string>();
            List<string> backgroundColors = new List<string>();
            int i = 0;
            Random random = new Random();

            string LastRow = "";
            string NewRow = "";
            List<string> Labels = new List<string>();
            List<DResult> LignesResult = new List<DResult>();
            List<DataGroup> ListDataGroup = new List<DataGroup>();

            foreach (var c in entityResults.Entities)
            {

                Int32 count = 0;

                if (((AliasedValue)c["aggregate_column"]).Value != null)
                {
                    count = (Int32)((AliasedValue)c["aggregate_column"]).Value;
                }

                string grouplabel = "vide";
                if (c.FormattedValues.Contains("groupby_column") && c.FormattedValues["groupby_column"] != null)
                {
                    grouplabel = c.FormattedValues["groupby_column"].ToString();
                }
                else if (c.Attributes.Contains("groupby_column") && c["groupby_column"] != null && ((AliasedValue)c["groupby_column"]).Value != null)
                {
                    if (((AliasedValue)c["groupby_column"]).Value is EntityReference)
                    {
                        grouplabel = ((EntityReference)((AliasedValue)c["groupby_column"]).Value).Name;
                    }
                    else if (((AliasedValue)c["groupby_column"]).Value is Int32)
                    {
                        grouplabel = ((Int32)((AliasedValue)c["groupby_column"]).Value).ToString();
                    }
                    else if (((AliasedValue)c["groupby_column"]).Value is string)
                    {
                        grouplabel = (string)((AliasedValue)c["groupby_column"]).Value;
                    }
                }


                string grouplabel2 = "vide";
                if (c.FormattedValues.Contains("groupby2_column") && c.FormattedValues["groupby2_column"] != null)
                {
                    grouplabel2 = c.FormattedValues["groupby2_column"].ToString();
                }
                else if (c.Attributes.Contains("groupby2_column") && c["groupby2_column"] != null && ((AliasedValue)c["groupby2_column"]).Value != null)
                {
                    if (((AliasedValue)c["groupby2_column"]).Value is EntityReference)
                    {
                        grouplabel2 = ((EntityReference)((AliasedValue)c["groupby2_column"]).Value).Name;
                    }
                    else if (((AliasedValue)c["groupby2_column"]).Value is Int32)
                    {
                        grouplabel2 = ((Int32)((AliasedValue)c["groupby2_column"]).Value).ToString();
                    }
                    else if (((AliasedValue)c["groupby2_column"]).Value is string)
                    {
                        grouplabel2 = (string)((AliasedValue)c["groupby2_column"]).Value;
                    }
                }



                ListDataGroup.Add(new DataGroup { group1 = grouplabel, group2 = grouplabel2, value = count });

            }


            labels = ListDataGroup.GroupBy(item => item.group1)
                                  .Select(grp => grp.First())
                                  .OrderBy(item => item.group1)
                                  .Select(item => item.group1).ToList();

            List<DatasetItem> ListDataset = new List<DatasetItem>();
            int n = 0;
            foreach (string group2 in ListDataGroup.GroupBy(item => item.group2)
                                  .Select(grp => grp.First())
                                  .OrderBy(item => item.group2)
                                  .Select(item => item.group2))
            {

                List<int> data = new List<int>();
                foreach (string group1 in labels)
                {
                    var d = ListDataGroup.FirstOrDefault(item => item.group1 == group1 && item.group2 == group2);
                    data.Add(d != null ? d.value : 0);
                }
                ListDataset.Add(
                    new DatasetItem
                    {
                        label = group2,
                        backgroundColor = ((n < ColorsPalette.Length) ? ColorsPalette[n++] : string.Format("#{0:X6}", random.Next(0x1000000))),
                        data = data.ToArray()
                    }
                    );
            }

            return new DataResultMulti
            {
                labels = labels.ToArray(),
                results = ListDataset.ToArray()
            };

        }

        private int GetNbRecordsOfCategoriePicklist(IOrganizationService _service, string entityName, string attributeIdName, string attributeName, int val)
        {
            string fetchXml = "";
            if (val == -1)
            {
                fetchXml = @"<fetch mapping='logical' count='1' returntotalrecordcount='true'>
								    <entity name='" + entityName + @"'>
									    <attribute name='" + attributeIdName + @"'/>
                                            <filter type='and'>
                                                <condition attribute='" + attributeName + @"' operator='null' />
                                            </filter>
								    </entity>
							    </fetch>";
            }
            else
            {
                fetchXml = @"<fetch mapping='logical' count='1' returntotalrecordcount='true'>
								    <entity name='" + entityName + @"'>
									    <attribute name='" + attributeIdName + @"'/>
                                            <filter type='and'>
                                                <condition attribute='" + attributeName + @"' operator='eq' value='" + val + @"' />
                                            </filter>
								    </entity>
							    </fetch>";
            }


            // Build fetch request and obtain results.
            RetrieveMultipleRequest efr = new RetrieveMultipleRequest()
            {
                Query = new FetchExpression(fetchXml)
            };

            EntityCollection entityResults = ((RetrieveMultipleResponse)_service.Execute(efr)).EntityCollection;
            return entityResults.TotalRecordCount;
        }

        [POST("api/charts/getchartdata")]
        [HttpPost]
        public HttpResponseMessage getchartdata(Models.Chart chart)
        {

            var response = new HttpResponseMessage();

            try
            {
                if (chart != null)
                {

                    if (string.IsNullOrEmpty(chart.ConnectionId))
                    {
                        response.StatusCode = HttpStatusCode.InternalServerError;
                        response.Content = new StringContent("Connection vide");
                        return response;
                    }
                    if (string.IsNullOrEmpty(chart.CategorieColumnName))
                    {
                        response.StatusCode = HttpStatusCode.InternalServerError;
                        response.Content = new StringContent("Catégorie vide");
                        return response;
                    }
                    if (string.IsNullOrEmpty(chart.ChartType))
                    {
                        response.StatusCode = HttpStatusCode.InternalServerError;
                        response.Content = new StringContent("Type de graphique vide");
                        return response;
                    }
                    if (string.IsNullOrEmpty(chart.Entity))
                    {
                        response.StatusCode = HttpStatusCode.InternalServerError;
                        response.Content = new StringContent("Entité vide");
                        return response;
                    }
                    if (string.IsNullOrEmpty(chart.Nom))
                    {
                        response.StatusCode = HttpStatusCode.InternalServerError;
                        response.Content = new StringContent("Nom vide");
                        return response;
                    }
                    if (string.IsNullOrEmpty(chart.SerieColumnName))
                    {
                        response.StatusCode = HttpStatusCode.InternalServerError;
                        response.Content = new StringContent("Série vide");
                        return response;
                    }

 

                    var connection = _context.Connections.Where(i => i.Id == int.Parse(chart.ConnectionId)).FirstOrDefault();

                    if (connection != null)
                    {

                        string CrmPassword = connection.Password;
                        string CrmURL = connection.Url;
                        string CrmUsername = connection.Username;

                        IOrganizationService _service = DashBox.Helpers.DynamicsCRM.Connect(CrmPassword, CrmURL, CrmUsername);


                        var chartype = _context.ChartTypes.Where(i => i.Id == int.Parse(chart.ChartType)).FirstOrDefault();

                        if (chartype != null)
                        {




                            RetrieveEntityRequest retrieveEntityRequest = new RetrieveEntityRequest
                            {
                                EntityFilters = EntityFilters.Attributes,
                                LogicalName = chart.Entity
                            };
                            RetrieveEntityResponse retrieveEntityResponse = (RetrieveEntityResponse)_service.Execute(retrieveEntityRequest);
                            EntityMetadata entityMetadata = retrieveEntityResponse.EntityMetadata;



                            AttributeMetadata attribute = entityMetadata.Attributes.FirstOrDefault(item => item.LogicalName == chart.CategorieColumnName);

                            if (attribute != null)
                            {

                                if (chartype.Nom == "Secteur")
                                {

                                    DataResult res = GetNbRecordsOfCategorie(_service, chart.Entity, entityMetadata.PrimaryIdAttribute, chart.SerieColumnName, chart.SerieAgregationType, chart.CategorieColumnName, attribute.AttributeType.Value.ToString());

                                    if (res != null)
                                    {

                                        var Datas = new
                                        {
                                            labels = res.labels,
                                            datasets = res.results
                                        };

                                        return Request.CreateResponse(HttpStatusCode.OK, Datas, JsonMediaTypeFormatter.DefaultMediaType);

                                    }

                                }

                                else if (chartype.Nom == "Colonne" || chartype.Nom == "Colonnes empilées")
                                {
                                    if (chart.Categorie2ColumnName != null)
                                    {
                                        DataResultMulti res = GetNbRecordsOfMultipleCategorie(_service, chart.Entity, entityMetadata.PrimaryIdAttribute, chart.SerieColumnName,chart.SerieAgregationType, chart.CategorieColumnName, chart.Categorie2ColumnName, attribute.AttributeType.Value.ToString());

                                        if (res != null)
                                        {

                                            var Datas = new
                                            {
                                                labels = res.labels,
                                                datasets = res.results
                                            };

                                            return Request.CreateResponse(HttpStatusCode.OK, Datas, JsonMediaTypeFormatter.DefaultMediaType);

                                        }
                                    }
                                    else
                                    {

                                        DataResult res = GetNbRecordsOfCategorie(_service, chart.Entity, entityMetadata.PrimaryIdAttribute, chart.SerieColumnName, chart.SerieAgregationType, chart.CategorieColumnName, attribute.AttributeType.Value.ToString());

                                        if (res != null)
                                        {

                                            var Datas = new
                                            {
                                                labels = res.labels,
                                                datasets = res.results
                                            };

                                            return Request.CreateResponse(HttpStatusCode.OK, Datas, JsonMediaTypeFormatter.DefaultMediaType);

                                        }
                                    }
                                }

                               

                            }

                        }
                        else
                        {

                            response.StatusCode = HttpStatusCode.InternalServerError;
                            response.Content = new StringContent("Type de graphique avec Id = '" + chart.ChartType + "' non trouvé");
                        }

                    }
                    else
                    {

                        response.StatusCode = HttpStatusCode.InternalServerError;
                        response.Content = new StringContent("Connection avec Id = '" + chart.ConnectionId + "' non trouvée");
                    }




                }
                else
                {

                    response.StatusCode = HttpStatusCode.InternalServerError;
                    response.Content = new StringContent("Grpahique NULL");
                }
            }
            catch (Exception ex)
            {
                // something went wrong - possibly a database error. return a
                // 500 server error and send the details of the exception.
                response.StatusCode = HttpStatusCode.InternalServerError;
                string message = ((ex.InnerException != null) ? ex.InnerException.Message : ex.Message);
                response.Content = new StringContent(string.Format("Erreur lors de l'affichage de l'apercu du graphique: {0}", message));
            }

            // return the HTTP Response.
            return response;
        }

        // WebAPI will respond to an HTTP GET with this method
        [GET("api/charts/getchartdonutsdata")]
        [HttpGet]
        public HttpResponseMessage getchartdonutsdata()
        {
            Random random = new Random();

            string json = @"{
                labels: [
                  'Dark Grey',
                  'Purple Color',
                  'Gray Color',
                  'Green Color',
                  'Blue Color'
                ],
                datasets: [{
                    data: [120, 50, 140, 180, 100],
                    backgroundColor: [
                      '" + (string.Format("#{0:X6}", random.Next(0x1000000))) + @"',
                      '" + (string.Format("#{0:X6}", random.Next(0x1000000))) + @"',
                      '" + (string.Format("#{0:X6}", random.Next(0x1000000))) + @"',
                      '" + (string.Format("#{0:X6}", random.Next(0x1000000))) + @"',
                      '" + (string.Format("#{0:X6}", random.Next(0x1000000))) + @"',
                    ]

                }]
            }";

            JObject Data = JObject.Parse(json);

            return Request.CreateResponse(HttpStatusCode.OK, Data, JsonMediaTypeFormatter.DefaultMediaType);

        }

        // WebAPI will respond to an HTTP GET with this method
        [GET("api/charts/getcharttypes")]
        [HttpGet]
        public HttpResponseMessage getcharttypes()
        {

            var Data = new
            {
                results =
                        from p in _context.ChartTypes
                        orderby p.Nom
                        select new
                        {
                            id = p.Id.ToString(),
                            text = p.Nom
                        }
            };

            return Request.CreateResponse(HttpStatusCode.OK, Data, JsonMediaTypeFormatter.DefaultMediaType);

        }

        [GET("api/charts/getcrmentities")]
        [HttpGet]
        public HttpResponseMessage getcrmentities(string ConnectionId, string search = "")
        {
            if (ConnectionId != null)
            {
                var connection =
                            (from p in _context.Connections
                             where p.Id == int.Parse(ConnectionId)
                             select p).FirstOrDefault();


                if (connection != null)
                {
                    string CrmPassword = connection.Password;
                    string CrmURL = connection.Url;
                    string CrmUsername = connection.Username;

                    IOrganizationService _service = DashBox.Helpers.DynamicsCRM.Connect(CrmPassword, CrmURL, CrmUsername);


                    RetrieveAllEntitiesRequest request = new RetrieveAllEntitiesRequest()
                    {
                        EntityFilters = EntityFilters.Entity,
                        RetrieveAsIfPublished = true
                    };

                    // Retrieve the MetaData.
                    RetrieveAllEntitiesResponse response = (RetrieveAllEntitiesResponse)_service.Execute(request);

                    var results = new List<Entite>();

                    foreach (EntityMetadata currentEntity in response.EntityMetadata)
                    {
                        if (currentEntity.IsCustomizable.Value && currentEntity.DisplayName.UserLocalizedLabel != null)
                        {
                            if (string.IsNullOrEmpty(search) || currentEntity.DisplayName.UserLocalizedLabel.Label.ToUpper().StartsWith(search.ToUpper()))
                            {
                                results.Add(new Entite
                                {
                                    id = currentEntity.LogicalName,
                                    text = currentEntity.DisplayName.UserLocalizedLabel.Label
                                });
                            }

                        }
                    }

                    var Data = new
                    {
                        results = results.OrderBy(item => item.text)
                    };

                    return Request.CreateResponse(HttpStatusCode.OK, Data, JsonMediaTypeFormatter.DefaultMediaType);
                }
                else
                {
                    var response = new HttpResponseMessage();
                    response.StatusCode = HttpStatusCode.InternalServerError;
                    response.Content = new StringContent("ConnectionId NULL");
                    return response;
                }
            }
            else
            {
                var response = new HttpResponseMessage();
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Content = new StringContent("ConnectionId NULL");
                return response;
            }
        }

        // WebAPI will respond to an HTTP GET with this method
        [GET("api/charts/grid")]
        [HttpGet]
        public HttpResponseMessage grid()
        {

            //int i = 1;
            var Connections = _context.Charts.ToList();



            JObject o = JObject.FromObject(new
            {
                draw = 1,
                recordsTotal = Connections.Count(),
                recordsFiltered = Connections.Count(),
                data = from p in _context.Charts
                       join c in _context.ChartTypes on p.TypeId equals c.Id
                       join con in _context.Connections on p.ConnectionId equals con.Id
                       orderby p.Id descending
                       select new
                       {
                           Id = p.Id,
                           Nom = p.Nom,
                           Type = c.Nom,
                           Connection = con.Nom
                           //Source = p.Sou
                       }

            });


            return Request.CreateResponse(HttpStatusCode.OK, o, JsonMediaTypeFormatter.DefaultMediaType);

        }

        [GET("api/charts/getchart")]
        [HttpGet]
        public HttpResponseMessage getchart(string ChartId)
        {
            if (ChartId != null)
            {

                var Data = new
                {
                    result =
                            (from p in _context.Charts
                            where p.Id == int.Parse(ChartId)
                            select new
                            {
                                id = p.Id.ToString(),
                                Nom = p.Nom,
                                ConnectionId = p.ConnectionId,
                                ChartType = p.TypeId,
                                Entity = p.EntiteName,
                                SerieColumnName = p.SerieColumnName,
                                CategorieColumnName = p.CategorieColumnName,
                                Categorie2ColumnName = p.Categorie2ColumnName,
                                SerieAgregationType = p.SerieAgregationType
                            }).First()
                };

                return Request.CreateResponse(HttpStatusCode.OK, Data, JsonMediaTypeFormatter.DefaultMediaType);
            }
            else
            {
                var response = new HttpResponseMessage();
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Content = new StringContent("ChartId NULL");
                return response;
            }
        }

        [GET("api/charts/isattributenumeric")]
        [HttpGet]
        public HttpResponseMessage isattributenumeric(string ConnectionId, string EntityName, string AttributeName)
        {
            if (AttributeName != null)
            {

                if (EntityName != null && ConnectionId != null)
                {
                    var connection =
                                (from p in _context.Connections
                                 where p.Id == int.Parse(ConnectionId)
                                 select p).FirstOrDefault();


                    if (connection != null)
                    {
                        string CrmPassword = connection.Password;
                        string CrmURL = connection.Url;
                        string CrmUsername = connection.Username;

                        IOrganizationService _service = DashBox.Helpers.DynamicsCRM.Connect(CrmPassword, CrmURL, CrmUsername);


                        RetrieveEntityRequest retrieveEntityRequest = new RetrieveEntityRequest
                                {
                                    EntityFilters = EntityFilters.Attributes,
                                    LogicalName = EntityName
                                };
                        RetrieveEntityResponse retrieveEntityResponse = (RetrieveEntityResponse)_service.Execute(retrieveEntityRequest);
                        EntityMetadata entityMetadata = retrieveEntityResponse.EntityMetadata;



                        AttributeMetadata attribute = entityMetadata.Attributes.FirstOrDefault(item => item.LogicalName == AttributeName);

                        bool result = false;

                        if (attribute != null)
                        {
                            switch (attribute.AttributeType.Value.ToString())
                            {
                                case "Integer":
                                case "Money":
                                case "Decimal":
                                    result = true;
                                    break;
                            }

                        }
                        var Data = new
                        {
                            result = result
                        };

                        return Request.CreateResponse(HttpStatusCode.OK, Data, JsonMediaTypeFormatter.DefaultMediaType);
                    }
                    else
                    {
                        var response = new HttpResponseMessage();
                        response.StatusCode = HttpStatusCode.InternalServerError;
                        response.Content = new StringContent("EntityName NULL");
                        return response;
                    }
                }
                else
                {
                    var response = new HttpResponseMessage();
                    response.StatusCode = HttpStatusCode.InternalServerError;
                    response.Content = new StringContent("EntityName NULL");
                    return response;
                }
            }
            else
            {
                var response = new HttpResponseMessage();
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Content = new StringContent("Attribut NULL");
                return response;
            }
        }

        [GET("api/charts/getcrmattributes")]
        [HttpGet]
        public HttpResponseMessage getcrmattributes(string EntityName, string ConnectionId, string search = "")
        {
            if (EntityName != null && ConnectionId != null)
            {
                var connection =
                            (from p in _context.Connections
                             where p.Id == int.Parse(ConnectionId)
                             select p).FirstOrDefault();


                if (connection != null)
                {
                    string CrmPassword = connection.Password;
                    string CrmURL = connection.Url;
                    string CrmUsername = connection.Username;

                    IOrganizationService _service = DashBox.Helpers.DynamicsCRM.Connect(CrmPassword, CrmURL, CrmUsername);


                    RetrieveEntityRequest retrieveEntityRequest = new RetrieveEntityRequest
                    {
                        EntityFilters = EntityFilters.Attributes,
                        LogicalName = EntityName
                    };
                    RetrieveEntityResponse retrieveEntityResponse = (RetrieveEntityResponse)_service.Execute(retrieveEntityRequest);
                    EntityMetadata entityMetadata = retrieveEntityResponse.EntityMetadata;


                    var results = entityMetadata.Attributes.Where(item =>
                        item.IsValidForAdvancedFind.Value
                        &&
                        (string.IsNullOrEmpty(search) || item.DisplayName.UserLocalizedLabel.Label.ToString().ToUpper().StartsWith(search.ToUpper()))
                        ).
                        Select(item => new { id = item.LogicalName, text = item.DisplayName.UserLocalizedLabel.Label.ToString() });

                    var Data = new
                    {
                        results = results.OrderBy(item => item.text)
                    };

                    return Request.CreateResponse(HttpStatusCode.OK, Data, JsonMediaTypeFormatter.DefaultMediaType);
                }
                else
                {
                    var response = new HttpResponseMessage();
                    response.StatusCode = HttpStatusCode.InternalServerError;
                    response.Content = new StringContent("EntityName NULL");
                    return response;
                }
            }
            else
            {
                var response = new HttpResponseMessage();
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Content = new StringContent("EntityName NULL");
                return response;
            }
        }



        [POST("api/charts/createchart")]
        public HttpResponseMessage createchart(Models.Chart chart)
        {

            var response = new HttpResponseMessage();

            try
            {
                if (chart != null)
                {

                    if (string.IsNullOrEmpty(chart.ConnectionId))
                    {
                        response.StatusCode = HttpStatusCode.InternalServerError;
                        response.Content = new StringContent("Connection vide");
                        return response;
                    }
                    if (string.IsNullOrEmpty(chart.CategorieColumnName))
                    {
                        response.StatusCode = HttpStatusCode.InternalServerError;
                        response.Content = new StringContent("Catégorie vide");
                        return response;
                    }
                    if (string.IsNullOrEmpty(chart.ChartType))
                    {
                        response.StatusCode = HttpStatusCode.InternalServerError;
                        response.Content = new StringContent("Type de graphique vide");
                        return response;
                    }
                    if (string.IsNullOrEmpty(chart.Entity))
                    {
                        response.StatusCode = HttpStatusCode.InternalServerError;
                        response.Content = new StringContent("Entité vide");
                        return response;
                    }
                    if (string.IsNullOrEmpty(chart.Nom))
                    {
                        response.StatusCode = HttpStatusCode.InternalServerError;
                        response.Content = new StringContent("Nom vide");
                        return response;
                    }
                    if (string.IsNullOrEmpty(chart.SerieColumnName))
                    {
                        response.StatusCode = HttpStatusCode.InternalServerError;
                        response.Content = new StringContent("Série vide");
                        return response;
                    }

                    //Models.Connection conn = new Models.Connection();
                    //con

                    DashBox.Data.Chart con = new Data.Chart
                    {
                        Nom = chart.Nom,
                        ConnectionId = int.Parse(chart.ConnectionId),
                        TypeId = int.Parse(chart.ChartType),
                        EntiteName = chart.Entity,
                        SerieColumnName = chart.SerieColumnName,
                        CategorieColumnName = chart.CategorieColumnName
                    };


                    _context.Charts.InsertOnSubmit(con);

                    // submit the changes to the database

                    _context.SubmitChanges();

                    // set the server response to OK
                    response.StatusCode = HttpStatusCode.NoContent;
                }
                else
                {
                    response.StatusCode = HttpStatusCode.InternalServerError;
                    response.Content = new StringContent("Grpahique NULL");
                }
            }
            catch (Exception ex)
            {
                // something went wrong - possibly a database error. return a
                // 500 server error and send the details of the exception.
                response.StatusCode = HttpStatusCode.InternalServerError;
                string message = ((ex.InnerException != null) ? ex.InnerException.Message : ex.Message);
                response.Content = new StringContent(string.Format("Erreur lors de l'enregistrement du graphique: {0}", message));
            }

            // return the HTTP Response.
            return response;
        }
    }
}