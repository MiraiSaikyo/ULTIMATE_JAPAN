using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
///  タッチパネルのボタンの処理
/// </summary>
public class Switch_Button : MonoBehaviour
{



    /// <summary>
    ///  次のを出すまでの時間
    /// </summary>
    public float CoolTime;
    /// <summary>
    ///  ボタンを押したかのフラグ
    /// </summary>
    public bool isSwitch_ON;
    /// <summary>
    ///  経過時間
    /// </summary>
    public float NowTime;

    /// <summary>
    ///  ルーレットを回すか止めておくかのフラグ
    /// </summary>
    public bool isRoulette;


    /// <summary>
    ///  最初はルーレットを回せるように経過時間をクールタイムと同じにしておく
    /// </summary>
    void Start()
    {
        NowTime = CoolTime;
    }

    /// <summary>
    ///  手で触れたかの判定
    /// </summary>
    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Hand")
        {
            if (isSwitch_ON == false)
            {
                isSwitch_ON = true;
                NowTime = 0f;
            }
        }
    }

    /// <summary>
    ///  経過時間の計算
    /// </summary>
    void Update()
    {

        NowTime += Time.deltaTime;
        if (NowTime > CoolTime)
        {
            isSwitch_ON = false;
            isRoulette = false;
        }
    }
}
