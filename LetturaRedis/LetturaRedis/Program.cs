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
			
            var redis = new RedisClient("127.0.0.1");
            Autobus auto1 = new Autobus();
            Autobus auto2 = new Autobus();
            Autobus auto3 = new Autobus();
            Autobus auto4 = new Autobus();
            Autobus auto5 = new Autobus();

            while (true)
            {
                Console.WriteLine("Auto 1      "+auto1.ToJson());
                System.Threading.Thread.Sleep(50);
                Console.WriteLine("Auto 2      " + auto2.ToJson());
                System.Threading.Thread.Sleep(50);
                Console.WriteLine("Auto 3      " + auto3.ToJson());
                System.Threading.Thread.Sleep(50);
                /*   Console.WriteLine("Auto 2      " + auto2.ToJson());
                   System.Threading.Thread.Sleep(50);
                   Console.WriteLine("Auto 3      " + auto3.ToJson());
                   System.Threading.Thread.Sleep(50);
                   Console.WriteLine("Auto 4      " + auto4.ToJson());
                   System.Threading.Thread.Sleep(50);
                   Console.WriteLine("Auto 5      " + auto5.ToJson());*/

                redis.LPush("key", auto1.ToJson());
                System.Threading.Thread.Sleep(50);
                Console.WriteLine("dsadas");
                redis.LPush("key", auto2.ToJson());
                System.Threading.Thread.Sleep(50);
                redis.LPush("key", auto3.ToJson());
                System.Threading.Thread.Sleep(50);
                redis.LPush("key", auto4.ToJson());
                System.Threading.Thread.Sleep(50);
                redis.LPush("key", auto5.ToJson());
                System.Threading.Thread.Sleep(1000);
            }
            Console.ReadLine();
        }
    }
}
