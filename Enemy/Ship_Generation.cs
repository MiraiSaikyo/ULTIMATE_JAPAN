using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 外部ファイルでObjectを生成する処理
/// </summary>
public class Ship_Generation : MonoBehaviour
{

    /// <summary>
    /// 出てくる場所の名称の候補
    /// </summary>
    public enum Name
    {
        Left,
        Center,
        Right
    }

    /// <summary>
    /// 出てくる場所の名称を指定する
    /// </summary>
    public Name NamePosi = Name.Center;
    /// <summary>
    /// 敵シップのプレハブ
    /// </summary>
    public GameObject Ship;
    /// <summary>
    /// 横と縦の幅を入れておく変数
    /// </summary>
    public Vector4 XYposi;
    /// <summary>
    /// 出てくる場所の位置を入れておく変数
    /// </summary>
    private Vector3 Position;
    /// <summary>
    /// 経過時間
    /// </summary>
    public float NowTime;
    /// <summary>
    /// 敵の射出時間
    /// </summary>　
    public float ShipShotTime;
    /// <summary>
    /// Objectの情報を入れる変数
    /// </summary>
    private Transform GameScript;
    /// <summary>
    /// GameManagerのScriptの情報を入れておく変数
    /// </summary>
    private GameManager GameManager_;

    /// <summary>
    /// 出てくる場所の名称の保存用変数
    /// </summary>
    private string PositionName;


    /// <summary>
    /// 変数に情報を入れる処理
    /// </summary>
    void Start()
    {
        GameScript = GameObject.Find("GameScript").transform;
        GameManager_ = GameScript.GetComponent<GameManager>();
        Init();
    }


    /// <summary>
    /// 外部ファイルで指定した時間、場所、Objectの種類で敵を出す
    /// </summary>
    void Update()
    {
        WaveReset();
        NowTime += Time.deltaTime;
        ShipShotTime = float.Parse(GameManager_.EnemyDataList[GameManager_.intShotCount][0]) + 5f;

        if (NowTime >= ShipShotTime)
        {
            if (PositionName == GameManager_.EnemyDataList[GameManager_.intShotCount][1])
            {
                Position.x = Random.Range(XYposi.x, XYposi.y);
                Position.y = Random.Range(XYposi.z, XYposi.w);
                Position.z = transform.position.z - transform.localScale.z / 2;
                if (GameManager_.intShotCount < int.Parse(GameManager_.NorumakillList[GameManager_.Wave][0]))
                {

                    Instantiate(Ship, Position, transform.rotation);
                    GameManager_.intShotCount++;

                }
            }
        }
    }


    /// <summary>
    /// Waveの初期化
    /// </summary>
    void WaveReset()
    {
        if(GameManager_.isWaveUP==true)
        {
            NowTime = 0;
        }
    }


    /// <summary>
    /// 名称を変数に入れる処理
    /// </summary>
    void Init()
    {
        switch (NamePosi)
        {
            case Name.Left:
                PositionName = "Left";
                break;
            case Name.Right:
                PositionName = "Right";
                break;
            case Name.Center:
                PositionName = "Center";
                break;
        }


        XYposi.x = transform.position.x - (transform.localScale.x / 2) + 2;
        XYposi.y = transform.position.x + (transform.localScale.x / 2) - 2;
        XYposi.z = transform.position.y - (transform.localScale.y / 2) + 2;
        XYposi.w = transform.position.y + (transform.localScale.y / 2) - 2;
    }
}