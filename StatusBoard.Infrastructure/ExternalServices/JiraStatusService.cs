using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using RestSharp;
using RestSharp.Authenticators;
using StatusBoard.Core.Exceptions;
using StatusBoard.Core.IExternalServices;

namespace StatusBoard.Infrastructure.ExternalServices
{
    public class JiraStatusService :IJiraStatusService
    {

        public JiraResponse JiraHighPriorityIssues()
        {
            var creds = Environment.GetEnvironmentVariable("JIRA_CREDENTIALS");
            if (string.IsNullOrEmpty(creds))
                throw new ApplicationConfigurationException(
                    "JIRA credentials are not provided in JIRA_CREDENTIALS environment variable");
            var client = new RestClient
            {
                BaseUrl = new Uri("https://transplantconnect.atlassian.net"),
                Authenticator = new HttpBasicAuthenticator(creds.Split(':')[0], creds.Split(':')[1])
            };

            var jql =
                "{\"jql\": \"project = ITX AND issuetype = \"General Bug\" AND status = Open AND (priority = \"1\" OR Severity=\"1 (Crash or Data Loss)\") AND assignee in (general-bug-queue, EMPTY)}";

            var request = new RestRequest("/rest/api/2/search", Method.GET);
            

            request.AddParameter("jql", jql);

            var response = client.Execute<JiraResponse>(request);

            //if something went wrong, throw up an error
            if (response.ErrorException != null)
                throw response.ErrorException;
            
            return response.Data;


        }
    }
}
