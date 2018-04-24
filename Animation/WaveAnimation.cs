using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveAnimation : MonoBehaviour {


    public Sprite[] Wave1 = new Sprite[2];
    public Sprite[] Wave2 = new Sprite[2];
    public Sprite[] Wave3 = new Sprite[2];
    public Sprite[] Wave4 = new Sprite[2];
    public Sprite[] Wave5 = new Sprite[2];
    public Sprite[] Wave6 = new Sprite[2];
    public Image[] ValueImage = new Image[2];
    public Image[] WaveImage = new Image[2];
   

    // Use this for initialization
    void Start () {
        Invoke("AnimeEND", 8f);
	}
	void AnimeEND()
    {
        GetComponent<Animator>().SetBool("Active", false);
    }


	// Update is called once per frame
	void Update () {

        if(GameObject.Find("CenterEyeAnchor").transform.GetComponent<Player_Maneger>().isSurvival == true)
        {
            gameObject.SetActive(false);
        }




        if (GameObject.Find("GameScript").transform.GetComponent<GameManager>().Wave == 1)
        {
            ValueImage[0].GetComponent<Image>().sprite = Wave1[0];
            ValueImage[1].GetComponent<Image>().sprite = Wave1[1];
        }
        else if (GameObject.Find("GameScript").transform.GetComponent<GameManager>().Wave == 2)
        {
            ValueImage[0].GetComponent<Image>().sprite = Wave2[0];
            ValueImage[1].GetComponent<Image>().sprite = Wave2[1];
        }
        else if (GameObject.Find("GameScript").transform.GetComponent<GameManager>().Wave == 3)
        {
            ValueImage[0].GetComponent<Image>().sprite = Wave3[0];
            ValueImage[1].GetComponent<Image>().sprite = Wave3[1];
        }
        else if (GameObject.Find("GameScript").transform.GetComponent<GameManager>().Wave == 4)
        {
            ValueImage[0].GetComponent<Image>().sprite = Wave4[0];
            ValueImage[1].GetComponent<Image>().sprite = Wave4[1];
        }
        else if (GameObject.Find("GameScript").transform.GetComponent<GameManager>().Wave == 5)
        {
            ValueImage[0].GetComponent<Image>().sprite = Wave5[0];
            ValueImage[1].GetComponent<Image>().sprite = Wave5[1];
        }
        else
        {
            ValueImage[0].GetComponent<Image>().sprite = Wave6[0];
            ValueImage[1].GetComponent<Image>().sprite = Wave6[1];
        }





    }
}
