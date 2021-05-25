using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace HttpClientDemo
{
    class Program
    {
        static Dictionary<string, int> SessionStorage = new Dictionary<string, int>();
        const string NewLine = "\r\n";

        static async Task Main(string[] args)
        {
            //await ReadData();
            Console.OutputEncoding = Encoding.UTF8;
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 12345);
            tcpListener.Start();
            while (true)
            {
                var client = tcpListener.AcceptTcpClient();
                ProcessClientAsync(client);
            }
        }

        public static async Task ProcessClientAsync(TcpClient client)
        {
            using (var stream = client.GetStream())
            {
                byte[] buffer = new byte[1000000];
                //checks the id of the active thread
                //Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                var lenght = await stream.ReadAsync(buffer, 0, buffer.Length);
                //Console.WriteLine(Thread.CurrentThread.ManagedThreadId);


                string requestString = Encoding.UTF8.GetString(buffer, 0, lenght);
                Console.WriteLine(requestString);

                var sid = Guid.NewGuid().ToString();
                var match = Regex.Match(requestString, @"sid=[^\n]*\r\n");
                if (match.Success)
                {
                    sid = match.Value.Substring(4);
                }
                Console.WriteLine(sid);

                if(!SessionStorage.ContainsKey(sid))
                {
                    SessionStorage.Add(sid, 0);
                }

                SessionStorage[sid]++;

                //bool sessionSet = false;
                //if (requstString.Contains("sid="))
                //{
                //    sessionSet = true;
                //}

                string html = $"<h1>Hello from the CSharp WEB 2021 Server {DateTime.Now} refreshed for the {SessionStorage[sid]} time</h1>" +
                    $"<form action=/tweet method=post><input name=username /><input name=password />" +
                    $"<input type=submit /></form>" + DateTime.Now;

                string response = "HTTP/1.1 200 OK" + NewLine +
                    "Server: CSharpWebSoftUniServer 2021" + NewLine +
                    //"Location: https://www.google.com" + NewLine +
                    //If we want to redirect : "HTTP/1.1 307 Redirect"
                    "Content-Type: text/html; charset=utf-8" + NewLine +
                    "X-Server-Version: 1.0" + NewLine +
                    //when we use the sessionSet
                    //(!sessionSet ? ("Set-Cookie: sid=12u47941y821eu91eu91i; Path=/;" + NewLine) : string.Empty) +
                    $"Set-Cookie: sid={sid}; HttpOnly; Max-Age=" + (3 * 60) + NewLine +
                    //Expires= " + DateTime.UtcNow.AddHours(3).ToString() 
                    "Content-Lenght: " + html.Length + NewLine +
                    NewLine +
                    html + NewLine;

                byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                //Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                await stream.WriteAsync(responseBytes);
                //Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

                Console.WriteLine(new string('=', 70));
            }
        }

        public static async Task ReadData()
        {
            string url = "https://softuni.bg/courses/csharp-web-basics";
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(string.Join(Environment.NewLine,
                response.Headers.Select(x => x.Key + ": " + x.Value.First())));

        }
    }
}
