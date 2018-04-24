using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 都道府県が出てくる場所の処理
/// </summary>
public class bobobon : MonoBehaviour {


    /// <summary>
    /// 出す都道府県のPrefabを入れる変数
    /// </summary>
    public GameObject []prefab;
    /// <summary>
    /// 都道府県を押し出す威力
    /// </summary>
    public float power = 1;
    /// <summary>
    /// ルーレットの数字を保存しておく変数
    /// </summary>
    public int Number;
    /// <summary>
    /// 都道府県を出したかのフラグ
    /// </summary>
    public bool bon = false;




    /// <summary>
    /// フラグがたったら都道府県を出す
    /// </summary>
    void Update () {
		
        if(bon)
        {
            var item = Instantiate(prefab[Number], transform.position, Quaternion.identity) as GameObject;
            item.GetComponent<Rigidbody>().AddForce(transform.up * power);
            bon = false;
        }
	}
}
