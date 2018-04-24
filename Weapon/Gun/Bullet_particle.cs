using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_particle : MonoBehaviour {


    public string[] strTagName;
    public GameObject Effect;
    public bool isExplosion;

    void OnTriggerEnter(Collider other)
    {
        for(int i = 0; i < strTagName.Length;i++)
        {
            if (other.tag == strTagName[i])
            {
                Instantiate(Effect, gameObject.transform.position,Quaternion.Euler(0,0,0));
                isExplosion = true;
                Destroy(gameObject);
            }

        }
        
    }

}
