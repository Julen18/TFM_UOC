using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DifuminationLogo : MonoBehaviour {

    // Use this for initialization

    private Image img;
    private float changePosColor = 2f;
    private float m_lastTime;
    private byte numCol=0;
    void Start () {
        img = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {

        m_lastTime += Time.deltaTime;

        if (m_lastTime > changePosColor)
        {
            if(numCol< 255)
            {
                img.color = new Color32(numCol, numCol, numCol, 255);
            }
            if (numCol == 255)
            {
                Invoke("LoadSceneMain", 3.5f);
                img.enabled = false;
            }
            Debug.Log(numCol);
            numCol ++;
            m_lastTime = 1.99f;
        }


    }
    private void LoadSceneMain()
    {
        SceneManager.LoadScene("MainStartScene");
    }
}
