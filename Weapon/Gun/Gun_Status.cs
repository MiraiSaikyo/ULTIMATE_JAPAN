using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 銃を使用するための処理　Gunを基底クラスとして使用
/// </summary>
public class Gun_Status : Gun
{



    /// <summary>
    /// タグの名前管理
    /// </summary>
    public string[] strTagName = new string[2];
    /// <summary>
    /// 0と1で右手か左手を決める
    /// </summary>
    private int intLeft_Right;
    /// <summary>
    /// 敵に使うか自分に使うか
    /// </summary>
    public bool isEnemy;



    /// <summary>
    /// 弾を打つ処理
    /// </summary>
    void Update()
    {
        if (isEnemy == false)//自分で使うなら
        {
            Hand_Judge();//手の判定を行う
            Recast();//ﾘｷｬｽﾄ
            if (!(gameObject.tag == "Untagged"))//武器にtagが入っていたら
            {
               
                    OVRShot(strInput[intLeft_Right]);//その手に合ったトリガー名を引数で送る
                
            }
            Reload();
        }
        else//敵なら
        {
            Shot(true);//自動で弾を撃つ
        }
    }


    /// <summary>
    /// 手の判定
    /// </summary>
    void Hand_Judge()
    {
        for (int i = 0; i < strTagName.Length; i++)//配列分ループ
        {
            if (gameObject.tag == strTagName[i])//どの手で持っているかの判定
            {
                intLeft_Right = i;//0が左手　1が右手
            }
        }
    }


    /// <summary>
    /// リロードの処理
    /// </summary>
    void Reload()
    {

        if (intLeft_Right == 0)//左手なら
        {
            Reload(OVRInput.GetDown(OVRInput.RawButton.LThumbstick));//アナログスティックを押し込んだらリロード
        }
        else//右手なら
        {
            Reload(OVRInput.GetDown(OVRInput.RawButton.RThumbstick));//アナログスティックを押し込んだらリロード
        }
    }
}
