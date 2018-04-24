using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  汎用性のあるObjectの消去の処理
/// </summary>
public class Enemy_Destroy : MonoBehaviour {
    /// <summary>
    ///  どのtagに当たったら死すのか指定
    /// </summary>
    public string[] strDesTagName;
    /// <summary>
    ///  死亡フラグ
    /// </summary>
    public bool isDesEnemy;

    /// <summary>
    ///  あたり判定に当たったら１フレームのみ通す　指定したTagに当たったら消去
    /// </summary>
    void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < strDesTagName.Length; i++)//配列分ループ
        {
            if (other.tag == strDesTagName[i])//合致していたら
            {
                isDesEnemy = true;//死にましたフラグON
                Invoke("DesEnemy", 0.1f);//0.1秒後に実行          
            }
        }
    }

    /// <summary>
    ///  消去のみ関数
    /// </summary>
    void DesEnemy()
    {
        Destroy(gameObject);//敵の存在を消す
    }

}
