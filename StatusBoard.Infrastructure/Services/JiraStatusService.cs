using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using StatusBoard.Core.IServices;

namespace StatusBoard.Infrastructure.Services
{
    public class JiraStatusService :IJiraStatusService
    {

        private IUnitOfWork _unitOfWork;

        public JiraStatusService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async void JiraHighPriorityIssues()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://transplantconnect.atlassian.net");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var creds = Environment.GetEnvironmentVariable("JIRA_CREDENTIALS");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(creds)));

                var jql = HttpUtility.UrlEncode(
                    "project = ITX AND issuetype = \"General Bug\" AND status = Open AND (priority = \"1\" OR Severity=\"1 (Crash or Data Loss)\") AND assignee in (general-bug-queue, EMPTY)");

                var response = await client.GetAsync("/rest/api/2/search?jql=" + jql);

                if (response.IsSuccessStatusCode)
                {
                    //now we need to write out the result to the db
                    var x = await response.Content.ReadAsAsync<JiraResponse>();
                    var y = x.Total;
                }

            }
        }

        private class JiraResponse
        {
            public string Expand { get; set; }
            public int StartAt { get; set; }
            public int MaxResults { get; set; }
            public int Total { get; set; }
            public List<Issue> Issues { get; set; } 
            public class Issue
            {
                public string Expand { get; set; }
                public string Id { get; set; }
                public string Self { get; set; }
                public string Key { get; set; }
            }
        }
    }
}
