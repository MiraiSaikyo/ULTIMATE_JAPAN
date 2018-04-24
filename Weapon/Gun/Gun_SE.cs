using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///  銃系のSE処理
/// </summary>
public class Gun_SE : MonoBehaviour {

    /// <summary>
    ///  Gun_StatusのScriptの情報を入れておく変数
    /// </summary>
    public Gun_Status Gun_Status_;
    /// <summary>
    ///  AudioSourceの情報を入れておく変数
    /// </summary>
    private AudioSource AudioSource_;
    /// <summary>
    ///  再生する音源を変数に入れる
    /// </summary>
    public AudioClip[] AudioClip;


    /// <summary>
    ///  変数に情報を入れる処理
    /// </summary>
    void Start()
    {
        AudioSource_ = GetComponent<AudioSource>();
    }



    /// <summary>
    ///  フラグが立ち次第一回だけ再生そしてフラグを折る
    /// </summary>
    void Update () {
        if(Gun_Status_.isShotSE == true)
        {
            AudioSource_.PlayOneShot(AudioClip[0],1f);
            Gun_Status_.isShotSE = false;
        }


        if (Gun_Status_.isBulletEnd == true)
        {
            AudioSource_.PlayOneShot(AudioClip[1], 1f);
            Gun_Status_.isBulletEnd = false;

        }

    }
}
