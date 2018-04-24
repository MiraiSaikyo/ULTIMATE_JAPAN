using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 敵母艦から出てきてからの処理
/// </summary>
public class EnemyShipControl : MonoBehaviour {

    /// <summary>
    /// 射出からの移動の切り替えタイム
    /// </summary>
    public float SwitchTime;
    /// <summary>
    /// 経過時間を保存しておく変数
    /// </summary>  
    private float NowTime;
    /// <summary>
    /// Rigidbodyの情報を入れておく
    /// </summary>
    private Rigidbody Rigidbody_;
    /// <summary>
    /// EnemyShipのScriptの情報を入れておく変数
    /// </summary>  
    EnemyShip EnemyShip_;
    /// <summary>
    /// 時間になったら立てるフラグ
    /// </summary>
    private bool isTimeOut;

    /// <summary>
    /// 変数に情報を入れる処理
    /// </summary>
    void Start () {
        EnemyShip_ = GetComponent<EnemyShip>();
        Rigidbody_ = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// 経過時間を見て時間になったら移動系の処理を行う
    /// </summary>
    void Update () {
        NowTime += Time.deltaTime;
        if(NowTime>SwitchTime)
        {
            if(isTimeOut==false)
            {
                Rigidbody_.velocity = Vector3.zero;
                EnemyShip_.enabled = true;
                isTimeOut = true;
            }
        }
    }
}
