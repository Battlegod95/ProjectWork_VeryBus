using System;

namespace sensore
{
    class Program
    {
        static void Main(string[] args)
        {
            SensorePorta sensorePorta = new SensorePorta();
            SensoreConteggio sensoreConteggio = new SensoreConteggio();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(sensorePorta.ToJson());
                for (int j = 0; j < 1; j++)
                {
                    sensoreConteggio.ContatorePersone(sensorePorta);
                    Console.WriteLine(sensoreConteggio.ToJson());
                }

            }

        }
    }
}
