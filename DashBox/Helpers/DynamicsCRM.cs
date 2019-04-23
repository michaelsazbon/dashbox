using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.Web;

namespace DashBox.Helpers
{
    public class DynamicsCRM
    {

        public static IOrganizationService Connect(
            string CrmPassword,
            string CrmURL,
            string CrmUsername
        )
        {

            var clientCredentials = new ClientCredentials();
            clientCredentials.UserName.UserName = CrmUsername;
            clientCredentials.UserName.Password = CrmPassword;
            return new OrganizationServiceProxy(new Uri(CrmURL + "/XRMServices/2011/Organization.svc"), null, clientCredentials, null);

        }
    }
}