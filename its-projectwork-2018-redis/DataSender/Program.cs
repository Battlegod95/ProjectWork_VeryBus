using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSRedis;

namespace DataSender
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
                Console.WriteLine(redis.BLPop(30, "sensors_data"));

                // send value to remote API
                // TODO...
            }
        }
    }
}
