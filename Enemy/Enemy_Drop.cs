using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///  敵を倒したらドロップする処理
/// </summary>
public class Enemy_Drop : MonoBehaviour {
    /// <summary>
    ///  Enemy_ManagerのScriptの情報を入れておく変数
    /// </summary>
    public Enemy_Manager Enemy_Manager_;
    /// <summary>
    ///  EnemyShipManagerのScriptの情報を入れておく変数
    /// </summary>
    public EnemyShipManager EnemyShipManager_;
    /// <summary>
    ///  ドロップする都道府県のPrefabを入れておく変数　inspectorで変更
    /// </summary>
    public GameObject[] Prefectures;

    // public GameObject[] ExperiencePoint;

    /// <summary>
    ///  確率　1-100パーセントまで
    /// </summary>
    [SerializeField, Range(0,100)]
    public int intProbability;


    //  public int intDropValue;//何個の経験値を生成するか

    /// <summary>
    ///  一回のみDropするようにするフラグ
    /// </summary>
    private bool isOneDrop;

    /// <summary>
    ///  どの都道府県、名産（経験値）をDropするか決める
    /// </summary>
    private int intDropRand;
    /// <summary>
    ///  Dropするか
    /// </summary>
    private int intDropProbability;


    // private Vector3 EXPPosition;



     /// <summary>
    ///  フラグが立ったらドロップする
    /// </summary>
    void Update () {
        if (EnemyShipManager_ == null && Enemy_Manager_.isEnemyDes == true)
        {
            Drop();
        }
        else if(Enemy_Manager_ == null && EnemyShipManager_.isEnemyDes==true)
        {
            Drop();
        }
    }

    /// <summary>
    ///  RANDOMでドロップするか決めてドロップするならどの県をドロップするか決めてから生成する
    /// </summary>
    void Drop()
    {
        if(isOneDrop==false)
        {
            intDropRand = Random.Range(0, Prefectures.Length);//どの都道府県、名産品を出すかのRandom
            intDropProbability = Random.Range(0, 100);//都道府県をだすか否かのRandom

            //for(int i = 0; i<intDropValue;i++)
            //{
            //    EXPPosition.x = transform.position.x + Random.Range(0, transform.localScale.x);
            //    EXPPosition.y = transform.position.y + Random.Range(0, transform.localScale.y);
            //    EXPPosition.z = transform.position.z + Random.Range(0, transform.localScale.z);
            //    Instantiate(ExperiencePoint[0], EXPPosition, Quaternion.Euler(0, 0, 0));//経験値、名産品を生成
            //}

            if (intDropProbability <= intProbability)
            {
                Vector3 Position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
                GameObject g = Instantiate(Prefectures[intDropRand], Position, Quaternion.Euler(0, 0, 0));//都道府県を生成する
                g.GetComponent<Rigidbody>().velocity = transform.forward * 2f;
            }
            isOneDrop = true;
        }
    }
}
