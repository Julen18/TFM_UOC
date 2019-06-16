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
            "A uno de ellos se les cayó una especie de piedra con una marca roja, mientras desaparecian a través de un portal mágico, igual te sirve. Si quieres pasar por el puente, tendrás que ayudarme a recuperar la rueda, te parece?"
        });
        FillDilaogMaster("Quest_002R", new string[]{
            "Gracias por recuperar la rueda, ahora el puente está transitable."
        });



    }
}

