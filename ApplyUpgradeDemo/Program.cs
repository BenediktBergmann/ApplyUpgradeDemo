using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Tooling.Connector;

namespace ApplyUpgradeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var solutionName = args[0];
            
            string connectionString = args.Length == 3 ? args[1] + args[2] + ";" : ConfigurationManager.ConnectionStrings["CRM"].ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("No ConnectionString found.");
            }

            CrmServiceClient client = new CrmServiceClient(connectionString);

            var request = new DeleteAndPromoteRequest
            {
                UniqueName = solutionName
            };

            client.Execute(request);
        }
    }
}
