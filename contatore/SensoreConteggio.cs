using System;

namespace contatore
{
    class SensoreConteggio
    {
        public int n;
        public int porta;
        private int GetValue(int minVal)
        {
      int nPersone=0;
            Random random = new Random();
            
            if (minVal == 0)
            {
                n = random.Next(0, 50);
            }
            else
            {
                n= random.Next(0,50);
            }
                nPersone = nPersone+n;

            return nPersone;

        }

        public void ContatorePersone(SensorePorta sensorePorta)
        {
            porta = sensorePorta.valStatoPorta;
        }

        public string ToJson()
        {
            return "{\"ContatorePersone\" :" + GetValue(1) + "}";
        }
    }
}
