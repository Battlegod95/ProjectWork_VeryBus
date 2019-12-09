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
			
            var redis = new RedisClient("127.0.0.1");   //creazione istanza per redis e creazione dei 3 autobus
            Autobus auto1 = new Autobus(1);
            Autobus auto2 = new Autobus(2);
            Autobus auto3 = new Autobus(3);
            

            while (true)
            {
                                                            //Invio i dati a redis
                redis.LPush("key", auto1.ToJson());
                System.Threading.Thread.Sleep(50);
                redis.LPush("key", auto2.ToJson());
                System.Threading.Thread.Sleep(50);
                redis.LPush("key", auto3.ToJson());
                System.Threading.Thread.Sleep(50);
                System.Threading.Thread.Sleep(5000);
            }

        }
    }
}
