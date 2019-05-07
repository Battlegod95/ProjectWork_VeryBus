// collegamento al db - è necessario "npm install --save influx"
const sql = require('influx');
const influx = new sql.InfluxDB('http://Verybus:password@192.168.101.74:8086/Verybus');

// creazione array statico - autobus
var situazioneAutobus = [];

async function routes(fastify, options) {

    fastify.get('/', async (request, reply) => {
             influx.query(`select * from prova`)
                .then(result => {reply.send(result)})
                .catch(error => {reply.send(error)});        
    });

    fastify.post('/', async (request, reply) => {
        try {
            var idR = request.body.id;
            var StatoPortaR = request.body.StatoPorta;
            var ConteggioPersoneR = request.body.ConteggioPersone;
            var LatitudineR = request.body.Latitudine;
            var LongitudineR = request.body.Longitudine;
            today = new Date();
            h = today.getHours();
            minuti = today.getMinutes();
            secondi = today.getSeconds();
            giorno = today.getDate();
            mese = today.getMonth() + 1;
            date = today.getDate();
            year = today.getFullYear();

            if (minuti < 10) minuti = "0" + minuti;
            if (secondi < 10) secondi = "0" + secondi;
            if (h < 10) h = "0" + h;

            var DataA = giorno + "/" + mese + "/" + year;
            var OraA = h + ":" + minuti + ":" + secondi;

            situazioneAutobus.push({ id: idR, StatoPorta: StatoPortaR, ConteggioPersone: ConteggioPersoneR, Latitudine: LatitudineR, Longitudine: LongitudineR, Data: DataA, Ora: OraA });
        } catch (error) {
            console.log(error);
            reply.send();
            reply.status(400).send("Bad request");
            //sql.close();
        }

    });

}
module.exports = routes;

