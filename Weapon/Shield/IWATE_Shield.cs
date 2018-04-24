using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  岩手県の跳ね返すシールド
/// </summary>
public class IWATE_Shield : MonoBehaviour {
    /// <summary>
    ///  跳ね返した後Tagを変えるか変えないか
    /// </summary>
    public bool isTagChange;
    /// <summary>
    ///  inspectorで変更後のTagを指定する
    /// </summary>
    public string strChangeTag;
    /// <summary>
    ///  inspectorで指定したTagを跳ね返す
    /// </summary>
    public string[] strBulletTagName;
    /// <summary>
    ///  跳ね返す威力
    /// </summary>
    public float Power;
    /// <summary>
    ///  Rigidbodyの情報を入れる変数
    /// </summary>
    Rigidbody Rigidbody_;

    /// <summary>
    ///  あたり判定に当たったら１フレームのみ通す　指定した弾だったら跳ね返す
    /// </summary>
    void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < strBulletTagName.Length;i++)
        {
            if(strBulletTagName[i]==other.gameObject.tag)
            {
                if(isTagChange==true)
                {
                    other.gameObject.tag = strChangeTag;
                }
                other.GetComponent<Rigidbody>().velocity = (transform.forward * Power);

            }
        }

    }

    /// <summary>
    ///  情報を変数に入れる
    /// </summary>
    void Start () {
        Rigidbody_ = GetComponent<Rigidbody>();

    }
	

}
