using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


/// <summary>
/// Scoreを可視化する処理
/// </summary>
public class Score_Text : MonoBehaviour
{

    /// <summary>
    /// PointsのScriptの情報を入れておく変数
    /// </summary>
    private Points Points_;
    /// <summary>
    /// TMP_TextのScriptの情報を入れておく変数
    /// </summary>
    public TMP_Text TMP_Text_;
    /// <summary>
    /// Objectの情報を入れておく変数
    /// </summary>
    Transform GameScript;


    Transform CenterEye;
    Player_Maneger Player_Maneger_;


    /// <summary>
    /// 変数に情報を入れる処理
    /// </summary>
    void Start()
    {
        GameScript = GameObject.Find("GameScript").transform;
        Points_ = GameScript.GetComponent<Points>();
    }


    /// <summary>
    /// ポイントの可視化処理
    /// </summary>
    void Update()
    {
        TMP_Text_.text = "\n Score   " + Points_.Earned_Points;//TextMeshProを使って文字を出す
    }

}
