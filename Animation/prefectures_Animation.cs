using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  都道府県の持った時のアニメーション
/// </summary>

public class prefectures_Animation : MonoBehaviour {

    /// <summary>
    ///  Animatorの情報を入れる用変数
    /// </summary>
    private Animator Animator_;

    /// <summary>
    ///  初期化、変数に情報を入れる
    /// </summary>
    void Start () {
        Animator_ = GetComponent<Animator>();
	}

    /// <summary>
    ///  ObjectにTagが入っているかいないかでAnimationを切り替えている
    /// </summary>
    void Update () {
        //if (!(gameObject.tag == "Untagged"))
        //{
        //    Animator_.SetBool("Active", true);
        //}
        //else
        //{
        //    // Animator_.SetBool("Active", false);
        //}
        if (gameObject.tag == "L_HavingObject")
        {
            if (Input.GetAxis("LFingerTrigger") == 1)
            {
                Animator_.SetBool("Active", true);
            }

        }

        if (gameObject.tag == "R_HavingObject")
        {
            if (Input.GetAxis("RFingerTrigger") == 1)
            {
                Animator_.SetBool("Active", true);
            }


        }

    }
}
