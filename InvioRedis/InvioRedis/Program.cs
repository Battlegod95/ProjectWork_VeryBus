﻿using CSRedis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InvioRedis
{
    class Program
    {
        static void Main(string[] args)
        {

            // configure Redis
            var redis = new RedisClient("127.0.0.1");

            while (true)
            {
                // read from Redis queue
                //Console.WriteLine(redis.BLPop(1000, "sensors_data"));
                //  Console.WriteLine(redis.BLPop(100, "key"));

                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://127.0.0.1:3000/api/events/inserimento");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = redis.BLPop(100, "key");

                    streamWriter.Write(json);
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