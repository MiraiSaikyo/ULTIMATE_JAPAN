using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  ソードを管理している
/// </summary>
public class Sword_Manager : MonoBehaviour {


    /// <summary>
    ///  コライダーのActive状態を示す
    /// </summary>
    public bool isActiveCollider = false;
    /// <summary>
    ///  剣の強さ威力
    /// </summary>
    public float SwordPower;
    /// <summary>
    ///  敵についているコライダーのTagを指定
    /// </summary>
    public string[] strEnemyTagName;
    /// <summary>
    ///  ColliderをON、OFFにするフラグ
    /// </summary>
    private bool isCollider;

    /// <summary>
    ///  ObjectにTagが付いたらColliderをActiveにする
    /// </summary>
    void Update()
    {

        if (!(gameObject.tag == "Untagged"))//親オブジェクトがなんらかのタグが入っていたら
        {
            isCollider = true;//コライダーをONにします
        }
       
        if(isCollider==true)
        {
            isActiveCollider = true;
        }

    }
}
