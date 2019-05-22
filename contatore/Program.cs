using System;

namespace contatore
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 50; i++)
            {
            SensorePorta p = new SensorePorta();
            SensoreConteggio a = new SensoreConteggio();
            
            a.ContatorePersone(p);
            Console.WriteLine(a.ToJson());    
            }

        }
    }
}
