using UnityEngine;
using UnityEngine.VR;


/// <summary>
/// VRのヘッドマウントディスプレイのトラッキングの処理
/// </summary>
public class TrackingReset: MonoBehaviour
{

    /// <summary>
    /// スペースキーを押したらトラッキングする
    /// </summary>
    void Update()
    {
        // spaceキーで位置トラッキングをリセットする
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InputTracking.Recenter();
        }
    }
}