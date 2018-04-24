using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///  汎用性のあるObjectの回転
/// </summary>
public class EnemyRotation : MonoBehaviour {
    /// <summary>
    ///  ターゲットとなるObjectの情報を入れておく変数
    /// </summary>
    private Transform target;
    /// <summary>
    ///  Rigidbodyの変数を入れておく変数
    /// </summary>
    private Rigidbody Rigidbody_;
    /// <summary>
    ///  回転速度の管理
    /// </summary>
    public float rotatespeed;

    /// <summary>
    ///  変数に情報を入れる処理
    /// </summary>
    void Start () {
        target = GameObject.Find("CenterEyeAnchor").transform;
    
        Rigidbody_ = GetComponent<Rigidbody>();//Rigidbodyをいじっている
    }

    /// <summary>
    ///  関数の呼び出し
    /// </summary>
    void Update () {

        Rotation();
    }

    /// <summary>
    ///  ターゲットに向かって向きを変える
    /// </summary>
    void Rotation()
    {
        Rigidbody_.rotation = Quaternion.Slerp(Rigidbody_.rotation, Quaternion.LookRotation(target.position - Rigidbody_.position), rotatespeed);//ターゲットの方向を向く

    }
}
