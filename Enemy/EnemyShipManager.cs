using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 敵の輸送シップの情報を管理している
/// </summary>
public class EnemyShipManager : MonoBehaviour {


    /// <summary>
    /// EnemyのHP
    /// </summary>
    public float EnemyHP = 1f;
    /// <summary>
    /// 死亡判定
    /// </summary>
    public bool isEnemyDes;


    /// <summary>
    /// 関数の呼び出し
    /// </summary>
    void Update()
    {
        Enemy_Des();
    }


    /// <summary>
    /// ダメージの処理
    /// </summary>
    void Damage(float Damage)
    {
        EnemyHP -= Damage;
    }

    /// <summary>
    /// HPが０になったらやられる処理
    /// </summary>
    void Enemy_Des()
    {
        bool isFlg = false;
        if (EnemyHP <= 0)
        {
            if(isFlg==false)
            {
                GameObject.Find("GameScript").transform.GetComponent<GameManager>().intEnemyCount++;
                GameObject.Find("GameScript").transform.GetComponent<GameManager>().KillCount++;
                isEnemyDes = true;
                Invoke("Destroy", 0.1f);
                isFlg = true;
            }
           
        }
    }


    /// <summary>
    /// Objectの消去
    /// </summary>
    void Destroy()
    {
        Destroy(gameObject);
    }

   
}
