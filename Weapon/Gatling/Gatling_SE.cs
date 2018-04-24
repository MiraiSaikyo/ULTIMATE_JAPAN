using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// ガトリングのSE処理
/// </summary>
public class Gatling_SE : MonoBehaviour {

    /// <summary>
    /// エネミーを管理している
    /// </summary>
    private bool isAudioPlay;

    /// <summary>
    /// エネミーを管理している
    /// </summary>
    public TIBA_GUNAnima TIBA_GUNAnima_;

    /// <summary>
    /// エネミーを管理している
    /// </summary>
    public float volume;

    /// <summary>
    /// エネミーを管理している
    /// </summary>
    private AudioSource AudioSource_;


    /// <summary>
    /// エネミーを管理している
    /// </summary>
    void Start () {
        AudioSource_ = GetComponent<AudioSource>();

    }


    /// <summary>
    /// エネミーを管理している
    /// </summary>
    void Update () {
		if(TIBA_GUNAnima_.isGatlingSE==true)
        {
            AudioSource_.volume += volume;
            if(isAudioPlay==false)
            {
                AudioSource_.Play();
                isAudioPlay = true;
            }
           
        }
        else
        {
            AudioSource_.volume = 0f;
            isAudioPlay = false;
        }
	}
}
