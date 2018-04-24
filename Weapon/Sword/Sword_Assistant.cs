using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///  ソードのあたり判定に着ける　ダメージを送る処理
/// </summary>
public class Sword_Assistant : MonoBehaviour {

    /// <summary>
    ///  Sword_ManagerのScriptの情報を入れておく変数
    /// </summary>
    private Sword_Manager Sword_Manager_;
    /// <summary>
    ///  BoxColliderの情報を入れておく変数
    /// </summary>
    private BoxCollider BoxCollider_;
    /// <summary>
    ///  指定したTagに当たったら１フレームのみ通す　そしてダメージをSendMessageで送る
    /// </summary>
    void OnTriggerEnter(Collider other)
    {
        for(int i = 0; i < Sword_Manager_.strEnemyTagName.Length;i++)
        {
            if(other.tag==Sword_Manager_.strEnemyTagName[i])
            {
                other.transform.root.SendMessage("Damage", Sword_Manager_.SwordPower);
            }
        }
    }
    /// <summary>
    ///  フラグによってColliderをActiveにするかしないかを処理している
    /// </summary>
    void ColliderActive()
    {
        if (Sword_Manager_.isActiveCollider == true)
        {
            BoxCollider_.enabled = true;
        }
        else
        {
            BoxCollider_.enabled = false;
        }
    }
    /// <summary>
    ///  変数に情報を入れる処理
    /// </summary>
    void Awake()
    {
        Sword_Manager_ = transform.root.GetComponent<Sword_Manager>();
        BoxCollider_ = GetComponent<BoxCollider>();
    }

    /// <summary>
    ///  関数の呼び出し
    /// </summary>
    void Update()
    {
        ColliderActive();
    }

    

}
