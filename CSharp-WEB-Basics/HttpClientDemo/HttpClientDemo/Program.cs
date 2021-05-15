using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //await ReadData();
            const string NewLine = "\r\n";
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 12345);
            tcpListener.Start();
            while (true)
            {
                var client = tcpListener.AcceptTcpClient();
                using (var stream = client.GetStream())
                {
                    byte[] buffer = new byte[1000000];
                    var lenght = stream.Read(buffer, 0, buffer.Length);

                    string requstString = Encoding.UTF8.GetString(buffer, 0, lenght);
                    Console.WriteLine(requstString);

                    string html = $"<h1>Hello from the CSharp WEB 2021 Server {DateTime.Now} </h1>";

                    string response = "HTTP/1.1 200 OK" + NewLine +
                        "Server: CSharpWebSoftUniServer 2021" + NewLine +
                        "Content-Type: text/html; charset=utf-8" + NewLine +
                        "Content-Lenght: " + html.Length + NewLine +
                        NewLine +
                        html;

                    byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                    stream.Write(responseBytes);

                    Console.WriteLine(new string('=', 70));
                }

                //using (var stream = client.GetStream())
                //{
                //    byte[] buffer = new byte[1000000];
                //    var lenght = stream.Read(buffer, 0, buffer.Length);

                //    string requstString = Encoding.UTF8.GetString(buffer, 0, lenght);
                //    Console.WriteLine(requstString);

                //    Console.WriteLine(new string('=', 70));
                //}
            }
        }

        public static async Task ReadData()
        {
            Console.OutputEncoding = Encoding.UTF8;
            string url = "https://softuni.bg/courses/csharp-web-basics";
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(string.Join(Environment.NewLine,
                response.Headers.Select(x => x.Key + ": " + x.Value.First())));

        }
    }
}
