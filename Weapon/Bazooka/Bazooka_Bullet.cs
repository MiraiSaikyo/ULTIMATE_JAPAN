using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazooka_Bullet : MonoBehaviour
{

    private GameObject NearEnemy;//最も近い敵
    public GameObject Effect;
    public float floSpeed;
    public string []EnemyTag;
    public string[] strTagName;
    


    void OnTriggerEnter(Collider other)
    {
        for(int i = 0; i<strTagName.Length;i++)
        {
            if(other.tag==strTagName[i])
            {
                Destroy(other.gameObject);

            }

        }
    }


    void Start()
    {

        NearEnemy = SearchTage(gameObject);//一番近い敵を取得
    }

    void Update()
    {
        if (NearEnemy.gameObject == null)
        {
            NearEnemy = SearchTage(gameObject);//一番近い敵を取得
            if (NearEnemy.gameObject == null)
            {
                Instantiate(Effect, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
                Destroy(gameObject);
            }
        }
       

        transform.LookAt(NearEnemy.transform);//敵のほうを向く
        transform.Translate(Vector3.forward * floSpeed);//敵のほうに向かう
      

    }


    GameObject SearchTage(GameObject nowObj)
    {
        float TmpDistance = 0;           //距離用一時変数
        float Close_Distance = 0;          //最も近いオブジェクトの距離
        GameObject target = null; 

        for(int i = 0;i<EnemyTag.Length;i++)
        {
            foreach (GameObject obs in GameObject.FindGameObjectsWithTag(EnemyTag[i]))
            {

                TmpDistance = Vector3.Distance(obs.transform.position, nowObj.transform.position);

                if (Close_Distance == 0 || Close_Distance > TmpDistance)//比べて近いのがあったら座標をいれる
                {
                    Close_Distance = TmpDistance;//近い敵の距離
                    target = obs; //ターゲット情報を入れる
                }

            }
        }
        
        return target; 

    }
}
