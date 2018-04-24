using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 敵の急所(ヘッドショット)に当たった時の処理
/// </summary>
public class HeadShotManager : MonoBehaviour
{

    /// <summary>
    /// Enemy_PointsのScriptの情報を入れておく変数
    /// </summary>
    private Enemy_Points Enemy_Points_;
    /// <summary>
    /// Enemy_ManagerのScriptの情報を入れておく変数
    /// </summary>
    private Enemy_Manager Enemy_Manager_;
    /// <summary>
    /// EnemyShipManagerのScriptの情報を入れておく変数
    /// </summary>
    private EnemyShipManager EnemyShipManager_;


    /// <summary>
    /// 変数に情報を入れる処理
    /// </summary>
    void Start()
    {
        EnemyShipManager_ = transform.root.GetComponent<EnemyShipManager>();
        Enemy_Points_ = transform.root.GetComponent<Enemy_Points>();
        Enemy_Manager_ = transform.root.GetComponent<Enemy_Manager>();
    }

    /// <summary>
    /// 急所に当たったらダメージの計算をしてHPを削る
    /// </summary>
    void Damage(float Power)
    {
        if (Enemy_Manager_ != null)
        {
            Enemy_Manager_.EnemyHP -= Power * 100;
        }
        else if(EnemyShipManager_!=null)
        {
            EnemyShipManager_.EnemyHP -= Power * 100;
        }
        Enemy_Points_.isHeadHit = true;//当たりました
    }
}
