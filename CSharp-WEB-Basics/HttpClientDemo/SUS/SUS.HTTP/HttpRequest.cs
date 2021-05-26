﻿using System.Collections.Generic;

namespace SUS.HTTP
{
    public class HttpRequest
    {
        public HttpRequest(string requestString)
        {

        }

        public string Path { get; set; }

        public string Method { get; set; }

        public List<Header> Headers { get; set; }

        public List<Cookie> Cookies { get; set; }

        public string Body { get; set; }
    }
}