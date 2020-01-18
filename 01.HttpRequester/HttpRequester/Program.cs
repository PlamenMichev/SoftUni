using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HttpRequester
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const string NewLine = "\r\n";
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 80);
            tcpListener.Start();
            while (true)
            {
                TcpClient tcpClient = tcpListener.AcceptTcpClient();

                //Get Request
                using NetworkStream networkStream = tcpClient.GetStream();
                byte[] requestBytes = new byte[1000000]; // TODO: Use buffer
                int bytesRead = networkStream.Read(requestBytes, 0, requestBytes.Length);
                string request = Encoding.UTF8.GetString(requestBytes, 0, bytesRead);

                //Return Response
                string pageName = GetPath(request);
                string responseText = GetResponse(pageName);
                string response = "HTTP/1.0 200 OK" + NewLine +
                                  "Server: SoftUniServer/1.0" + NewLine +
                                  "Content-Type: text/html" + NewLine +
                                  // "Location: https://google.com" + NewLine +
                                  // "Content-Disposition: attachment; filename=niki.html" + NewLine +
                                  "Content-Lenght: " + responseText.Length + NewLine +
                                  NewLine +
                                  responseText;
                byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                networkStream.Write(responseBytes, 0, responseBytes.Length);

                //Print Request
                Console.WriteLine(request);
                Console.WriteLine(new string('=', 60));
            }
        }

        public static async Task HttpRequest()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://softuni.bg/");
            string result = await response.Content.ReadAsStringAsync();
            File.WriteAllText("index.html", result);
        }

        public static string GetResponse(string pageName)
        {
            string fileName = $"{pageName}Html.txt";
            string result = "";

            try
            {
                //Reads html from file
                using (StreamReader reader = new StreamReader($"../../../ResponseFiles/{fileName}"))
                {
                    result = reader.ReadToEnd();
                }

                return result;
            }
            catch (Exception)
            {
                //Returns not found
                using (StreamReader reader = new StreamReader($"../../../ResponseFiles/Error404Html.txt"))
                {
                    result = reader.ReadToEnd();
                }

                return result;
            }
        }

        public static string GetPath(string request)
        {
            string pattern = @"\/[A-Za-z]+";
            Regex regex = new Regex(pattern);
            var page = regex.Match(request.Substring(0, 20));
            string result;

            //Check if it is home 
            if (page.Success == false)
            {
                result = "Home";
            }
            else
            {
                result = page.Value.Substring(1);
            }

            return result;
        }
    }
}
