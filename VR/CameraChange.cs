using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

/// <summary>
/// VRのヘッドマウントディスプレイがあるかないかでカメラの種類を変える処理
/// </summary>

public class CameraChange : MonoBehaviour {
    /// <summary>
    /// カメラの種類を変数に入れる
    /// </summary>
    public GameObject[] Camera = new GameObject[2];  //カメラの種類を保存



/// <summary>
/// 起動したときにVRのカメラがあるか判定してあったらVR用のカメラにする
/// </summary>
    void Awake() {
		
        if(VRDevice.isPresent==true)//Oculusが接続されていたら
        {
            Camera[0].SetActive(true);//Oculusのカメラをアクティブにする
            Camera[1].SetActive(false);//メインカメラを非アクティブにする
        }
        else//接続されていなかったら
        {
            Camera[0].SetActive(false);//Oculusのカメラを非アクティブにする
            Camera[1].SetActive(true);//メインカメラをアクティブにする
        }
	}
}
