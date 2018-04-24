using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentShipCreate : Enemy_Create {


    private GameObject Ship;
    public int MAXEnemyValue;
    GameObject[] tagObjects;

    void Start () {

    }
	
	void Update () {
        Check("EnemyMain");
        CreateEnemy();
        CreateShip();
    }

    void CreateShip()
    {
        if(isCreate==true&&transform.position.z>0f)
        {
            if (tagObjects.Length < MAXEnemyValue)
            {
                Ship = Instantiate(Enemy[EnemyRand], CreatePosition[CreateRand].position, Quaternion.Euler(0, 180, 0));
                Ship.GetComponent<Rigidbody>().velocity = CreatePosition[CreateRand].transform.forward * 50;
                isCreate = false;
            }
        }
        if(transform.position.z<-300f)
        {
            Destroy(gameObject);
        }

      
    }
    void Check(string tagname)
    {
        tagObjects = GameObject.FindGameObjectsWithTag(tagname);
        //Debug.Log(tagObjects.Length); //tagObjects.Lengthはオブジェクトの数

    }
}
