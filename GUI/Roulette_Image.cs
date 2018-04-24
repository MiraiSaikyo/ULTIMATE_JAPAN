using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// ルーレットの画像を回転する処理
/// </summary>
public class Roulette_Image : MonoBehaviour
{


    /// <summary>
    /// 都道府県が出てくる場所の指定
    /// </summary>
    GameObject bobobon;
    /// <summary>
    /// 都道府県の画像
    /// </summary>
    public Sprite[] Image;
    /// <summary>
    /// Imageの情報を入れておく変数
    /// </summary>
    Image Image_;
    /// <summary>
    /// bobobonのScriptの情報を入れておく変数
    /// </summary>
    bobobon bobobon_;
    /// <summary>
    /// Switch_ButtonのScriptの情報を入れておく変数
    /// </summary>
    public Switch_Button Switch_Button_;
    /// <summary>
    /// ルーレットの番号をいれてください
    /// </summary>
    public int RouletteNumber = 0;


    /// <summary>
    /// 変数に情報を入れる処理
    /// </summary>
    void Start()
    {
        bobobon = GameObject.Find("bobobon");
        bobobon_ = bobobon.GetComponent<bobobon>();
        Image_ = GetComponent<Image>();
    }


    /// <summary>
    /// ルーレットを回して、停止した数字を変数に情報を入れる処理
    /// </summary>
    void Update()
    {
        if (Switch_Button_.isSwitch_ON == false)//スイッチを押してなかったら
        {
            Image_.sprite = Image[RouletteNumber];
            RouletteNumber++;

            if (RouletteNumber >= Image.Length)
            {
                RouletteNumber = 0;
            }
        }
        else//押したら
        {

            if (Switch_Button_.isRoulette == false)
            {
                bobobon_.Number = RouletteNumber;
                Image_.sprite = Image[RouletteNumber];
                bobobon_.bon = true;//都道府県を出す

                Switch_Button_.isRoulette = true;
            }
        }
    }
}
