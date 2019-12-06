// collegamento al db - è necessario "npm install --save influx"
const sql = require('influx');
const module = require('./module.js');
let host = module.host;
let database = module.database;

var mqtt = require('mqtt')
var client  = mqtt.connect(module.broker)

const influx = new sql.InfluxDB({
    host: host,
    database: database,
    schema: [
      {
        measurement: 'DatiAutobus',
        fields: { StatoPorta: sql.FieldType.BOOLEAN,
                ContaPersone: sql.FieldType.INTEGER,
                Latitudine: sql.FieldType.FLOAT,
                Longitudine: sql.FieldType.FLOAT
         },
        tags: ['TargaAutobus', 'Linea']
      }
    ]
  });

// creazione array statico - autobus
var situazioneAutobus = [];

async function routes(fastify, options) {
/*
    fastify.get('/', async (request, reply) => {
             influx.query(`select * from DatiAutobus`)
                .then(result => {reply.send(result)})
                .catch(error => {reply.send(error)});        
    });
*/
    client.on('connect', function () {
      client.subscribe('verybus/autobus', function (err) {

      })
    })
    fastify.post('/', async (request, reply) => {    
            var targaR = request.body.targa;
            var StatoPortaR = request.body.statoporta;
            var ConteggioPersoneR = request.body.contatorepersone;
            var LatitudineR = request.body.latitudine;
            var LongitudineR = request.body.longitudine;
            var lineaR =request.body.linea;
            //situazioneAutobus.push({ id: idR, StatoPorta: StatoPortaR, ConteggioPersone: ConteggioPersoneR, Latitudine: LatitudineR, Longitudine: LongitudineR, Data: DataA, Ora: OraA });
            
            
            
            
            influx.writePoints([
                {
                  measurement: 'DatiAutobus',
                  tags: {
                    TargaAutobus: targaR,
                    Linea: lineaR,
                  },
                  fields: { StatoPorta: StatoPortaR,ContaPersone:ConteggioPersoneR,Latitudine:LatitudineR,Longitudine:LongitudineR }                
                }
              ], {
                database: 'Verybus',               
              }).then(function(){
                  reply.code(200).send();
              })
              .catch(error => {
                console.error(`Error saving data to InfluxDB! ${error.stack}`)
              });

    });

}
module.exports = routes;
