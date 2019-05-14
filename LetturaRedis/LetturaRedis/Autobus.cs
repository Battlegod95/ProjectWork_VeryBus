using sensore;
using Simulazione_Gps;
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
        public Autobus()
        {
            gps = new Gps();
            persone = new SensoreConteggio();
            porta = new SensorePorta();
            Random gen = new Random();
            linea = gen.Next(0, 100);
            System.Threading.Thread.Sleep(50);
            targa = gen.Next(0000, 9999);
            System.Threading.Thread.Sleep(50);
        }
        
        public string ToJson()
        {

            string json = "{" + gps.ToJson().ToLower().Replace("{", "").Replace("}", "") + ",";
            persone.ContatorePersone(porta);
            json += persone.ToJson().Replace("{", "").ToLower().Replace("}", "").Replace(" ", "") + ",";
            json += porta.ToJson().ToLower().Replace("{", "").Replace("}", "").Replace(" ", "") +","+"\"linea\":"+linea+ "," + "\"targa\":" + targa + "}";
            return json;
        }
        

        

            
                



        

                

                

               
            

    }
}
