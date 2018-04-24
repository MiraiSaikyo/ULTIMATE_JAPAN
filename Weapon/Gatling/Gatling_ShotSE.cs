using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ガトリング砲の打つSE
/// </summary>
public class Gatling_ShotSE : MonoBehaviour {

    /// <summary>
    /// Gatling_StatusのScriptの情報を入れておく変数
    /// </summary>
    public Gatling_Status Gatling_Status_;

    /// <summary>
    /// AudioSourceの情報を入れておく変数
    /// </summary>
    private AudioSource AudioSource_;


    /// <summary>
    /// 変数に情報を入れる処理
    /// </summary>
    void Start () {
        AudioSource_ = GetComponent<AudioSource>();

    }


    /// <summary>
    /// フラグが立ったらSEを再生する
    /// </summary>
    void Update () {
		if(Gatling_Status_.isShotSE==true)
        {
            AudioSource_.Play();
            Gatling_Status_.isShotSE = false;
        }
	}
}
