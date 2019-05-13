using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulazione_Gps
{
    class Gps
    {
        public Gps() { }
        decimal[] posizione;
        private decimal[] PosizioneDecimale()
        {
            decimal[] posizione = new decimal[2];
            Random longitudine = new Random();
            Random latitudine = new Random();
            
            posizione[0] = Convert.ToDecimal(longitudine.Next(-18000000,18000000))/1000000;
            posizione[1] = Convert.ToDecimal(latitudine.Next(-90000000, 90000000)) / 1000000;


 
            return posizione;
        }
        public string ToJson()
        {
            posizione = PosizioneDecimale();
            string longitudine = posizione[0].ToString();
            string latitudine = posizione[1].ToString();
            longitudine.Replace(',', '.');
            latitudine.Replace(',', '.');
            return "{\"latitudine\":\"" + latitudine + "\",\"longitudine\":\"" + longitudine + "\"}";
        }
    }
}
