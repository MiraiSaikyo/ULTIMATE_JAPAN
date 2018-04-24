using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ガトリング砲の回転Animation
/// </summary>
public class TIBA_GUNAnima : MonoBehaviour {


    /// <summary>
    /// Tagの名前指定
    /// </summary>
    public string[] strTagName = new string[2];
    /// <summary>
    /// トリガーの指定
    /// </summary>
    public string[] strTriggerName = new string[2];
    /// <summary>
    /// 右か左かを入れておく変数
    /// </summary>
    private int intLeft_or_Right;
    /// <summary>
    /// 最大回転数
    /// </summary>
    [SerializeField, Range(0f, 360f)]
    public float MaxRotation;
    /// <summary>
    /// ガトリングのSEを流すためのフラグ
    /// </summary>
    public bool isGatlingSE;
    /// <summary>
    /// 現在の回転スピード
    /// </summary>
    private float RotationUP;
    /// <summary>
    /// 回転速度
    /// </summary>
    public float RotationSpeed;
    /// <summary>
    /// 回転速度がマックスになっているかのフラグ
    /// </summary>
    public bool isMAXRotation;
    /// <summary>
    /// どの軸で回すか
    /// </summary>
    public bool []isXYZ = new bool[3];
    /// <summary>
    /// エネミー用か自分用かのフラグ
    /// </summary>
    public bool isEnemy;
    /// <summary>
    /// Objectの情報を入れておく変数
    /// </summary>
    public GameObject Parent;


    /// <summary>
    /// 関数の呼び出し
    /// </summary>
    void Update()
    {

        HandJudge();

        if (!(Parent.tag == "Untagged"))//親に何らかのtagが入っていたら
        { 
                Nozzle_Rotation(strTriggerName[intLeft_or_Right]);//トリガーを引数で送る
        }
        else
        {
            isGatlingSE = false;
        }

        if(isEnemy==true)
        {
            FastRotation();
        }

    }


    /// <summary>
    /// どの手で持っているかの判定
    /// </summary>
    void HandJudge()
    {
        for (int i = 0; i < strTagName.Length; i++)//Tagの配列分みて      
        {
            if (Parent.tag == strTagName[i])//指定したTagなら
            {
                intLeft_or_Right = i;//右か左かを入れる
            }
        }
    }



    /// <summary>
    /// 押しているかの判定
    /// </summary>
    void Nozzle_Rotation(string INPUT)//トリガーを引数で受け取り
    {
     
        if (Input.GetAxis(INPUT) == 1)//送られてきたトリガーを押したら
        {
            FastRotation();
           
        }
        else//押してないなら
        {
            EndRotation();
        }

    }

    
/// <summary>
/// 回転軸の判定
/// </summary>
void Rotate()
    {
        if (isXYZ[0] == true)
        {
            gameObject.transform.Rotate(new Vector3(RotationUP, 0, 0));//Y座標で回転させる

        }
        else if (isXYZ[1] == true)
        {
            gameObject.transform.Rotate(new Vector3(0, RotationUP, 0));//Y座標で回転させる

        }
        else if (isXYZ[2] == true)
        {
            gameObject.transform.Rotate(new Vector3(0, 0, RotationUP));//Y座標で回転させる

        }
    }


    /// <summary>
    /// 徐々に回転速度を上げる
    /// </summary>
    void FastRotation()
    {
        if (RotationUP <= MaxRotation)//指定した最大回転数以下なら
        {
            RotationUP += RotationSpeed;//徐々に回転速度を上げていく
            isMAXRotation = false;
        }
        else
        {
            isMAXRotation = true;
        }

        Rotate();
        isGatlingSE = true;//音を流すフラグ
    }


    /// <summary>
    /// 回転終了の処理
    /// </summary>
    void EndRotation()
    {
        isGatlingSE = false;//音を終了
        isMAXRotation = false;
        if (RotationUP >= 0)
        {
            RotationUP -= (RotationSpeed * 2);//回転速度を下げる
        }
        Rotate();
    }
}
