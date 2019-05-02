// collegamento al db


// creazione array statico - autobus
var situazioneAutobus = [
    { id: 1, StatoPorta: "True", ConteggioPersone: 0 },
    { id: 2, StatoPorta: "False", ConteggioPersone: 2 }
]

async function routes(fastify, options) {

    fastify.get('/', async (request, reply) => {
        return situazioneAutobus;
      });

    fastify.post('/', async (request, reply) => {
        try {
            var idR = request.body.id;
            var StatoPortaR = request.body.StatoPorta;
            var ConteggioPersoneR = request.body.ConteggioPersone;

            situazioneAutobus.push({id: idR,StatoPorta: StatoPortaR,ConteggioPersone:ConteggioPersoneR});

            /*
            let pool = await sql.connect(config);
            let insert = request.body;
            let result = await pool.request()
            .query`INSERT INTO [dbo].[Users]
                ([Username], [FullName], [BirthDate], [CorsoITS], [StudentName])
                VALUES (
                ${insert.Username}, ${insert.FullName}, ${insert.BirthDate}, ${corsoITS}, ${StudentName})`;
            sql.close();*/
            reply.status(201).send("Created");
        } catch (error) {
            console.log(error);
            reply.send();
            reply.status(400).send("Bad request");
            //sql.close();
        }
    });

}
module.exports = routes;