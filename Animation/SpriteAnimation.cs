using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimation : MonoBehaviour {

    public Sprite[] sprite;

    float time = 0f;
    bool flag = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;






        if (time >= 1)
        {
            if (flag)
            {
                GetComponent<SpriteRenderer>().sprite = sprite[1];
                flag = false;
                time = 0;
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = sprite[0];
                flag = true;
                time = 0;
            }
        }




		
	}
}
