using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  汎用性のあるObjectの移動処理
/// </summary>
public class EnemyMove : MonoBehaviour
{
    /// <summary>
    ///  Rigidbodyの情報を入れておく変数
    /// </summary>
    private Rigidbody Rigidbody_;//Rigidbody用の変数
    /// <summary>
    ///  敵の動くスピード
    /// </summary>
    public float speed;
    /// <summary>
    ///  動けるエリア内かのフラグ
    /// </summary>
    public bool isArea;

    /// <summary>
    ///  動く処理をストップするものに当たったら停止する
    /// </summary>
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")//finishのtagに当たったら
        {
            isArea = true;//動けない範囲になったら
        }
    }

    /// <summary>
    ///  変数に情報を入れておく変数
    /// </summary>
    void Start()
    {
        Rigidbody_ = GetComponent<Rigidbody>();// Rigidbodyの情報を入手

    }

    /// <summary>
    ///  関数の呼び出し
    /// </summary>
    void Update()
    {
        if (isArea == false)//動ける範囲なら
        {
            Move();
        }
    }

    /// <summary>
    ///  移動処理　world座標のZ軸で動かす
    /// </summary>
    public void Move()
    {
        Rigidbody_.position += transform.forward * speed;//worldの青軸を使って敵を動かす
    }
}
