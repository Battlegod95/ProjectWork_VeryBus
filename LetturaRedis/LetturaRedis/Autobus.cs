using sensore;
using Simulazione_Gps;
using contatore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSRedis;

namespace LetturaRedis
{
    class Autobus
    {
        private int linea;
        private int targa;
        private Gps gps;
        private SensoreConteggio persone;
        private SensorePorta porta;
        public Autobus(int linea)   //creazione autobus
        {
            this.linea = linea;
            gps = new Gps(this.linea);
            persone = new SensoreConteggio();
            porta = new SensorePorta();
            Random gen = new Random();       
            System.Threading.Thread.Sleep(50);
            targa = gen.Next(0000, 9999);
            System.Threading.Thread.Sleep(50);
        }
        
        public string ToJson()  //metodo che restituisce il json dell'autobus
                                //se la porta è aperta chiama il metodo per modificare il numero di persone
                                //se è chiuso mantiene il numero di persone dentro l'autobus
        {
            porta.StatoPorta();
            string portajson = porta.ToJson();
            if (portajson.Contains("true") == true)
            {
                
                persone.GetValue();
                string json = "{" + gps.ToJson().ToLower().Replace("{", "").Replace("}", "") + ",";

                json += persone.ToJson().Replace("{", "").ToLower().Replace("}", "").Replace(" ", "") + ",";
                json += portajson.ToLower().Replace("{", "").Replace("}", "").Replace(" ", "") + "," + "\"linea\":" + linea + "," + "\"targa\":" + targa + "}";
                return json;
            }
            else
            {
                string json = "{" + gps.ToJson().ToLower().Replace("{", "").Replace("}", "") + ",";
                
                json += persone.ToJson().Replace("{", "").ToLower().Replace("}", "").Replace(" ", "") + ",";
                json += portajson.ToLower().Replace("{", "").Replace("}", "").Replace(" ", "") + "," + "\"linea\":" + linea + "," + "\"targa\":" + targa + "}";
                return json;
            }
        }
        

        

            
                



        

                

                

               
            

    }
}
