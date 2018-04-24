using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ガトリング砲の弾を打つ処理
/// </summary>
public class Gatling_Status : Gun
{

    /// <summary>
    /// タグの名前管理
    /// </summary>
    public string[] strTagName;
    /// <summary>
    /// 0と1で右手か左手を決める
    /// </summary>
    private int intLeft_Right;
    /// <summary>
    /// 敵用にするかのフラグ
    /// </summary>
    public bool isEnemy;
    /// <summary>
    /// TIBA_GUNAnimaのScriptの情報を入れておく変数
    /// </summary>
    public TIBA_GUNAnima TIBA_GUNAnima_;



    /// <summary>
    /// 弾を打つ処理
    /// </summary>
    void Update()
    {
        if (isEnemy == false)//敵用でなければ
        {
            Recast();
            for (int i = 0; i < strTagName.Length; i++)//TagNameの配列のサイズ分
            {
                if (gameObject.tag == strTagName[i])//ゲームオブジェクトが指定したTagNameなら
                {
                    intLeft_Right = i;//右か左かを判定する
                }
            }

            if (!(gameObject.tag == "Untagged"))//親Objectに何らかのtagが入ってたら
            {

                if (Input.GetAxis(strInput[intLeft_Right]) == 1)//ボタンを押してアクションしたら
                {
                    if (TIBA_GUNAnima_.isMAXRotation == true)
                    {
                        OVRShot(strInput[intLeft_Right]);//うつべしうつべし！！
                    }
                }
                              


                if (intLeft_Right == 0)//右なら
                {
                    Reload(OVRInput.GetDown(OVRInput.RawButton.LThumbstick));//アナログスティックを押し込むとリロード
                }
                else//左なら
                {
                    Reload(OVRInput.GetDown(OVRInput.RawButton.RThumbstick));//アナログスティックを押し込むとリロード
                }
            }
        }
        else//敵用なら
        {
            Shot(true);//自動的に打つ
        }
    }
}