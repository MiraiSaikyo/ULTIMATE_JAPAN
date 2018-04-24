using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(GameObject.Find("GameScript").transform.GetComponent<GameManager>().isGameEnd==true || GameObject.Find("CenterEyeAnchor").transform.GetComponent<Player_Maneger>().isSurvival == true)
        {
            Destroy(gameObject);
        }

        
	}



}
