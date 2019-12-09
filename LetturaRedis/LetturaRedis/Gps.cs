using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Simulazione_Gps
{
    class Gps

    {
        decimal[] posizione;
        string text;
        int contatoreposizione;
        public Gps(int linea)
        {
            contatoreposizione = 0;     
            
            

            switch (linea)      //scelta del percorso in base alla linea
            {
               
                case 1:

                     text = System.IO.File.ReadAllText(@"cordinatea1.txt");

                    break;
                case 2:

                     text = System.IO.File.ReadAllText(@"cordinatea2.txt");

                    break;
                case 3:

                     text = System.IO.File.ReadAllText(@"cordinatea3.txt");

                    break;
            }

        }

        
        private decimal[] Posizione()   //lettore delle posizione dell'autobus
        {

            string[] pos = text.Split(';');
            
            
            decimal[] posizione = new decimal[2];
            
            if (pos.Length==contatoreposizione)
            {
                contatoreposizione =contatoreposizione*-1;
                
            }
            if (contatoreposizione >= 0)
            {
                string[] posadesso = pos[contatoreposizione].Split(',');
                posizione[0] = Convert.ToDecimal(posadesso[0]);
                posizione[1] = Convert.ToDecimal(posadesso[1]);
                contatoreposizione++;
            }else
            {
                contatoreposizione++;
                if (contatoreposizione != 0)
                {
                    
                    string[] posadesso = pos[contatoreposizione * -1].Split(',');
                    posizione[0] = Convert.ToDecimal(posadesso[0]);
                    posizione[1] = Convert.ToDecimal(posadesso[1]);
                }else
                {
                    string[] posadesso = pos[contatoreposizione].Split(',');
                    posizione[0] = Convert.ToDecimal(posadesso[0]);
                    posizione[1] = Convert.ToDecimal(posadesso[1]);
                    contatoreposizione++;
                }


            }
            return posizione;

        }

        public string ToJson()  //metodo che restituisce il json della posizione dell'autobus
        {

            posizione = Posizione();
            string longitudine = posizione[0].ToString();
            string latitudine = posizione[1].ToString();
            longitudine.Replace(',', '.');
            latitudine.Replace(',', '.');
            return "{\"latitudine\":\"" + latitudine + "\",\"longitudine\":\"" + longitudine + "\"}";
        }
    }
}
