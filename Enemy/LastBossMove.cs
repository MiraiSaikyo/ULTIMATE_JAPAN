using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastBossMove : MonoBehaviour {

    Rigidbody Rigidbody_;
    public GameObject Light;
    public GameObject Enemys;
    private float ArrivalTime = 10f;
    private float NowTime;
    private float RotateSpeed = 0f;
    private Vector3 startPosition;
    public Vector3 TargetPosition;

    bool isCreate;

    // Use this for initialization
    void Start () {
        Rigidbody_ = GetComponent<Rigidbody>();
        Init();
    }
	
	// Update is called once per frame
	void Update () {
        Move();

        if(transform.position==TargetPosition&& isCreate==false)
        {
            GetComponent<AudioSource>().Stop();
            Light.SetActive(true);
            Invoke("EnemysCreate", 1f);
            isCreate = true;
        }

    }


    void EnemysCreate()
    {
        Enemys.SetActive(true);
        LightOFF();
    }

    void LightOFF()
    {
        Light.SetActive(false);
    }


    void Init()//初期化用
    {
        NowTime = Time.timeSinceLevelLoad;//タイムをReset
        startPosition = transform.position;//最初の位置を保存
    }

    void Move()
    {
        Rigidbody_.rotation = Quaternion.Slerp(Rigidbody_.rotation, Quaternion.LookRotation(TargetPosition - Rigidbody_.position), RotateSpeed);//ターゲットの方向を向く
        var Now = Time.timeSinceLevelLoad - NowTime;
        var rate = Now / ArrivalTime;
        transform.position = Vector3.Lerp(startPosition, TargetPosition, rate);
    }
}
