using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Manager : MonoBehaviour
{


    public float EnemyHP = 1f;               //EnemyのHP
    public bool isEnemyDes;             //死亡判定
    public GameObject ragdoll;
    public GameObject bomb;
    public float frontSpeed = 1;             //移動速度
    public float sideSpeed = 1;
    float f_Speed;
    float s_Speed;
    public Transform target;            //移動方向
    public float distance = 1f;         //targetとの距離。大きいほど遠くで移動が止まる
    public float minDistans = 1f;
    public string stateName = "Base Layer.action";            //Animatorにて攻撃時のStateを格納
    public bool isShortAttack = true;          //近接攻撃か否か
    public LayerMask layerMask;
    public LayerMask layerMaskW;



    public GameObject weaponCollider;   //攻撃時のcolliderがついているオブジェクト。ColliderをOn/Offする

    public GameObject bullet;           //撃ち出す弾
    public float bulletSpeed;           //bulletの速度
    public Transform muzzle;            //弾の発射位置

    public float firstTime = 0f;          //初弾の調整用 fireRate+firstTimeをすることで初弾の間隔を調整
    public int magazine = 0;            //一度の攻撃中に撃てる数
    public float fireRate = 0f;           //弾を撃つ間隔
    private int count_M = 0;            //一度の攻撃中に撃った弾数をcount
    private float count_B = 0f;         //TimeCount用

    [SerializeField, Range(0f, 1f)]
    public float spread;
    public int shotPerRound = 1;             //発射弾数

    private bool isHit = false;　　　　　//攻撃を受けた際のFlag
    bool isRange = false;     // targetとの距離
    private bool isAttack = false;      //攻撃を始動させるFlag
    public bool isSideStep = false;

    //isHit用のTime系変数
    private float time_H = 0.7f;        //規定値
    private float count_H = 0f;         //count用
    //isAttack用のTime系変数
    private float time_A = 5f;           //規定値
    private float count_A = 0f;         //count用

    public float time_S = 5f;
    private float count_S = 0f;

    public float time_m =0.1f;
    private float count_m= 0f;

    private bool isMove;

    private Rigidbody rb;
    private Animator anim;
    AnimatorStateInfo anim_;

    private Transform GameScript;
    private GameManager GameManager_;
    private bool isCount;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        GameScript = GameObject.Find("GameScript").transform;
        GameManager_ = GameScript.GetComponent<GameManager>();
        target = GameObject.Find("CenterEyeAnchor").transform;

        f_Speed = 0;
        s_Speed = 0;
    }

    void Update()
    {

        anim_ = anim.GetCurrentAnimatorStateInfo(0);


        Enemy_Attack();

        HitStop();
        Enemy_Des();
        Enemy_Move();
    }

    void Damage(float Damage)
    {
        EnemyHP -= Damage;
    }
    void Enemy_Des()
    {
        if (EnemyHP <= 0)
        {
            if (!isEnemyDes)
            {
                Instantiate(ragdoll, transform.position, transform.rotation);
                Instantiate(bomb, transform.position, transform.rotation);
            }
            isEnemyDes = true;
            Invoke("Destroy", 0.1f);



        }
    }
    void Destroy()
    {
        Destroy(gameObject);
        if (isCount == false)
        {
            GameManager_.KillCount++;
            isCount = true;
        }
    }
    void Enemy_Move()
    {
        count_m += Time.deltaTime;
        if (count_m >= time_m)
        {
            isMove = true;
        }


        if (isMove)
        {
            Vector3 v = rb.velocity;
            if (!isHit && (anim_.nameHash != Animator.StringToHash("Base Layer.hit_01")))
            {
                //前進する
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, distance, layerMask))
                {
                    isRange = true;
                    f_Speed = 0;
                }
                else
                {

                    isRange = false;
                    f_Speed = frontSpeed;
                }

                if (isSideStep && !isAttack && !isRange)
                {
                    count_S += Time.deltaTime;
                    if (count_S >= time_S)
                    {
                        isSideStep = false;
                        count_S = 0;
                    }
                    if (Physics.Raycast(transform.position, transform.forward, out hit, 1, layerMaskW))
                    {
                        isSideStep = false;
                        count_S = 0;
                    }
                }
                else
                {

                    //targetの方向を向く
                    var newRotation = Quaternion.LookRotation(target.transform.position - transform.position).eulerAngles;
                    newRotation.x = 0;
                    newRotation.z = 0;
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(newRotation), 10 * Time.deltaTime);
                }


            }
            else
            {

                f_Speed = 0;
                s_Speed = 0;
                count_A = 0;
            }


            //Debug.Log(transform.position.z - target.position.z);

            v = rb.velocity = (transform.forward * f_Speed) + (transform.right * s_Speed);



            anim.SetFloat("Move", v.magnitude);
        }

    }
    void HitStop()
    {
        if (isHit)
        {
            count_H += Time.deltaTime;
            if (count_H >= time_H)
            {
                isHit = false;
                count_H = 0;

            }
        }
    }
    void Enemy_Attack()
    {
        //一定時間経つと攻撃する

        if (isRange)
        {
            if (isShortAttack)
            {
                count_A += Time.deltaTime;
                if (count_A >= time_A)
                {
                    isAttack = true;
                    count_A = 0f;
                    if (isAttack)
                    {
                        anim.SetTrigger("Attack");
                        count_A = 0f;
                        isAttack = false;
                    }
                }

            }
            else
            {
                if (isAttack)
                {

                    if (anim_.nameHash != Animator.StringToHash(stateName))
                    {
                        isAttack = false;
                        float angle = Random.Range(45, 180f);
                        int symbol = Random.Range(-1, 2);
                        transform.Rotate(new Vector3(0, transform.rotation.y + (angle * symbol), 0));
                        if (angle == 0)
                        {
                            isSideStep = false;
                            count_S = 0;
                        }
                        //var diff = new Vector3(0,  angle, 0);
                        //var newRotation = Quaternion.LookRotation(target.transform.position - transform.position+diff).eulerAngles;

                        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(newRotation), 10 * Time.deltaTime);

                    }
                }
                count_A += Time.deltaTime;
                if (count_A >= time_A)
                {
                    isSideStep = true;
                    isAttack = true;
                    anim.SetTrigger("Attack");
                    count_A = 0f;
                }
            }
        }







        if (isShortAttack)
        {
            //AnimatorのステートをみてColliderをOn/Off
            if (anim_.nameHash == Animator.StringToHash(stateName))
            {
                weaponCollider.gameObject.GetComponent<Collider>().enabled = true;
            }
            else
            {
                weaponCollider.gameObject.GetComponent<Collider>().enabled = false;
            }
        }
        else
        {
            if (anim_.nameHash == Animator.StringToHash(stateName))
            {
                if (count_M < magazine)
                {
                    count_B += Time.deltaTime;
                    if (count_B >= fireRate)
                    {
                        for (int i = 0; i < shotPerRound; i++)
                        {

                            Vector3 diffusionVector;
                            float angle_x = Random.Range(-spread, spread);
                            float angle_y = Random.Range(-spread, spread);
                            diffusionVector = new Vector3(angle_x, angle_y, 0);

                            var b = Instantiate(bullet, muzzle.position, muzzle.rotation) as GameObject;
                            b.GetComponent<Rigidbody>().velocity = (target.transform.position - muzzle.position + diffusionVector).normalized * bulletSpeed;
                        }
                        GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
                        count_B = 0;
                        count_M++;
                    }
                }

            }
            else
            {
                count_B = fireRate + firstTime;
                count_M = 0;
            }
        }
    }
    void OnTriggerEnter(Collider coll)
    {
        //弾に当たるとひるむ
        if (coll.gameObject.tag == "Bullet" || coll.gameObject.tag == "Sword")
        {
            if (weaponCollider != null)
            {

                weaponCollider.gameObject.GetComponent<Collider>().enabled = false;
            }
            rb.velocity = Vector3.zero;
            anim.SetTrigger("Hit");
        }
    }
}