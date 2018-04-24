using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Status : MonoBehaviour {


    
    public BoxCollider []SwordCollider;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {


        if (!(gameObject.tag == "Untagged"))
        {
            for(int i = 0; i<SwordCollider.Length;i++)
            {
                SwordCollider[i].enabled = true;
            }
            
        }
        else
        {
            for (int i = 0; i < SwordCollider.Length; i++)
            {
                SwordCollider[i].enabled = false;
            }
        }



    }
}
