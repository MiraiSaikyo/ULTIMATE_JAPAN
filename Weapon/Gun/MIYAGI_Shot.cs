using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 宮城県の武器の処理
/// </summary>
public class MIYAGI_Shot : MonoBehaviour
{

    /// <summary>
    /// 生成するフラグ
    /// </summary>
    private bool isCreate;
    /// <summary>
    /// 右か左か
    /// </summary>
    private int Left_Right;
    /// <summary>
    /// 現在の時間
    /// </summary>
    private float NowTime;
    /// <summary>
    /// 最大まで力をためる時間
    /// </summary>
    public float Time_Charge;
    /// <summary>
    /// 弾のprefab
    /// </summary>
    public GameObject Bullet;
    /// <summary>
    /// ノズルの位置を変数に情報を入れる
    /// </summary>
    public Transform Nozzle;
    /// <summary>
    /// 魔力（弾）のObjectの情報を入れておく変数
    /// </summary>
    private GameObject Power;
    /// <summary>
    /// Objectのtag
    /// </summary>
    public string[] strTagName = new string[2];
    /// <summary>
    /// Inputキーの指定
    /// </summary>
    public string[] strTriggerName = new string[2];
    /// <summary>
    /// 最大火力数
    /// </summary>
    public float MAXPower;
    /// <summary>
    /// 現在の火力数
    /// </summary>
    public float NowPower;

    private bool isShot;
    float ReTIme;
    bool isTransformationl;
    public int Ammon;
    /// <summary>
    /// 弾を打つ処理
    /// </summary>
    void Update()
    {

        for (int i = 0; i < strTagName.Length; i++)//ここでどの手で持っているかを判定する
        {
            if (gameObject.tag == strTagName[i])
            {
                Left_Right = i;
            }
        }


        if (gameObject.tag != "Untagged")
        {
            if (Input.GetAxis(strTriggerName[Left_Right]) == 1 && isTransformationl == false)
            {

                isShot = true;
                isTransformationl = true;

            }

            if (Input.GetAxis(strTriggerName[Left_Right]) == 1 && isShot == false && isTransformationl == true && Ammon >0)
            {
                
                if (isCreate == false)
                {
                    Power = Instantiate(Bullet, Nozzle.position, Nozzle.rotation);//生成
                    Ammon--;
                    isCreate = true;
                }
                Power.transform.rotation = Nozzle.rotation;
                Power.transform.position = Nozzle.position;
                Power.transform.localScale = new Vector3(NowTime / 10, NowTime / 10, NowTime / 10);

                if (NowTime <= Time_Charge)
                {
                    NowTime += Time.deltaTime;
                    NowPower = (MAXPower / Time_Charge) * NowTime;
                }
            }
            else if (Input.GetAxis(strTriggerName[Left_Right]) == 0)
            {
                if (isCreate == true)
                {
                    Power.SendMessage("BulletPower", Time_Charge);
                    Power.GetComponent<Rigidbody>().velocity = Nozzle.forward * 30f;
                    Power.GetComponent<TimeDestroy>().enabled = true;
                    Power.GetComponent<Collider>().enabled = true;
                    isCreate = false;
                    isShot = true;
                }
                NowPower = 0f;
                NowTime = 0f;
            }

        }
        else
        {
            if (Power != null)
            {
                Destroy(Power);
            }
        }




        if (isShot == true)
        {
            ReTIme += Time.deltaTime;
            if (ReTIme > 2f)
            {
                isShot = false;
                ReTIme = 0.0f;
            }
        }

    }
}