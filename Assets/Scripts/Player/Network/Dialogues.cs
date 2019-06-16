using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogues : MainPlayerClass
{
    private Dictionary<string, List<string>> dialog = new Dictionary<string, List<string>>();

    private Dictionary<string, List<float>> dialogInst = new Dictionary<string, List<float>>();

    public List<string> GetDictionary(string key)
    {
        return dialog[key];
    }

    void Start()
    {
        FillDialogues();
        FillInstancesAndQuest();


    }

    private void FillDilaogMaster(string name, string[] texts)
    {
        List<string> txlist = new List<string>();
        foreach (string text in texts)
        {
            txlist.Add(text);
        }
        dialog.Add(name, txlist);
    }

    private void FillDialogues()
    {
        FillDilaogMaster("NPC_0001_D", new string[]{
            "Siento mucho lo de vuestro padre muchachos, el rey y sus huéspedes algún día lo pagaran caro...",
            "Si necesitais cualquier cosa, mi gente del pueblo del Agua os ayudará, no dudeis en ir."
        });
        FillDilaogMaster("NPC_0002_D", new string[]{
            "Ya estoy viejo para ir de caza o cargar con el carro y los víveres...",
            "Ahora me dedico a cuidar este pequeño jardín para tener verduras frescas para mi família y amigos.",
        });
        FillDilaogMaster("NPC_0003_D", new string[]{
            "Siempre veo movimiento en la zona de más allá del rio, y no me gusta un pelo.",
            "Creo que desde la ultima batalla contra la caballería de Mocholo, pese a perder, parece que no se rinden.",
            "¡Seguiré vigilando jovencito, núnca se sabe si pueden aparecer por aquí, mantendré mi espada afilada!",
        });
        FillDilaogMaster("NPC_0004_D", new string[]{
            "Este arbol es especial, fue donde le pedí matrimonio a mi mujer hace ya 60 año, aunque nos dejó hace 3 años..aún asi y vengo aquí cada día a recordarla.",
            "Aún recuerdo nuestra boda, fué ahí detrás, junto a ese viejo pilar...",
            "Antiguas historias decian que conducia a alguna parte tenebrosa y llena de maldad... me pregunto si serán ciertas.",
        });
        FillDilaogMaster("NPC_0005_D", new string[]{
            "¡Santo dios del cielo!, te prometo que lo tenía! Un pez más grande que yo! Pero tiró muy fuerte y se me llevó la caña!",
        });
        FillDilaogMaster("NPC_0006_D", new string[]{
            "Este lugar está encantado, o eso dicen...",
        });

        FillDilaogMaster("NPC_0009_D", new string[]{
            "Guardia de Mocholo!, a su servicio!","Desde que vivimos esta batalla contra los de las Tierras Fangosas, uno ha de estar alerta siempre"
        });
        FillDilaogMaster("NPC_0010_D", new string[]{
            "Me encargo de la protección del edificio principal de Mocholo, la Igleamiento!", "jeje, Es la iglésia y el ayuntamiento, lo inventé yo."
        });
        FillDilaogMaster("NPC_0011_D", new string[]{
            "¡Alto ahí caminante!","Ah perdona, te habia confundido con un bandido..."
        });
        FillDilaogMaster("NPC_0012_D", new string[]{
            "Mi hermano murió en la última batalla contra los salvajes...le vengaré, lo prometo",
        });
        FillDilaogMaster("NPC_0013_D", new string[]{
            "Nuestra misión es proteger la ciudad en caso de ataque compañero.",
        });
        FillDilaogMaster("NPC_0014_D", new string[]{
            "Zzz...zzz","Ay va!, me he quedado dormido! No se lo digas a mis superiores, por favor!"
        });
        FillDilaogMaster("NPC_0015_D", new string[]{
            "Esos salvajes rompieron el puente, no se puede pasar...",
        });
        FillDilaogMaster("NPC_0017_D", new string[]{
            "Me encargo de guardar esta entrada a Mocholo, no se si dejarte pasar...","Bueno, no pareces peligroso, adelante!"
        });
        FillDilaogMaster("NPC_0018_D", new string[]{
            "Te he visto venir, debes ser el hijo de Nexiant, siento lo de tu padre...","Esos canallas, lo pagarán caro algún dia", "Disfruta de Mocholo"
        });
        FillDilaogMaster("NPC_0019_D", new string[]{
            "Al cruzar el puente te deja cerca de terreno enemigo, ten cuidado",
        });
        FillDilaogMaster("NPC_0020_D", new string[]{
            "No me molestes, estoy trabajando..",
        });
        FillDilaogMaster("NPC_0021_D", new string[]{
            "Aquí detrás está la entrada a la cripta","Descansan todos los heroes caidos en combate, pero no se permite el acceso"
        });
        FillDilaogMaster("NPC_0022_D", new string[]{
            "Estoy sin género muchacho, los maleantes me robaron...",
        });
        FillDilaogMaster("NPC_0023_D", new string[]{
            "¿Cuanto hace que Mocholo está en guerra?","Desde siempre, esos indeseados de las Tierras Inhóspitas siempre nos intentan robar..."
        });
        FillDilaogMaster("NPC_0024_D", new string[]{
            "Esta es la Zona de mercaderes de armas, delante la de comidas","Aqui vivimos bien, no podemos quejarnos... salvo por los maleantes, entre nosotros no hay problemas."
        });
        FillDilaogMaster("NPC_0025_D", new string[]{
            "Siempre atento...",
        });
        FillDilaogMaster("NPC_0026_D", new string[]{
            "Hombre, es Ryn, he intentado llevar el carro para las Aguas, pero los guardas no me dejaron por que habian bandidos por la zona..",
        });
        FillDilaogMaster("NPC_0027_D", new string[]{
            "¡Hic!, Esta es la taber..Hic!, Siempre termino iguglgual.",
        });
        FillDilaogMaster("NPC_0028_D", new string[]{
            "No tengo víveres muchacho, salvo 4 cosas que están en mal estado","a ver si se acaba de una vez por todas con los maleantes!"
        });


    }
    public void FillInstancesAndQuest()
    {

        FillDilaogMaster("Quest_001I", new string[]{//Coordenadas de instancia
            "47,76","-3,5","-182,16",
            "143,7","-2,99","-187,1",
            "92,47","-1,23","-140,1",
            "35,83","-2,6","-144,0",
            "63,55","-1,57","-100,6",
        });


        FillDilaogMaster("Quest_001", new string[]{
            "Mi mujer está en cama enferma y necesito plantas medicinales. Tienen un color azul y salen por esta zona."+
            "Necesitaría 5 de ellas, puedes ayudarme?"
        });
        FillDilaogMaster("Quest_001R", new string[]{
            "Gracias a las plantas mi mujer recuperará las fuerzas antes."+
            " A todo esto, el chico de las provisiones debería haber llegado ya a través del puente, deberías ir a mirar si le ha pasado algo, el podría indicarte el camino a Mocholo.",
        });

        FillDilaogMaster("Quest_002", new string[]{
            "Me asaltaron unos bandidos y me robaron víveres y una rueda."+
            "A uno de ellos se les cayó una especie de piedra con una marca roja, mientras desaparecian a través de un portal mágico, igual te sirve. Si quieres pasar por el puente, tendrás que ayudarme a recuperar la rueda, te parece?, ah si, te doy esta espada, tal vez la necesites"
        });
        FillDilaogMaster("Quest_002R", new string[]{
            "Gracias por recuperar la rueda, ahora el puente está transitable."
        });


        FillDilaogMaster("Quest_003", new string[]{
            "Estamos intentando descubrir como destruir esas rocas fuera del bosque, mi hermano menor fué a investigar, nosotros estamos descansando un poco ya que los bandidos no dejan de intentar robarnos."+
            "Igual el podría ayudarte, aunque si no le traes nada, no creo que te ayude. Ten, te doy este jarro de agua para que se lo lleves, seguro que está sediento, porqué se dejó sus provisiones."
        });

        FillDilaogMaster("Quest_003R", new string[]{
            "Espero que des con él"
        });

        FillDilaogMaster("Quest_004", new string[]{
            "Te ha dado ese agua mi hermano mayor? Gracias."+
            "Me encontré un par de bandidos a los que les robé esta llave, creo que abre la puerta de esa base derruida que tienen. Igual ahí dentro encuentras algo o alguien capaz de destruir esas rocas que bloquean el paso."
        });

        FillDilaogMaster("Quest_004R", new string[]{
            "Suerte..!"
        });

        FillDilaogMaster("Quest_005", new string[]{
            "Gracias por liberarme!"+
            "¿Cómo, el paso bloqueado? Y que si puedo abrir camino? Bromeas chico? Soy el mejor pirotécnico de todo Mocholo, por eso me apresaron, para que les dijese como crear explosivos. Quemaré esos arboles en un pis pas"
        });
        FillDilaogMaster("Quest_005R", new string[]{
            "Gracias, vamos a desbloquear el paso"
        });

        FillDilaogMaster("Quest_006", new string[]{
            "Cuidado no te quemes, le damos?"
           
        });
        FillDilaogMaster("Quest_006R", new string[]{
            "Visita Mocholo"

        });

        FillDilaogMaster("Quest_007", new string[]{
            "Quieres llegar al desierto de Shoku? Es por el puente, en dirección oeste desde Mocholo. Pero el puente lo derrumbaron unos maleantes, deberías ir a hechar un vistazo, quizás te digan como pasar al otro lado del rio."

        });
        FillDilaogMaster("Quest_007R", new string[]{
            "El puente está al Oeste"

        });

        FillDilaogMaster("Quest_008", new string[]{
            "Esos maleantes rajaron las maderas, y el puente cayó al agua, no se puede pasar... Hasta que no acabemos con ellos, no podrán empezar las tareas de reconstrucción. Si sabes luchar, deberías ver al Capitán Sparrow, es el que está al mando, dirección este de Mocholo."+
            "Ten, te doy esta llave de la puerta, ya que la tenemos cerrada por si acaso aparece esa chusma"

        });
        FillDilaogMaster("Quest_008R", new string[]{
            "El puente está al Oeste"

        });

        FillDilaogMaster("Quest_009", new string[]{
            "No podemos aguantar mucho más, quedamos solo nosotros y la segunda caballería que defenderá Mocholo si nosotros caemos. Podrías ayudarnos a acabar con las huéspedes enemigas?"

        });
        FillDilaogMaster("Quest_009R", new string[]{
            "Gracias a ti, ahora Mocholo será un lugar tranquilo otra vez."

        });

        FillDilaogMaster("Quest_010", new string[]{
            "De no ser por tu ayuda, Mocholo ahora podría ser todo cenizas, como Desembarco del Rey. Muchas Gracias, muchacho. "

        });
        FillDilaogMaster("Quest_010R", new string[]{
            "Gracias, de verdad, por cierto el puente ya está arreglado, ya puedes viajar a Shoku."

        });
    }
}

