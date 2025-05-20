using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServices
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService {

        [WebMethod]
        public string CheckForMaliciousContent(string input)
        {
            // Define a list of potentially malicious patterns
            string[] maliciousKeywords = new string[]
            {
        "DROP TABLE",
        "<script>",
        "SELECT *",
        "rm -rf",
        "--",           // SQL comment injection
        "INSERT INTO",
        "DELETE FROM",
        "UPDATE ",
        "xp_cmdshell",  // SQL Server command execution
        "exec",         // Execute command
        "shutdown",     // System command
        "wget",         // Command injection
        "curl",         // Command injection
            };

            foreach (string keyword in maliciousKeywords)
            {
                if (input.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return "Potentially malicious input detected.";
                }
            }

            return "Input is safe.";
        }


    }
}
