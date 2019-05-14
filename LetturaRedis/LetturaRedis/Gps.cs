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
        bool primo = false;
        private decimal[] PosizioneDecimale()
        {
            primo = true;
            decimal[] posizione = new decimal[2];
            Random longitudine = new Random();
            Random latitudine = new Random();
            
            posizione[0] = Convert.ToDecimal(longitudine.Next(-18000000,18000000))/1000000;
            posizione[1] = Convert.ToDecimal(latitudine.Next(-90000000, 90000000)) / 1000000;


 
            return posizione;
        }
        private decimal[] PosizioneDecimale2(decimal lat, decimal longi)
        {
            decimal[] posizione = new decimal[2];
            Random longitudine = new Random();
            Random latitudine = new Random();
            int longiap = Convert.ToInt32(longi * 1000000);
            int lati = Convert.ToInt32(lat * 1000000);
            posizione[0] = Convert.ToDecimal(longitudine.Next(longiap-5000 ,longiap + 5000)) / 1000000;
            posizione[1] = Convert.ToDecimal(latitudine.Next(lati-5000 ,lati  + 5000)) / 1000000;



            return posizione;
        }
        public string ToJson()
        {
            if (primo == false)
                posizione = PosizioneDecimale();
            else
                posizione = PosizioneDecimale2(posizione[1], posizione[0]);
            string longitudine = posizione[0].ToString();
            string latitudine = posizione[1].ToString();
            longitudine.Replace(',', '.');
            latitudine.Replace(',', '.');
            return "{\"latitudine\":\"" + latitudine + "\",\"longitudine\":\"" + longitudine + "\"}";
        }
    }
}
