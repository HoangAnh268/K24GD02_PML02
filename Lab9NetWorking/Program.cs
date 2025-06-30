using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Encodings.Web;

namespace Lab9NetWorking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string url = "https://gooogle.com.v";
            //var uri = new Uri(url);
            //var uritype = typeof(Uri);
            //uritype.GetProperties().ToList().ForEach(property =>
            //{
                //Console.WriteLine($"{property.Name,15} {property.GetValue(uri)}");
            //});
           //Console.WriteLine($"Segments: {string.Join(",", uri.Segments)}");

            //string hostName = Dns.GetHostName();
            //IPHostEntry entry = Dns.GetHostEntry("google.com");
            //foreach(IPAddress ip in entry.AddressList)
            //{
                //Console.WriteLine(ip);
            //}
         

            //Ping pingSender = new Ping();
            //PingReply reply = pingSender.Send("google.com");

            //if (reply.Status == IPStatus.Success)
           // {
            //    Console.WriteLine(($"Ping Thành Công: {reply.RoundtripTime} ms"));
           // }
           // else
           // {
            //    Console.WriteLine($"Ping thất bại {reply.Status}");
            //}
            var taskLoadWeb = GetWebContent(url);
            taskLoadWeb.Wait();
            var html = taskLoadWeb.Result;
            Console.WriteLine(html);

            Console.ReadLine();               
        }
        public static async Task<string> GetWebContent(string url)
        {
            string html = "";
            try
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozila 5.0");
                HttpResponseMessage httpResponse = await httpClient.GetAsync(url);
                html = await httpResponse.Content.ReadAsStringAsync();

            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            return html;
        }
        static async void VD07()
        {
            using (var listener = new HttpListener())
            {
                listener.Prefixes.Add("http://localhost:9000/");
                listener.Start();
                Console.WriteLine("LOCALHOST: 9090");
                var context = await listener.GetContextAsync();
                var response = context.Response;
                string responseString = "<html><body>Hoang Anh!</body></html>";
                byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                response.ContentLength64 = buffer.Length;
                await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
                response.Close();
                listener.Stop();
            }
        }
    }
}
