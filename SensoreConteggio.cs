using System;

namespace sensore
{
    class SensoreConteggio 
    {  
        public int count=0;
        private int GetValue(int minVal)
        {
            Random random = new Random();
            if (minVal == 0)
            {
                return random.Next(0, 20);
            }
            return random.Next(-10,20);
        }
        public void ContatorePersone(SensorePorta sensorePorta)
        {
            if(sensorePorta.valStatoPorta == 1)
            {
                count += GetValue(count);
            }
        }

        public string ToJson()
        {
            return "{\"ContatorePersone\" :" + count + "}";
        }
    }
}
