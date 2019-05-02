using sensore;
using Simulazione_Gps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSRedis;

namespace LetturaRedis
{
    class Program
    {
        static void Main(string[] args)
        {
            var gps = new Gps();
            var persone = new SensoreConteggio();
            
            var porta = new SensorePorta();
            var redis = new RedisClient("127.0.0.1");

            for (int i = 0; i < 10; i++)
            {
                string json = "{"+gps.ToJson().ToLower().Replace("{", "").Replace("}", "") + ",";



                persone.ContatorePersone(porta);

                json += persone.ToJson().Replace("{", "").ToLower().Replace("}", "").Replace(" ", "") + ",";

                json += porta.ToJson().ToLower().Replace("{", "").Replace("}", "").Replace(" ", "") +"}";
                Console.WriteLine(json);
                // redis.LPush(lat[0],lat[1],lon[0],lon[1],perssplit[0],perssplit[1],por[0],por[1]);
                redis.LPush("key",json);
               // Console.WriteLine(lat[0]+" "+ lat[1] + " " + lon[0] + " " + lon[1] + " " + perssplit[0] + " " + perssplit[1] + " " + por[0] + " " + por[1]);
                System.Threading.Thread.Sleep(100);
            }
            
            Console.ReadLine();
        }
    }
}
