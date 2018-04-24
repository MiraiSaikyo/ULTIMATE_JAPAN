using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastEnemy_Manager : MonoBehaviour {

 
    public float frontSpeed = 1;             //移動速度

    float f_Speed;

    public float distance = 1f;

    public Transform target;            //移動方向  
    public LayerMask layerMask;

    private bool isAttack = false;      //攻撃を始動させるFlag
    
    //isAttack用のTime系変数
    private float time_A = 5f;           //規定値
    private float count_A = 0f;         //count用

    public float time_M = 2f;
    private float count_M = 0f;

    private Rigidbody rb;
    private Animator anim;
    public bool isMove = false;

    public bool isAttackMode=false;

   // Player_Maneger player;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
 
        target = GameObject.Find("CenterEyeAnchor").transform;
       // player = GameObject.Find("CenterEyeAnchor").GetComponent<Player_Maneger>();
    }

    void Update()
    {
        if (isAttack)
        {
            Enemy_Attack();
        }

        if (!isAttackMode)
        {
            Enemy_Move();
        }
    }

    void Enemy_Move()
    {
        count_M += Time.deltaTime;
        if (count_M >= time_M)
        {
            isMove = true;
        }


        if (isMove)
        {
            Vector3 v = rb.velocity;
            //前進する
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, distance, layerMask))
            {
                f_Speed = 0;
                isAttack = true;
                isAttackMode = true;
            }

            else
            {
                f_Speed = frontSpeed;
            }
            //targetの方向を向く
            //var newRotation = Quaternion.LookRotation(target.transform.position - transform.position).eulerAngles;
            //newRotation.x = 0;
            //newRotation.z = 0;
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(newRotation), 10 * Time.deltaTime);

            //Debug.Log(transform.position.z - target.position.z);
            v = rb.velocity = (transform.forward * f_Speed);
            anim.SetFloat("Move", v.magnitude);
        }
    }
    void Enemy_Attack()
    {
        //一定時間経つと攻撃する
        count_A += Time.deltaTime;
        if (count_A >= time_A)
        {
            Quaternion r = new Quaternion(0, 150, 0,30);
            transform.rotation = Quaternion.Lerp(transform.rotation, r, 5);
            anim.SetTrigger("Attack");
            count_A = 0;
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        //弾に当たるとひるむ
        if (coll.gameObject.tag == "Bullet" || coll.gameObject.tag == "Sword")
        {
           //ひるまない
        }
    }
    void OnTriggerStay(Collider coll)
    {
        //if(coll.tag=="Target")
        //{
        //    player.hp = 0;
        //}
    }
    
}
