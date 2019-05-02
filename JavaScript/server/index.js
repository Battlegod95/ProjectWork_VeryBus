// collegamento al db


// creazione array statico - autobus
var situazioneAutobus = [
    //{ id: 1, StatoPorta: "True", ConteggioPersone: 0 , Latitudine: 0, Longitudine: 0, today:"01/01/2000", Ora: "00:00"}
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
            var LatitudineR = request.body.Latitudine;
            var LongitudineR = request.body.Longitudine;
            today = new Date();
            h =today.getHours();
            minuti=today.getMinutes();
            secondi=today.getSeconds();
            giorno = today.getDate();
            mese = today.getMonth()+1;
            date= today.getDate();
            year= today.getFullYear();

            if(minuti < 10) minuti="0"+minuti;
            if(secondi < 10) secondi="0"+secondi;
            if(h <10) h="0"+h;

        var DataA = giorno+"/"+mese+"/"+year;
        var OraA = h+":"+minuti+":"+secondi;
            
            situazioneAutobus.push({id: idR,StatoPorta: StatoPortaR,ConteggioPersone: ConteggioPersoneR, Latitudine: LatitudineR, Longitudine:LongitudineR, Data: DataA, Ora: OraA});

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

