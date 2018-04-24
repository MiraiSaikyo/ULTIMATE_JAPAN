using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombed : MonoBehaviour {


    public string []strDesTagName;



    void OnTriggerEnter(Collider other)
    {
        for(int i = 0; i <strDesTagName.Length;i++)
        {
            if (other.tag == strDesTagName[i])
            {
                Destroy(gameObject);
            }
        }
        
    }
}
