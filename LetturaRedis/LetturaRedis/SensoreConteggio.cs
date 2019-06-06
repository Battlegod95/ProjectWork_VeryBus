using System;

namespace contatore
{
    class SensoreConteggio
    {
        public int variazione;
        public int porta;
        private int GetValue()
        {
            int nPersone = 10;
            Random random = new Random();

            if (nPersone == 0)
            {
                variazione = random.Next(0, 10);
            }
            else
            {
                while(variazione<=0)
                {
                variazione = random.Next(-5, 10);
                }
            }
            nPersone = nPersone + variazione;

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
