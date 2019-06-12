using CSRedis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InvioRedis
{
    class Programs
    {
        static void Main(string[] args)
        {
			string line;
		System.IO.StreamReader file = new System.IO.StreamReader(@".\Config.txt");  	
			line = file.ReadLine();
            // configure Redis
            var redis = new RedisClient(line);
			line = file.ReadLine();
            while (true)
            {
                // read from Redis queue
                //Console.WriteLine(redis.BLPop(1000, "sensors_data"));
                //  Console.WriteLine(redis.BLPop(100, "key"));

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(line);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = redis.BLPop(100, "key");

                     streamWriter.Write(json);
                   // Console.WriteLine(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    Console.WriteLine(result);
                }
            }
        }
    }
}
