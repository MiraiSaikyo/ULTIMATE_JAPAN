using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // これを追加


/// <summary>
/// プレイヤーの情報管理
/// </summary>
public class Player_Maneger : MonoBehaviour
{

    /// <summary>
    /// 現在のHP
    /// </summary>
    [SerializeField]
    public float hp;
    /// <summary>
    /// 最大HP
    /// </summary>
    private float hp_Max;
    /// <summary>
    /// 無敵か無敵じゃないかのフラグ
    /// </summary>
    bool isInvincible;

    /// <summary>
    /// 生存フラグ　trueなら死亡　
    /// </summary> 
    public bool isSurvival;
    
    /// <summary>
    /// 無敵時間
    /// </summary>
    private float invincible_Time;

    /// <summary>
    /// 無敵時間を入れておく変数
    /// </summary>
    float count_I;

    /// <summary>
    /// Objectの情報を入れておく変数
    /// </summary>
    private Transform GameScript;

    /// <summary>
    /// GameManagerのScriptの情報を入れておく変数
    /// </summary>
    private GameManager GameManager_;

    public GameObject gameEnd;



    /// <summary>
    /// 初期化処理
    /// </summary>
    void Start()
    {
        Init();
    }


    /// <summary>
    /// 無敵時間の計算
    /// </summary>
    void Update()
    {

        if (isInvincible)
        {
            count_I += Time.deltaTime;
            if (count_I >= invincible_Time)
            {
                isInvincible = false;
                count_I = 0;
            }
        }
        if (hp == 0)
        {
            AudioListener.volume = 0f;
            isSurvival = true;
            gameEnd.SetActive(true);
        }
    }


    /// <summary>
    /// 初期化、変数に情報を入れる処理
    /// </summary>
    public void Init()
    {
        GameScript = GameObject.Find("GameScript").transform;//Scriptが入ったオブジェクトを探す
        GameManager_ = GameScript.GetComponent<GameManager>();//ゲームの情報が入ったScriptの情報を手に入れる
        hp_Max = float.Parse(GameManager_.GameManagementList[1][1]);
        invincible_Time = float.Parse(GameManager_.GameManagementList[2][1]);

        hp = hp_Max;
    }


    /// <summary>
    /// 敵からのダメージを計算する処理
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyAttack"|| other.gameObject.tag == "EnemyBullet")
        {
            if (!isInvincible)
            {
                hp -= 1;
                

                GetComponent<AudioSource>().Play();

                isInvincible = true;
            }
            GameObject.Find("VR").transform.GetComponent<Vibration>().R_VIBRATION(255);
            GameObject.Find("VR").transform.GetComponent<Vibration>().L_VIBRATION(255);
        }
        if(other.gameObject.tag=="LastAttack")
        {
            hp = 0;
        }
    }
}
