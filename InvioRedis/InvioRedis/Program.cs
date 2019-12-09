﻿using CSRedis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace InvioRedis
{
    class Programs
    {
        static void Main(string[] args)
        {
			string line;
		//System.IO.StreamReader file = new System.IO.StreamReader(@".\Config.txt");  	
		//	line = file.ReadLine();
            // configure Redis
            var redis = new RedisClient("127.0.0.1");
            //	line = file.ReadLine();
            while (true)
            {
                // read from Redis queue
                //Console.WriteLine(redis.BLPop(1000, "sensors_data"));
                //  Console.WriteLine(redis.BLPop(100, "key"));

                MqttClient client = new MqttClient("192.168.101.65");
                byte code = client.Connect(Guid.NewGuid().ToString());
                ushort msgId; // creazione connessione con il broker




                try
                {

                    string json = redis.BLPop(100, "key");
                    string[] jsonarray = json.Split(',');                    
                    System.Threading.Thread.Sleep(5000);
                     msgId = client.Publish("verybus/autobus/" + jsonarray[4].Split(':')[1], // topic
                               Encoding.UTF8.GetBytes(json), // message body
                               MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, // QoS level
                               false); // retained
                               

                }
                catch { }
            }  
        }
    }
}
