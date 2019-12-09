using System;

namespace sensore
{
    class SensorePorta
    {
        // Consideriamo che:
        // False significa che la porta è chiusa
        // True significa che la porta è aperta
        private bool primo = true;
        public int valStatoPorta;
        string stato;
        public void StatoPorta()        //metodo che simula se una porta è aperta o chiusa
        {
            if (primo != true)
            {
                Random random = new Random();
                valStatoPorta = random.Next(0, 11);
                if (valStatoPorta >= 8)
                {
                    stato = "true";

                }
                else
                {
                    stato = "false";

                }
            }
            else
            {
                stato = "true";
                primo = false;
            }
        }

        public string ToJson() //metodo che restituisce il json dello stato della porta
        {
            
            return "{\"StatoPorta\" : " + stato + "}";
        }
        
    }
}
