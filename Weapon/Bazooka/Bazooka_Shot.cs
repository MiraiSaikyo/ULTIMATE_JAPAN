using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazooka_Shot : Gun {

    public string[] strTagName;//タグの名前管理
    private int intLeft_Right;//0と1で右手か左手を決める
    public bool isEnemy;


    // Update is called once per frame
    void Update()
    {
        if (isEnemy == false)
        {
            for (int i = 0; i < strTagName.Length; i++)
            {
                if (gameObject.tag == strTagName[i])
                {
                    intLeft_Right = i;
                }
            }

            if (!(gameObject.tag == "Untagged"))
            {
                OVRShot(strInput[intLeft_Right]);
                if (intLeft_Right == 0)
                {
                    Reload(OVRInput.GetDown(OVRInput.RawButton.LThumbstick));
                }
                else
                {
                    Reload(OVRInput.GetDown(OVRInput.RawButton.RThumbstick));
                }
            }
        }
        else
        {
            Shot(true);
        }


    }

}
