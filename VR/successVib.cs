using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class successVib : MonoBehaviour
{

    public string LRName;

    void OnTriggerStay(Collider other)
    {
        if(LRName=="Right")
        {
            if (other.tag=="Right" || other.tag=="Left")
            {
                GameObject.Find("VR").transform.GetComponent<Vibration>().R_VIBRATION(255);
            }
        }
        else
        {
            if (other.tag == "Left" || other.tag == "Right")
            {
                GameObject.Find("VR").transform.GetComponent<Vibration>().L_VIBRATION(255);
            }
        }
    }
}
