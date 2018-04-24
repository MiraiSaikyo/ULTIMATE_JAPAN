using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// 都道府県がある一定の距離から離れたら消す処理
/// </summary>
public class Prefectures_Manager : MonoBehaviour {


    /// <summary>
    /// 範囲を指定する
    /// </summary>
    private Vector3 OverPosition = new Vector3(30, 10, 30);

    /// <summary>
    /// Rigidbodyの情報を入れておく変数
    /// </summary>
    Rigidbody Rigidbody_;

    private bool isHaving;


    /// <summary>
    /// 変数に情報を入れる処理
    /// </summary>
    void Start () {
        Rigidbody_ = GetComponent<Rigidbody>();
       
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Floor")
        {
            GetComponent<Animator>().SetBool("Destroy", true);
            Destroy(gameObject, 1f);
        }

    }

    /// <summary>
    /// 一定の距離離れたら消す
    /// </summary>	
    void Update () {
		if(transform.tag=="Untagged")
        {
           // Rigidbody_.velocity = transform.forward * PowerSpeed;
        }
        else
        {
            isHaving = true;
        }
        Change();
        Destroy();

    }

    void Destroy()
    {
        if (transform.position.x > OverPosition.x || transform.position.x < -OverPosition.x)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y > OverPosition.y || transform.position.y < -OverPosition.y)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z > OverPosition.z || transform.position.z < -OverPosition.z)
        {
            Destroy(gameObject);
        }
    }

    void Change()
    {
        if (isHaving == true)
        {
            GetComponent<BoxCollider>().isTrigger = false;
            Rigidbody_.useGravity = true;
            Rigidbody_.mass = 0.5f;
        }
    }
}
