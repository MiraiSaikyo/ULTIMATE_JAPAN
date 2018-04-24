using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///  弾の情報を管理している
/// </summary>
public class Bullet_Manager : MonoBehaviour {

    /// <summary>
    ///  弾の威力　銃側からセンドメッセージで来る
    /// </summary>
    public float Power;
    /// <summary>
    ///  敵のtagを入れておく配列
    /// </summary>
    public string[] strTagName;
    /// <summary>
    ///  弾と敵に当たった時のEffect
    /// </summary>
    public GameObject Effect;

    public GameObject headFX;
    public GameObject lastFX;

    /// <summary>
    ///  あたり判定に当たったら１フレームのみ通す　当たったやつにダメージを送る　エフェクトを出す
    /// </summary>
    void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < strTagName.Length; i++)//配列分ループ
        {
            if (other.tag == strTagName[i])//当たったObjectが敵なら
            {
                if (other.tag == "EnemyHead")
                {
                    other.transform.root.gameObject.SendMessage("Damage", Power * 100);//敵にセンドメッセージを送る
                    Instantiate(headFX, transform.position, transform.rotation);
                    Instantiate(Effect, gameObject.transform.position, Quaternion.Euler(0, 0, 0));//エフェクトを生成

                }
              

                else
                {
                    other.transform.root.gameObject.SendMessage("Damage", Power);
                    Instantiate(Effect, gameObject.transform.position, Quaternion.Euler(0, 0, 0));//エフェクトを生成
                }
               
                Destroy(gameObject);//弾を消す
            }

            else if (other.tag == "LastEnemy")
            {
                Instantiate(lastFX, transform.position, transform.rotation);
                Destroy(gameObject);//弾を消す
            }
            else
            {
                if(other.tag=="NAGANO")
                {
                    Instantiate(Effect, gameObject.transform.position, Quaternion.Euler(0, 0, 0));//エフェクトを生成

                }
            }

        }
    }
    /// <summary>
    ///  銃側から弾の威力をSendMessageで受け取る
    /// </summary>
    void BulletPower(float Damage)//銃側から威力を授かる
    {
        Power = Damage;//威力をもらいました
    }
}
