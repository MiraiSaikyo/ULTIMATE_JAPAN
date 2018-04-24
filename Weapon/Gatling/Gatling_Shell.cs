using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ガトリング砲の空薬きょう
/// </summary>
public class Gatling_Shell : MonoBehaviour {


    /// <summary>
    /// Gatling_StatusのScriptの情報を入れておく変数
    /// </summary>
    public Gatling_Status Gatling_Status_;
    /// <summary>
    /// 薬きょうのPrefabを入れる変数
    /// </summary>
    public GameObject Shell;



    /// <summary>
    /// フラグが立ったら薬きょうを生成する
    /// </summary>
    void Update () {
		
        if(Gatling_Status_.isShell==true)
        {
            Instantiate(Shell, transform.position, transform.rotation);
            Gatling_Status_.isShell = false;
        }
	}
}
