using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


/// <summary>
/// 銃のscriptの大元
/// </summary>
public class Gun : MonoBehaviour
{


    /*
     * 銃の親にこのscriptを
     * bulletには発射する弾のプレハブ
     * muzzluには弾の発射位置のオブジェクト
     * 
     * 
     * 弾の移動速度、拡散はこのスクリプトで設定している
     * 射程やダメージなどもここで実装するので
     * 弾には自身をを消すScriptを後日
     */






    /// <summary>
    /// 弾の間隔
    /// </summary>
    [SerializeField]
    public float FireRate = 0.1f;
    /// <summary>
    /// 拡散度
    /// </summary>
    [SerializeField, Range(0f, 1f)]
    public float Spread = 0;
    /// <summary>
    /// //射程 未実装
    /// </summary>
    [SerializeField]
    public float Range = 0;

    /// <summary>
    /// //ダメージ
    /// </summary>
    [SerializeField]
    public float Damage = 0;

    /// <summary>
    /// 弾の速度
    /// </summary>
    [SerializeField]
    public float BulletSpeed = 100f;


    /// <summary>
    /// 銃の種類
    /// </summary>
    public enum ShotType
    {
        Full,
        Semi,
        Burst　//未実装
    }
    /// <summary>
    /// 銃の種類をいれる変数
    /// </summary>
    [SerializeField]
    public ShotType sType = ShotType.Full;
    /// <summary>
    /// リロードにかかる時間
    /// </summary>
    [SerializeField]
    public float ReloadTime = 1f;

    /// <summary>
    /// 最大装填数
    /// </summary>
    [SerializeField]
    public int ClipSize = 10;

    /// <summary>
    /// 弾の最大所持数
    /// </summary>
    [SerializeField]
    public int AmmoMax = 30;


    /// <summary>
    /// 現在の装填数
    /// </summary>
    [System.NonSerialized]
    public int Ammo;                

    /// <summary>
    /// 現在の弾の所持数
    /// </summary>
    [System.NonSerialized]
    public int AmmoHave;

    /// <summary>
    /// 一発あたりの消費弾数
    /// </summary>
    [SerializeField]
    public int AmmoUsep = 1;             

    /// <summary>
    /// 発射弾数
    /// </summary>
    [SerializeField]
    public int ShotPerRound = 1;

    /// <summary>
    /// 発射するオブジェクト
    /// </summary>
    [SerializeField]
    public GameObject bullet; 

    /// <summary>
    /// Shotのタイム
    /// </summary>
    public float time_S = 0f;

    /// <summary>
    /// Reloadのタイム
    /// </summary>
    private float time_R = 0f; 

    /// <summary>
    /// 弾を打っているかのフラグ
    /// </summary>
    public bool isShot = false;

    /// <summary>
    /// リロードをするかのフラグ
    /// </summary>
    private bool isReload = false;

    /// <summary>
    /// ヒットスキャンにするか
    /// </summary>
    public bool isHitScan;

    /// <summary>
    /// 角度初期化する際にでも
    /// </summary>
    private Quaternion initRotation;

    /// <summary>
    /// 発射位置を指定
    /// </summary>
    [SerializeField]
    public Transform muzzle;

    /// <summary>
    /// Rayの開始位置
    /// </summary>
    public Transform startRay;     

    /// <summary>
    /// layerの距離
    /// </summary>
    public int layer;
    /// <summary>
    /// どのボタンで出すか
    /// </summary>
    public string[] strInput = new string[1];


    /// <summary>
    /// 薬莢
    /// </summary>
    public GameObject Shell;

    /// <summary>
    /// 薬莢の排出口
    /// </summary>
    public Transform ShellOuter;  

    /// <summary>
    /// 薬きょうを出すか
    /// </summary>
    public bool isShell; //

    /// <summary>
    /// 薬きょうを出すときに建てるフラグ
    /// </summary>
    public bool isShellPut = false;

    /// <summary>
    /// 発射エフェクト
    /// </summary>
    public GameObject MuzzleFX;    

    /// <summary>
    /// パーティクルシステムの情報を入れる変数
    /// </summary>                         
    ParticleSystem Psys;

    /// <summary>
    /// 弾の発射音のフラグ
    /// </summary>
    public bool isShotSE;

    public bool isBulletEnd;
    bool isTransformation;


    /// <summary>
    /// 初期化
    /// </summary>
    void Start()
    {
        Init();
        //strInput[0] = "Fire1";
        //startRay = Camera.main.transform;
    }


    /// <summary>
    /// 関数の呼び出し
    /// </summary>
    void Update()
    {
        Reload(Input.GetKeyDown(KeyCode.R));
        ChoiceType(strInput[0]);
    }


    /// <summary>
    /// 変数に情報を入れる処理　初期化
    /// </summary>
    public void Init()
    {
        //Psys = MuzzleFX.GetComponent<ParticleSystem>();
        Ammo = ClipSize;
        AmmoHave = AmmoMax;
      //  initRotation = transform.rotation;
      //  isShotSE = false;
    }

    /// <summary>
    /// どのタイプの銃にするか
    /// </summary>
    public void ChoiceType(string input)
    {
        if (!isReload)
        {
            switch (sType)
            {
                case ShotType.Full:
                    Shot(Input.GetButton(input));
                    break;
                case ShotType.Semi:
                    Shot(Input.GetButtonDown(input));
                    break;
                case ShotType.Burst:
                    break;
            }
        }
    }

    /// <summary>
    ///　ボタンを押したら弾を打つ
    /// </summary>
    public void Shot(bool input)
    {
        if (isShot)
        {
            time_S += Time.deltaTime;
            if (time_S > FireRate)
            {

                isShot = false;
                time_S = 0;
            }

        }

        if (input && !isShot)
        {
            ShotElement();
        }
    }



    /// <summary>
    /// ボタンを押したら　GetAxis
    /// </summary>
    public void OVRShot(string INPUT)
    {
        if (isTransformation == false)
        {
            if(Input.GetAxis(INPUT) == 1)
            {
                isShot = true;
                isTransformation = true;
            }
        }

        if (Input.GetAxis(INPUT) == 1 && !isShot && isTransformation == true)
        {
            ShotElement();
            if (INPUT == "RFingerTrigger")
            {
                GameObject.Find("VR").transform.GetComponent<Vibration>().R_VIBRATION(255);
            }
            else
            {
                GameObject.Find("VR").transform.GetComponent<Vibration>().L_VIBRATION(255);
            }
        }
    }



    /// <summary>
    /// 弾の打つ間隔
    /// </summary>
    public void Recast()
    {
        if (isShot)
        {
            time_S += Time.deltaTime;
            if (time_S > FireRate)
            {
                isShot = false;
                time_S = 0;
            }

        }

    }

    /// <summary>
    /// リロードの処理
    /// </summary>
    public void Reload(bool input)
    {
        if (input)
        {
            if (!(Ammo >= ClipSize))
            {
                isReload = true;
            }
        }
        if (isReload)
        {

            time_R += Time.deltaTime;
            if (time_R >= ReloadTime)
            {
                if (AmmoHave - (ClipSize - Ammo) <= 0)
                {
                    Ammo += (AmmoHave);
                    AmmoHave = 0;
                }
                else
                {
                    AmmoHave -= (ClipSize - Ammo);
                    Ammo += (ClipSize - Ammo);
                }
                isReload = false;
                time_R = 0f;
            }
        }

    }

    /// <summary>
    /// レイキャストでうつ弾の処理
    /// </summary>
    private void ShotElement()
    {
        isShot = true;
        if (Ammo > 0)
        {
            for (int i = 0; i < ShotPerRound; i++)
            {
                Vector3 diffusionVector;
                float angle_x = Random.Range(-Spread, Spread);
                float angle_y = Random.Range(-Spread, Spread);
                diffusionVector = new Vector3(angle_x, angle_y, 0);

                Ray ray = new Ray(startRay.position, startRay.forward + diffusionVector);
                RaycastHit hit;
                if (isHitScan)
                {
                    if (Physics.Raycast(ray, out hit, Range, layer))
                    {
                        if (hit.transform.tag == "Enemy")
                        {
                            hit.collider.SendMessage("Damage", Damage);
                        }
                    }
                    else
                    {

                    }
                }
                else
                {
                    GameObject b = Instantiate(bullet, muzzle.position, muzzle.rotation);
                    if (Physics.Raycast(ray, out hit, Range, layer))
                    {
                        b.GetComponent<Rigidbody>().velocity = (hit.point - b.transform.position).normalized * BulletSpeed;
                        b.SendMessage("BulletPower", Damage);
                    }
                    else
                    {
                        b.GetComponent<Rigidbody>().velocity = (ray.GetPoint(Range) - b.transform.position).normalized * BulletSpeed;
                        b.SendMessage("BulletPower", Damage);

                    }
                }
                //生成と同時に弾に移動速度を与える
                if(MuzzleFX != null)
                {
                    var fx=Instantiate(MuzzleFX, muzzle.position, muzzle.rotation)as GameObject;
                    fx.transform.parent = muzzle;

                }

                if (isShellPut)
                {
                    GameObject s = Instantiate(Shell, ShellOuter.position, ShellOuter.rotation);
                }
                isShell = true;
                isShotSE = true;
                //Debug.DrawRay(ray.origin, ray.direction, Color.red, 0.5f, true);
                //transform.rotation = initRotation;
            }
            Ammo -= AmmoUsep;
        }
        else
        {
            isBulletEnd = true;
        }
    }

    /// <summary>
    /// 残りの残弾
    /// </summary>
    public int GetAmmo()
    {
        return Ammo;
    }

    /// <summary>
    /// 残り持っている残弾数
    /// </summary>
    public int GetAmmoHave()
    {
        return AmmoHave;
    }

  

}
