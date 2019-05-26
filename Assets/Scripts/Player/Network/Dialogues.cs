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
        FillDilaogMaster("NPC_0001_D",new string[]{
            "Se sabe desde hace días que algo malo ocurrió en la granja. Resulta que el caballero Nexiant murió.",
            "Según cuentan, los sicarios del rey le dieron muerte dejando a las pobres criaturas desamparadas."
        });
        FillDilaogMaster("NPC_0002_D", new string[]{
            "¡El otro día fui a pescar truchas al rio, mala suerte me acompañó que solo pesqué un resfriado!",
        });
        FillDilaogMaster("NPC_0003_D", new string[]{
            "Os contaré, mi valiente admirador, una historia que me hizo ser muy famoso en estas tierras.",
            "Todo empezó, cuando empecé a perder todo mi dinero, apostandolo en la ciudad principal de Mocholo. Por aquel entonces solo vivia para la bebida y las apuestas",
            "Y tras todo eso, ¡hic!, ahora soy un simple calvo...por cierto, me llamo Jordi.",
        });

        FillDilaogMaster("Quest_001", new string[]{
            "Necesito manzanas para hacerme un gazpacho y curar el resfriado",
            "Ahora necesito que me polees suavemente."
        });
        FillDilaogMaster("Quest_001R", new string[]{
            "Gracias a las manzanas, ya podré recuperar fuerzas",
            "la pole polileo polilei"
        });


        FillDilaogMaster("Quest_001I", new string[]{//Coordenadas de instancia
            "-12","-3","-175,40",
            "-17","-3","-170,40",
            "-8","-3","-166,40",
        });




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



}

