using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 汎用性のあるObjectの時間での消去
/// </summary>
public class TimeDestroy : MonoBehaviour {

    /// <summary>
    /// 生成してから消去までの時間
    /// </summary>
    public float TimeDes;


    /// <summary>
    /// 消去までの時間のカウントを計算し始める
    /// </summary>
    void Start () {
        Invoke("Des", TimeDes);
	}

    /// <summary>
    /// Objectの消去
    /// </summary>
    void Des()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// 触れたら時間になる前に消す処理
    /// </summary>
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy" || other.tag == "EnemyAttack" || other.tag == "Shield"||other.tag=="MainCamera")
        {
            Des();
        }
    }
}
