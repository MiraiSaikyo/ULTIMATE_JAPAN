using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 銃のアタッチメントのレーザーポインターの処理
/// </summary>
public class Laser_Pointer : MonoBehaviour
{

    /// <summary>
    /// Pointerを出す場所を変数に入れる
    /// </summary>
    public GameObject Pointer;

    /// <summary>
    /// LineRendererの情報を入れる変数
    /// </summary>
    LineRenderer laser;

    /// <summary>
    /// RaycastHitの情報を入れる変数
    /// </summary>
    RaycastHit hit;


    /// <summary>
    /// 変数に情報を入れる処理
    /// </summary>
    void Start()
    {
        laser = this.GetComponent<LineRenderer>();
    }


    /// <summary>
    /// ポインターがどこかに当たったら貫通しなくする処理
    /// </summary>
    void Update()
    {
        if (Physics.Raycast(transform.position, Pointer.transform.up, out hit))
        {
            laser.SetPosition(0, Pointer.transform.position);
            print(hit.transform.gameObject.tag);
            laser.SetPosition(1, hit.point);
        }
        else
        {
            laser.SetPosition(0, Pointer.transform.position);
            laser.SetPosition(1, Pointer.transform.up * 100);
        }
    }
}
