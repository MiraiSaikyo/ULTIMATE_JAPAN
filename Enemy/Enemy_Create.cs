using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///  時間で敵を生成する処理
/// </summary>
public class Enemy_Create : MonoBehaviour
{
    /// <summary>
    ///  inspectorで生成する場所を指定する
    /// </summary>
    public Transform[] CreatePosition;
    /// <summary>
    ///  inspectorで敵の種類を配列の中に入れてあげる
    /// </summary>
    public GameObject[] Enemy;
    /// <summary>
    ///  生成する時間
    /// </summary>
    public float CreateTime;
    /// <summary>
    ///  経過時間
    /// </summary>
    public float NowTime;
    /// <summary>
    ///  生成する場所のRandom一時保存
    /// </summary>
    public int CreateRand;
    /// <summary>
    ///  どの敵を生成するかのRandomの一時保存
    /// </summary>
    public int EnemyRand;
    /// <summary>
    ///  生成するときに立てるフラグ　１体のみ出るように制御する
    /// </summary>
    public bool isCreate;

    /// <summary>
    ///  関数の呼び出し
    /// </summary>
    void Update()
    {
        CreateEnemy();
        Create();
    }


    /// <summary>
    ///  経過時間を見て時間になったら生成フラグを立てる
    /// </summary>
    public void CreateEnemy()
    {
        NowTime += Time.deltaTime;//経過時間記録
        if (NowTime > CreateTime)//時間になったら
        {
            CreateRand = Random.Range(0, CreatePosition.Length);//生成する場所をRandomで選ぶ
            EnemyRand = Random.Range(0, Enemy.Length);//生成する敵をRandomで選ぶ
            isCreate = true;
            NowTime = 0;//経過時間を初期化
        }
    }


    /// <summary>
    ///  フラグが立ったら敵を生成する
    /// </summary>
    public void Create()
    {
        if (isCreate == true)
        {
            Instantiate(Enemy[EnemyRand], CreatePosition[CreateRand].position, Quaternion.Euler(0, 0, 0));//生成する
            isCreate = false;
        }

    }

}

