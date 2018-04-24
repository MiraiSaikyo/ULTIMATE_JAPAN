using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 輸送シップの移動、回転、ロボット生成をしている
/// </summary>
public class EnemyShip : MonoBehaviour {

    /// <summary>
    /// ターゲットに行くまでの時間
    /// </summary>
    private float ArrivalTime = 5f;
    /// <summary>
    /// 現在の時間
    /// </summary>
    private float NowTime;
    /// <summary>
    /// Rayの距離を入れておく変数
    /// </summary>
    private float RayLength = 80f;
    /// <summary>
    /// 目的地
    /// </summary>
    private Vector3 TargetPosition;
    /// <summary>
    /// スタートの位置
    /// </summary>
    private Vector3 startPosition;
    /// <summary>
    /// 最後に向かう場所
    /// </summary>
    private Vector3 EndPosition = new Vector3(0, 40, -100);
    /// <summary>
    /// 敵をどのY座標に出すかの変数
    /// </summary>
    private Vector3 RayHit;
    /// <summary>
    /// Rigidbodyの情報を変数に入れる
    /// </summary>
    private Rigidbody Rigidbody_;
    /// <summary>
    /// RaycastHitの情報を変数に入れる
    /// </summary>
    private RaycastHit Hit;
    /// <summary>
    /// Objectの情報を変数に入れる
    /// </summary>
    private Transform GameScript;
    /// <summary>
    /// GameManagerのScriptの情報を入れておく変数
    /// </summary>
    private GameManager GameManager_;
    /// <summary>
    /// 生成するてきの数
    /// </summary>
    public int intEnemyCreate;
    /// <summary>
    /// どのくらい敵を出したか
    /// </summary>
    public int intCreateCount;
    /// <summary>
    /// どの敵を出すか
    /// </summary>
    private int intEnemyRand;
    /// <summary>
    /// 目的地に着いたか
    /// </summary>
    private bool isDestination;
    /// <summary>
    /// 敵を生成するフラグ
    /// </summary>
    private bool isEnemyCreate;
    /// <summary>
    /// 1フレームだけ通すため
    /// </summary>
    private bool isCreate;
    /// <summary>
    /// 中心点となる位置
    /// </summary>
    public Vector3 BasePosition;
    /// <summary>
    /// 中心点からの範囲
    /// </summary>
    public Vector2 Landing_Point;
    /// <summary>
    /// 範囲を見えやすくするために使用
    /// </summary>
    public Vector3[] Position = new Vector3[5];
    /// <summary>
    /// 回転速度
    /// </summary>
    public float RotateSpeed;
    /// <summary>
    /// 敵（近接）を出す射出口
    /// </summary>
    public GameObject Discharge_Gate;
    /// <summary>
    /// 敵の種類を入れる配列
    /// </summary>
    public GameObject[] Enemy;




    /// <summary>
    /// 変数に情報を入れる処理
    /// </summary>
    void Start()
    {
        Rigidbody_ = GetComponent<Rigidbody>();
        GameScript = GameObject.Find("GameScript").transform;
        GameManager_ = GameScript.GetComponent<GameManager>();
        intEnemyCreate = int.Parse(GameManager_.EnemyDataList[GameManager_.intShotCount - 1][2]); //外部ファイルで何体出すかを代入

        PositionSet();//出せる範囲を決めます 
        RandPosition();//ターゲットの場所を決める
        Init();//初期化
    }


    /// <summary>
    /// 初期化する
    /// </summary>
    void Init()//初期化用
    {
        NowTime = Time.timeSinceLevelLoad;//タイムをReset
        startPosition = transform.position;//最初の位置を保存
    }


    /// <summary>
    /// 関数の呼び出し
    /// </summary>
    void Update()
    {
        if (transform.position == TargetPosition)//目標地点についたら
        {
            if(HitRay())
            {
                intCreateCount++;//インクリメント

                if (isCreate == false)//一度だけ通す
                {
                    Invoke("Create", 1f);
                    isDestination = true;
                    Discharge_Gate.SetActive(true);
                    isCreate = true;
                }
            }
            
        }
        else
        {
            isCreate = false;
        }

        if (isDestination == false)
        {
            Discharge_Gate.SetActive(false);
            Move();
        }

        if(transform.position==EndPosition)
        {
            Destroy(gameObject);
        }

        if (isEnemyCreate == true)//Shipが指定の位置についてまだ近接の敵を出していなければ
        {
            HitRay();

            //下記を外部ファイルのデータで出すやつを決める
            intEnemyRand = int.Parse(GameManager_.EnemyDataList[GameManager_.intEnemyCount][3]);


            Instantiate(Enemy[intEnemyRand], RayHit, Quaternion.Euler(0, 180, 0));//指定の座標に敵を生成する
            GameManager_.intEnemyCount++;//二足歩行ロボットのインクリメント
            isDestination = false;
            isEnemyCreate = false;

        }

    }

    /// <summary>
    /// Objectの移動
    /// </summary>
    void Move()
    {
        Rigidbody_.rotation = Quaternion.Slerp(Rigidbody_.rotation, Quaternion.LookRotation(TargetPosition - Rigidbody_.position), RotateSpeed);//ターゲットの方向を向く


        var Now = Time.timeSinceLevelLoad - NowTime;
        var rate = Now / ArrivalTime;
        transform.position = Vector3.Lerp(startPosition, TargetPosition, rate);
    }



    /// <summary>
    /// ターゲットとなる場所の決定
    /// </summary>
    void RandPosition()//ターゲットとなる場所を決定する
    {
        if(intCreateCount < intEnemyCreate)//出せる数より出した数のほうが小さかったら
        {
            TargetPosition.x = Random.Range(Position[0].x, Position[2].x + 1f);
            TargetPosition.y = Random.Range(20, 30);
            TargetPosition.z = Random.Range(Position[0].z, Position[2].z + 1f);

        }
        else
        {
            TargetPosition = EndPosition;//最終地点へ
        }
   
    }


    /// <summary>
    /// 生成する処理
    /// </summary>
    void Create()
    {
        isEnemyCreate = true;//生成フラグをONにする
        RandPosition();//ランダムでターゲットを作る
        Init();//初期化
        
    }

    /// <summary>
    /// エネミーを管理している
    /// </summary>
    bool HitRay()
    {
        Ray ray = new Ray(Discharge_Gate.transform.position, Discharge_Gate.transform.forward);//Rayを出す
        //Debug.DrawRay(Discharge_Gate.position, Discharge_Gate.forward * RayLength, Color.green);//Rayの可視化

        if (Physics.Raycast(ray, out Hit, RayLength))//もしヒットしたら
        {
            if (Hit.transform.tag == "Floor")
            {
                RayLength = transform.position.y - Hit.collider.transform.position.y;//Rayの長さを調整
                RayHit = Hit.point;//当たった先のY座標を保存
            }
            else
            {
                RandPosition();
                Init();
                return false;
            }
               
        }
        else//ヒットしていなかったら
        {
            RayLength = 80f;//Rayを80m飛ばす
        }
        return true;
    }



    /// <summary>
    /// 範囲の指定
    /// </summary>
    void PositionSet()
    {
        Position[0] = new Vector3(BasePosition.x - Landing_Point.x, BasePosition.y, BasePosition.z + Landing_Point.y);//左上
        Position[1] = new Vector3(BasePosition.x + Landing_Point.x, BasePosition.y, BasePosition.z + Landing_Point.y);//右上
        Position[2] = new Vector3(BasePosition.x + Landing_Point.x, BasePosition.y, BasePosition.z - Landing_Point.y);//右下
        Position[3] = new Vector3(BasePosition.x - Landing_Point.x, BasePosition.y, BasePosition.z - Landing_Point.y);//左下
        Position[4] = Position[0];//やむ終えず
    }



    /// <summary>
    /// Editor上で敵を生成する範囲を可視化する
    /// </summary>
    void OnDrawGizmosSelected()
    {


#if UNITY_EDITOR

        PositionSet();


        for (int i = 0; i< Position.Length;i++)//座標をわかりやすく表示
        {
            UnityEditor.Handles.Label(Position[i], Position[i].ToString());
        }

       // UnityEditor.Handles.Label(BasePosition, BasePosition.ToString());//ベースとなる位置の可視化　座標
        Gizmos.DrawSphere(BasePosition, 1f);//上記と同じ　ボール
        for (int i = 0; i<Position.Length-1;i++)
        {
            Gizmos.DrawSphere(Position[i], 3f);
            Gizmos.DrawLine(Position[i], Position[i+1]);
        }
#endif
    }

}
