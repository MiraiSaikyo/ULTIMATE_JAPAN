using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 福岡県のバーナーの処理
/// </summary>
public class Gun_HUKUOKA : MonoBehaviour
{
    /// <summary>
    /// 容量
    /// </summary>
    public float Capacity;
    /// <summary>
    /// 消費量
    /// </summary>
    public float Consumed;
    /// <summary>
    /// 火力（ダメージ量）
    /// </summary>
    public float Damage;
    /// <summary>
    /// タグの名前管理
    /// </summary>
    public string[] strTagName;
    /// <summary>
    /// トリガー名
    /// </summary>
    public string[] strInput;
    /// <summary>
    /// 0と1で右手か左手を決める
    /// </summary>
    private int intLeft_Right;
    /// <summary>
    /// 炎のあたり判定を飛ばす用のPrefabを指定
    /// </summary>
    public GameObject FireCollider;
    /// <summary>
    /// マズルの位置を入れておく変数
    /// </summary>
    public Transform Nozzle;
    /// <summary>
    /// particleを指定する
    /// </summary>
    public GameObject particle;
    /// <summary>
    /// particlesystemを使う
    /// </summary>
    private ParticleSystem Psys;
    /// <summary>
    /// 連続再生しないように制御するフラグ
    /// </summary>
    bool isPlay;
    /// <summary>
    /// 経過時間
    /// </summary>
    private float NowTime;
    /// <summary>
    /// あたり判定を飛ばす間隔の時間
    /// </summary>
    public float CreateTime;

    float Timer;

    /// <summary>
    /// 変数に情報を入れる処理
    /// </summary>
	void Start()
    {
        Psys = particle.GetComponent<ParticleSystem>();
    }


    /// <summary>
    /// Triggerを押したら炎を出す処理
    /// </summary>
    void Update()
    {

        for (int i = 0; i < strTagName.Length; i++)
        {
            if (gameObject.tag == strTagName[i])
            {
                intLeft_Right = i;
            }
        }

        if (!(gameObject.tag == "Untagged"))
        {
            Timer += Time.deltaTime;

            if (Input.GetAxis(strInput[intLeft_Right]) == 1 && Capacity > 0&&Timer>3f)
            {
                NowTime += Time.deltaTime;

                if (isPlay == false)
                {
                    Psys.Play();
                    isPlay = true;
                }

                if (NowTime >= CreateTime)
                {
                    GameObject b = Instantiate(FireCollider, Nozzle.position, Nozzle.rotation);
                    b.GetComponent<Rigidbody>().velocity = Nozzle.forward * 5f;
                    b.SendMessage("BulletPower", Damage);
                    NowTime = 0f;
                }

                Capacity -= Consumed;//容量から消費量を引いていく
            }
            else
            {
                NowTime = 0f;
                isPlay = false;
                Psys.Stop();
            }

        }
        else
        {
            Psys.Stop();
        }
    }
}
