using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHaving : MonoBehaviour {


    public GameObject[] Weapon;


    void OnTriggerStay(Collider other)
    {
        
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
      if(transform.childCount == 0)
        {
            int RandWeapon = Random.Range(0,Weapon.Length);
            GameObject obj = Instantiate(Weapon[RandWeapon], transform.position, Quaternion.identity);
            obj.GetComponent<BoxCollider>().isTrigger = false;
            obj.transform.parent = transform;
        }

	}
}
