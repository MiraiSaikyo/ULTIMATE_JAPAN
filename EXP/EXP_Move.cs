using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXP_Move : MonoBehaviour {

    public float floEXP_Value;//どのくらいの経験値をためるか
    public float floSpeed;//吸い込まれていくスピード
    private GameObject NearEnemy;//最も近い敵
    public string Suction_GateTag;//吸い込みのタグを検索
    private float TmpDistance = 0;//距離用一時変数
    private float Close_Distance = 0;//最も近いオブジェクトの距離


    void OnTriggerEnter(Collider other)
    {
       
        if (other.tag == Suction_GateTag)//吸い込み口まで吸い込まれていったら
        {
            Destroy(gameObject);//Objectを消す
            other.SendMessage("Experience", floEXP_Value);
        }
    }


    void Start()
    {
        NearEnemy = SearchTage(gameObject);//一番近い敵を取得
    }

    void Update()
    {
        transform.LookAt(NearEnemy.transform);//敵のほうを向く
        transform.Translate(Vector3.forward * floSpeed);//敵のほうに向かう
    }


    GameObject SearchTage(GameObject nowObj)
    {

        GameObject target = null;
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(Suction_GateTag))
        {

            TmpDistance = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            if (Close_Distance == 0 || Close_Distance > TmpDistance)//比べて近いのがあったら座標をいれる
            {
                Close_Distance = TmpDistance;//近い敵の距離
                target = obs; //ターゲット情報を入れる
            }

        }
        return target;

    }
}
