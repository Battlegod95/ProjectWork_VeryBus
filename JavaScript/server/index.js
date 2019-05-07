// collegamento al db - è necessario "npm install --save influx"
const sql = require('influx');
const influx = new sql.InfluxDB('http://Verybus:password@192.168.101.74:8086/Verybus');

// creazione array statico - autobus
var situazioneAutobus = [];

async function routes(fastify, options) {

    fastify.get('/', async (request, reply) => {
             influx.query(`select * from DatiAutobus`)
                .then(result => {reply.send(result)})
                .catch(error => {reply.send(error)});        
    });

    fastify.post('/', async (request, reply) => {
        try {
            
            var targa = request.body.id;
            var StatoPortaR = request.body.StatoPorta;
            var ConteggioPersoneR = request.body.ConteggioPersone;
            var LatitudineR = request.body.Latitudine;
            var LongitudineR = request.body.Longitudine;
            var linea ="";

            //situazioneAutobus.push({ id: idR, StatoPorta: StatoPortaR, ConteggioPersone: ConteggioPersoneR, Latitudine: LatitudineR, Longitudine: LongitudineR, Data: DataA, Ora: OraA });
            influx.query(`insert DatiAutobus,TargaAutobus=@targa,Linea=@linea StatoPorta=@StatoPortaR,ContaPersone=@ContaPersoneR,Latitudine=@LatitudineR,Longitudine=@LongitudineR`)
            .then(result => {reply.send(result)})
            .catch(error => {reply.send(error)}); 
        } catch (error) {
            console.log(error);
            reply.send();
            reply.status(400).send("Bad request");
            //sql.close();
        }

    });

}
module.exports = routes;

