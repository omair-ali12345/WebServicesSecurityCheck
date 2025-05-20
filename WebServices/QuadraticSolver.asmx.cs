using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServices
{
    /// <summary>
    /// Summary description for QuadraticSolver
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class QuadraticSolver : System.Web.Services.WebService {

        [WebMethod]
        public string SolveByFormula(double a, double b, double c)
        {
            double discriminant = b * b - 4 * a * c;

            if (discriminant < 0)
                return "No real roots.";

            double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);

            return $"Roots by Formula: x1 = {x1}, x2 = {x2}";
        }

        [WebMethod]
        public string SolveByCompletingSquare(double a, double b, double c)
        {
            if (a == 0) return "Not a quadratic equation.";

            double h = -b / (2 * a);
            double k = a * h * h + b * h + c;

            if (k > 0)
                return "No real roots.";

            double root = Math.Sqrt(-k / a);
            double x1 = h + root;
            double x2 = h - root;

            return $"Roots by Completing Square: x1 = {x1}, x2 = {x2}";
        }

        [WebMethod]
        public string SolveByFactoring(double a, double b, double c)
        {
            if (a != 1)
                return "Factoring only supported for a = 1.";

            for (int i = -100; i <= 100; i++)
            {
                if (i == 0) continue;
                for (int j = -100; j <= 100; j++)
                {
                    if (i * j == c && i + j == b)
                        return $"Roots by Factoring: x1 = {-i}, x2 = {-j}";
                }
            }

            return "Cannot factor easily.";
        }
    }
}
