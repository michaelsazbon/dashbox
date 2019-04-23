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


namespace DashBox.Controllers
{

    // Inheriting from the APIController class will designate this as a WebAPI endpoint
    public class ConnectionsController : ApiController
    {


        private Data.DashBoxDataContext _context = new Data.DashBoxDataContext();

        // the current http request being made
        HttpRequest _request = HttpContext.Current.Request;


        // WebAPI will respond to an HTTP GET with this method
        [GET("api/connections/grid")]
        [HttpGet]
        public HttpResponseMessage grid()
        {

            //int i = 1;
            var Connections = _context.Connections.ToList();

            JObject o = JObject.FromObject(new
                     {
                         draw = 1,
                         recordsTotal = Connections.Count(),
                         recordsFiltered = Connections.Count(),
                         data = from p in _context.Connections
                                orderby p.Id descending
                                select new
                                {
                                    Id = p.Id,
                                    Nom = p.Nom,
                                    Source = p.Source,
                                    Compte = p.Username
                                    //Source = p.Sou
                                }

                     });


            return Request.CreateResponse(HttpStatusCode.OK, o, JsonMediaTypeFormatter.DefaultMediaType);

        }

        [GET("api/connections/select")]
        [HttpGet]
        public HttpResponseMessage select()
        {

            var Data = new
            {
                results =
                        from p in _context.Connections
                        orderby p.Nom
                        select new
                        {
                            id = p.Id.ToString(),
                            text = p.Nom
                        }
            };



            return Request.CreateResponse(HttpStatusCode.OK, Data, JsonMediaTypeFormatter.DefaultMediaType);

        }

        [POST("api/connections/testconnection")]
        public HttpResponseMessage testconnection(Models.Connection connection)
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var response = new HttpResponseMessage();

            try
            {
                if (connection != null)
                {

                    if (string.IsNullOrEmpty(connection.Password))
                    {
                        response.StatusCode = HttpStatusCode.InternalServerError;
                        response.Content = new StringContent("Mot de passe vide");
                        return response;
                    }
                    if (string.IsNullOrEmpty(connection.Url))
                    {
                        response.StatusCode = HttpStatusCode.InternalServerError;
                        response.Content = new StringContent("URL vide");
                        return response;
                    }
                    if (string.IsNullOrEmpty(connection.Username))
                    {
                        response.StatusCode = HttpStatusCode.InternalServerError;
                        response.Content = new StringContent("Nom d'utilisateur vide");
                        return response;
                    }


                    try
                    {

                        string CrmPassword = connection.Password;
                        string CrmURL = connection.Url;
                        string CrmUsername = connection.Username;

                        IOrganizationService CrmService = DashBox.Helpers.DynamicsCRM.Connect(CrmPassword, CrmURL, CrmUsername);


                        Guid UserId = ((WhoAmIResponse)CrmService.Execute(new WhoAmIRequest())).UserId;

                        response.StatusCode = HttpStatusCode.NoContent;
                    }
                    catch (Exception ex)
                    {
                        response.StatusCode = HttpStatusCode.InternalServerError;
                        response.Content = new StringContent("Erreur lors de la connexion au CRM : " + ex.Message);
                    }

                }
                else
                {

                    response.StatusCode = HttpStatusCode.InternalServerError;
                    response.Content = new StringContent("Connection NULL");
                }
            }
            catch (Exception ex)
            {
                // something went wrong - possibly a database error. return a
                // 500 server error and send the details of the exception.
                response.StatusCode = HttpStatusCode.InternalServerError;
                string message = ((ex.InnerException != null) ? ex.InnerException.Message : ex.Message);
                response.Content = new StringContent(string.Format("Erreur lors du test de la connection: {0}", message));
            }

            // return the HTTP Response.
            return response;
        }

        [POST("api/connections/createconnection")]
        public HttpResponseMessage createconnection(Models.Connection connection)
        {

            var response = new HttpResponseMessage();

            try
            {
                if (connection != null)
                {

                    if (string.IsNullOrEmpty(connection.Password))
                    {
                        response.StatusCode = HttpStatusCode.InternalServerError;
                        response.Content = new StringContent("Mot de passe vide");
                        return response;
                    }
                    if (string.IsNullOrEmpty(connection.Url))
                    {
                        response.StatusCode = HttpStatusCode.InternalServerError;
                        response.Content = new StringContent("URL vide");
                        return response;
                    }
                    if (string.IsNullOrEmpty(connection.Username))
                    {
                        response.StatusCode = HttpStatusCode.InternalServerError;
                        response.Content = new StringContent("Nom d'utilisateur vide");
                        return response;
                    }


                    DashBox.Data.Connections con = new Data.Connections
                    {
                        Source = connection.Source,
                        Nom = connection.Nom,
                        Password = connection.Password,
                        Url = connection.Url,
                        Username = connection.Username
                    };


                    _context.Connections.InsertOnSubmit(con);

                    // submit the changes to the database

                    _context.SubmitChanges();

                    // set the server response to OK
                    response.StatusCode = HttpStatusCode.NoContent;
                }
                else
                {

                    response.StatusCode = HttpStatusCode.InternalServerError;
                    response.Content = new StringContent("Connection NULL");
                }
            }
            catch (Exception ex)
            {
                // something went wrong - possibly a database error. return a
                // 500 server error and send the details of the exception.
                response.StatusCode = HttpStatusCode.InternalServerError;
                string message = ((ex.InnerException != null) ? ex.InnerException.Message : ex.Message);
                response.Content = new StringContent(string.Format("Erreur lors de l'enregistrement de la connection: {0}", message));
            }

            // return the HTTP Response.
            return response;
        }
    }
}