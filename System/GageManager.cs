using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// パネルのGaugeの処理
/// </summary>
public class GageManager : MonoBehaviour
{
    /// <summary>
    /// Gaugeの数値
    /// </summary>
    private float GaugeValue;
    /// <summary>
    /// 画像のデータを入れておく変数
    /// </summary>
    public Image Image_;
    /// <summary>
    /// Switch_ButtonのScriptの情報を入れておく変数
    /// </summary>
    public Switch_Button Switch_Button_;

    /// <summary>
    /// 時間によってGaugeを動かす
    /// </summary>
    void Update()
    {

        GaugeValue = Switch_Button_.NowTime / Switch_Button_.CoolTime;
        Image_.fillAmount = GaugeValue;
    }
}
