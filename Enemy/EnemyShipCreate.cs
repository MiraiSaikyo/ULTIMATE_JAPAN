using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 敵母艦を生成する処理
/// </summary>
public class EnemyShipCreate : MonoBehaviour {
    /// <summary>
    /// 敵母艦のPrefabを入れておく変数
    /// </summary>
    public GameObject ParentShip;
    /// <summary>
    /// 敵を生成する場所
    /// </summary>
    private Vector3 CreatePosition= new Vector3(0,40,700);
    /// <summary>
    /// X座標のRandom範囲
    /// </summary>
    public float []X_Range = new float[2];
    /// <summary>
    /// 生成する時間
    /// </summary>
    [SerializeField, Range(0f, 180f)]
    public float CreateTime;
    /// <summary>
    /// 現在の経過時間
    /// </summary>
    private float NowTime;



    /// <summary>
    /// 変数に情報を入れる処理
    /// </summary>
    void Start () {
        CreatePosition.x = Random.Range(X_Range[0], X_Range[1]);//範囲内でRandomでX座標の値を決める
        Instantiate(ParentShip, CreatePosition, Quaternion.Euler(0, 180, 0));//決めた座標から生成する
    }


    /// <summary>
    /// 関数の呼び出し
    /// </summary>
    void Update () {

        CreateShip();

    }

    /// <summary>
    /// 敵母艦を生成する処理
    /// </summary>
    void CreateShip()
    {
        NowTime += Time.deltaTime;//時間経過を変数に入れる
        if (NowTime > CreateTime)//生成する時間になったら
        {
            CreatePosition.x = Random.Range(X_Range[0], X_Range[1]);//範囲内でRandomでX座標の値を決める
            Instantiate(ParentShip, CreatePosition, Quaternion.Euler(0, 180, 0));//決めた座標から生成する
            NowTime = 0f;//経過時間を初期化
        }
    }

}
