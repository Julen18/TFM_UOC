using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraMap : MonoBehaviour
{

    public GameObject[] cameras;
    private GameObject player;

    private bool isMapOpen;
    private string camera;
    // Start is called before the first frame update
    void Start()
    {
        isMapOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!player)
            {
                player = GameObject.Find("Player(Clone)") ;
            }
            else
            {
                if (isMapOpen)
                {
                    DisableMap();
                    DisableAllCams();
                }
                else
                {
                    EnableMap();
                    WhereAmI();
                }
            }
            
        }
    }

    private void EnableMap()
    {
        isMapOpen = true;
    }

    private void  DisableMap()
    {
        isMapOpen = false;
    }

    private void WhereAmI()
    {
        float x = player.GetComponent<Transform>().position.x;
        float z = player.GetComponent<Transform>().position.z;
        DisableAllCams();

        if (TestRange(x, -105, 104) && TestRange(z, -90, -192))
        {
            cameras[0].SetActive(true);
        }
        else if (TestRange(x, 73, 141) && TestRange(z, -53, -139)) {
            cameras[1].SetActive(true);
        }
        else if (TestRange(x, -65, 134) && TestRange(z, -61, 1)) {
            cameras[2].SetActive(true);
        }
        else if (TestRange(x, -60, 200) && TestRange(z, -50, 177))
        {
            cameras[3].SetActive(true);
        }
        else if (TestRange(x, 143 ,272) && TestRange(z, -153, 30))
        {
            cameras[4].SetActive(true);
        }
    }

    bool TestRange(float numberToCheck, int bottom, int top)
    {

        if(numberToCheck < 0 && bottom < 0 && top < 0)
        {
            return (Mathf.Abs(numberToCheck) >= Mathf.Abs(bottom) && Mathf.Abs(numberToCheck) <= Mathf.Abs(top));
        }


        return (numberToCheck >= bottom && numberToCheck <= top );
    }
    private void DisableAllCams()
    {
        foreach (GameObject came in cameras)
        {
            came.SetActive(false);
        }
    }
}
