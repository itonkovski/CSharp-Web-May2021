using System;
using System.Text;
using SUS.HTTP;

namespace SUS.MvcFramework
{
    public abstract class Controller
    {
        public HttpResponse View(string viewPath)
        {
            var responseHtml = System.IO.File.ReadAllText(viewPath);
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);
            return response;
        }

        public HttpResponse File(string filePath, string contentType)
        {
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            var response = new HttpResponse(contentType, fileBytes);
            return response;
        }
    }
}
