using System;
using sensore;

namespace contatore
{
    class SensoreConteggio
    {
        public int variazione;
        public int porta;
        int nPersone = 10;
        private int GetValue()
        {
            
            Random random = new Random();

            if (nPersone == 0)
            {
                variazione = random.Next(0, 10);
                
            }
            else
            {
                
                variazione = random.Next(-5, 5);
                
            }
            nPersone = nPersone + variazione;
            if (nPersone > 50)
                nPersone = 50;
            if (nPersone < 0)
                nPersone = 0;

            return nPersone;

        }

        public void ContatorePersone(SensorePorta sensorePorta)
        {
            porta = sensorePorta.valStatoPorta;
        }

        public string ToJson()
        {
            return "{\"ContatorePersone\" :" + GetValue() + "}";
        }
    }
}
