using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  敵を倒したときに入れるポイントの処理
/// </summary>
public class Enemy_Points : MonoBehaviour {
    /// <summary>
    ///  何点ポイントが入るかの変数
    /// </summary>
    public int GetPoint;
    /// <summary>
    ///  急所に当たった時の倍率
    /// </summary>
    public float Magnification;
    /// <summary>
    ///  急所に当たったかフラグ
    /// </summary>
    public bool isHeadHit;
    /// <summary>
    ///  加算処理を一回のみ行うためのフラグ
    /// </summary>
    private bool isAddition;
    /// <summary>
    ///  Enemy_ManagerのScriptの情報を入れておく変数
    /// </summary>
    public Enemy_Manager Enemy_Manager;
    /// <summary>
    ///  EnemyShipManagerのScriptの情報を入れておく変数
    /// </summary>
    public EnemyShipManager EnemyShipManager_;
    /// <summary>
    ///  PointsのScriptの情報を入れておく変数
    /// </summary>
    private Points Points_;
    /// <summary>
    ///  Objectの情報を入れておく変数
    /// </summary>
    private Transform GameScript;


    /// <summary>
    ///  変数に情報を入れる処理
    /// </summary>
    void Start()
    {
        GameScript = GameObject.Find("GameScript").transform;//ゲームスクリプトが入っているObjectを探す  
        Points_ = GameScript.GetComponent<Points>();//捜したらその情報を変数に入れる
    }

    /// <summary>
    ///  関数の呼び出し
    /// </summary>
    void Update()
    {
        if (EnemyShipManager_ == null && Enemy_Manager.isEnemyDes == true)//敵が死んだら
        {
            PointsGet();//ポイントを入手
        }
        else if (Enemy_Manager == null && EnemyShipManager_.isEnemyDes == true)
        {
            PointsGet();//ポイントを入手

        }
    }

    /// <summary>
    ///  ポイントの加算処理
    /// </summary>
    void PointsGet()
    {
        if(isAddition==false)//まだ加算していなければ
        {
            if (isHeadHit == true)//弱点に当たりましたか？
            {
                Points_.Earned_Points += (int)(GetPoint * Magnification);//元のポイントに対して倍率分かけてポイントに加算
            }
            else//当たっていなければ
            {
                Points_.Earned_Points += GetPoint;//普通にポイント加算
            }
            isAddition = true;//加算しました
        }
    }
}
