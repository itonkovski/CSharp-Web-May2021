using System;
using System.IO;
using System.Text;
using SUS.HTTP;

namespace SUS.MvcFramework
{
    public abstract class Controller
    {
        public HttpResponse View(string viewPath)
        {
            var responseHtml = File.ReadAllText(viewPath);
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);
            return response;
        }
    }
}
