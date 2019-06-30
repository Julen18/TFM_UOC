using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditSceneController : MonoBehaviour {


    public Outline canvas;
    private static  Text texts;
    private static  Outline effects;
    private float m_lastPressed;
    public float changePosColor = 2f;
    private string [] textos;
    private static int numText;
    // Use this for initialization
    void Start () {
        texts = GetComponent<Text>(); 
        effects = GetComponent<Outline>();
        numText = -1;
        m_lastPressed = 1.5f;
        textos = new string[3];
        textos[0] = "Videojuego desarrollado por Julen Gallego y Jordi Puertas";
        textos[1] = "Trabajo de fin de Máster";
        textos[2] = "Universitat Oberta de Catalunya";
        Invoke("ChangeNum", 2f);
    }


    void Update()
    {
        switch (numText)
        {
            case 0:
                texts.text = textos[0];
                break;
            case 1:
                texts.text = textos[1];
                break;
            case 2:
                texts.text = textos[2];
                Invoke("ChangeToMainScene", 3f);
                break;
        }

        m_lastPressed += Time.deltaTime;

        if (m_lastPressed > changePosColor)
        {
            effects.effectDistance = new Vector2(Random.Range(1, 3), Random.Range(-1, -3));
            m_lastPressed = 1.5f;
        }

    }

    void ChangeNum()
    {
        if (numText < 2)
        {
            numText++;
            Invoke("ChangeNum", 3.5f);
        }
    }
    void ChangeToMainScene()
    {
        SceneManager.LoadScene("MainStartScene");
    }
}
