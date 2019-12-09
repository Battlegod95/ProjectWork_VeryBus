using System;
using sensore;

namespace contatore
{
    class SensoreConteggio
    {
        public int variazione;
        int nPersone = 10;
        public int GetValue()       //metodo per modificare il numero di persone in maniera casuale
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

        

        public string ToJson()  //metodo per restituire il json del numero di persone nell'autobus
        {
            return "{\"ContatorePersone\" :" + nPersone + "}";
        }
        
        
    }
}
