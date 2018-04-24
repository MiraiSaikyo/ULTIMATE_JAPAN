using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHavingVib : MonoBehaviour {

    bool isHaving;
    public  bool LR;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(LR==false)
        {
            if (Input.GetAxis("RHandTrigger") == 1 && isHaving == false && transform.childCount > 0)
            {
                isHaving = true;
                GameObject.Find("VR").transform.GetComponent<Vibration>().R_VIBRATION(255);
                GetComponent<AudioSource>().Play();
            }

            if (Input.GetAxis("RHandTrigger") == 0)
            {
                isHaving = false;
            }
        }
        else
        {
            if (Input.GetAxis("LHandTrigger") == 1 && isHaving == false && transform.childCount > 0)
            {
                isHaving = true;
                GameObject.Find("VR").transform.GetComponent<Vibration>().L_VIBRATION(255);
                GetComponent<AudioSource>().Play();
            }

            if (Input.GetAxis("LHandTrigger") == 0)
            {
                isHaving = false;
            }
        }
       

       
    }
}
