using System;

namespace sensore
{
    class SensorePorta
    {
        // Consideriamo che:
        // False significa che la porta è chiusa
        // True significa che la porta è aperta

        public int valStatoPorta;
        public bool StatoPorta()
        {
            Random random = new Random();
            valStatoPorta = random.Next(2);
            return (valStatoPorta==0 ? false : true);
        }

        public string ToJson()
        {
            return "{\"StatoPorta\" : " + (StatoPorta()) + "}";
        }
    }
}
