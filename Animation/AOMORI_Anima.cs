using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  青森県の武器のアニメーション用
/// </summary>
public class AOMORI_Anima : MonoBehaviour {

    /// <summary>
    ///  Animatorの情報を入れる変数用
    /// </summary>
    private Animator Animator_;
    /// <summary>
    ///  inspector上でタグを指定二つ指定する
    /// </summary>
    public string []strTagName　= new string [2];
    /// <summary>
    ///  inspector上でAnimatorのBoolの名前を２つ指定する
    /// </summary>
    public string[] strBoolName = new string[2];


    /// <summary>
    ///  初期化、情報を入れる
    /// </summary>
    void Start () {

        Animator_ = GetComponent<Animator>();

	}

    /// <summary>
    ///  関数を呼ぶ
    /// </summary>
    void Update () {

        StyleChange();
    }
    /// <summary>
    ///  どの手で持っているか判定して違うAnimationをする
    /// </summary>
    void StyleChange()
    {
        for (int i = 0; i < strTagName.Length; i++)
        {
            if (gameObject.tag == strTagName[i])//LHavingのタグになったら
            {
                Animator_.SetBool(strBoolName[i], true);
            }
            else
            {
                Animator_.SetBool(strBoolName[i], false);
            }
        }
    }
}
