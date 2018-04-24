using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

/// <summary>
/// ゲームの進行を管理している
/// </summary>
public class GameManager : MonoBehaviour
{

    /// <summary>
    /// CSVファイルのデータを入れておく変数
    /// </summary>
    private TextAsset CSVFile;
    /// <summary>
    /// ゲームの情報を入れておくリスト
    /// </summary>
    public List<string[]> GameManagementList = new List<string[]>();
    /// <summary>
    /// 敵が出てくる順番のパスが入った配列
    /// </summary>
    public List<string[]> PathList = new List<string[]>();
    /// <summary>
    /// 何体だすかの情報が入ってます
    /// </summary>
    public List<string[]> NorumakillList = new List<string[]>();
    /// <summary>
    /// どのタイミングでどの敵が出てくるかなどの情報が入ったリスト
    /// </summary>
    public List<string[]> EnemyDataList = new List<string[]>();
    /// <summary>
    /// 何体Shipを敵を出したか
    /// </summary>
    public int intShotCount;
    /// <summary>
    /// 何体ロボットを出したか
    /// </summary>
    public int intEnemyCount;
    /// <summary>
    /// 倒した敵の数
    /// </summary>
    public int KillCount;
    /// <summary>
    /// 現在のWave数
    /// </summary>
    public int Wave;
    /// <summary>
    /// １Wave終わった時に立てるフラグ
    /// </summary>
    public bool isWaveUP;


	public GameObject gameEnd;
    public GameObject WaveAnime;
    public bool isGameEnd;
    public GameObject ParentShip;
    /// <summary>
    /// 初期化　変数に情報を入れている
    /// </summary>

    void Start()
    {
        ManagementLoad();//ゲームの情報のロード

        Wave = 1;
        ManagementLoad();//ゲームの情報のロード
        NorumaKillLoad();//出てくる敵の数のロード
        PathLoad();//出す敵のPathのロード
        EnemyLoad();
        Invoke("WaveSet", 3f);
    }

    void WaveSet()
    {
        WaveAnime.SetActive(true);

    }


    /// <summary>
    /// 関数を呼ぶ
    /// </summary>
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            Invoke("FadeOut", 2f);
            isGameEnd = true;
            WaveAnime.SetActive(false);
        }



        if (int.Parse(GameManagementList[0][1]) < Wave)
        {
            WaveAnime.SetActive(false);
            ParentShip.SetActive(true);
           // Invoke("FadeOut", 2f);
           // isGameEnd = true;
        }

        if (int.Parse(NorumakillList[Wave][1]) == KillCount && isGameEnd == false)
        {
            KillCount = 0;
            intEnemyCount = 0;
            intShotCount = 0;
            Wave++;
            NorumaKillLoad();//出てくる敵の数のロード
            EnemyLoad();
            isWaveUP = true;
            WaveAnime.GetComponent<Animator>().SetBool("Active", true);
            Invoke("WaveAnimatorEnd", 7f);
        }
        else
        {
            isWaveUP = false;
        }

        
    }

    void WaveAnimatorEnd()
    {
        WaveAnime.GetComponent<Animator>().SetBool("Active", false);
    }

    void FadeOut()
    {
		gameEnd.SetActive(true);
    }


    /// <summary>
    /// HP、最大Wave、無敵時間といったゲームの情報のCSVを読み込む
    /// </summary>
    void ManagementLoad()
    {
        CSVFile = Resources.Load("GameInfo") as TextAsset; /* Resouces/CSV下のCSV読み込み */
        StringReader reader = new StringReader(CSVFile.text);

        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            GameManagementList.Add(line.Split(',')); // リストに入れる
        }
    }

    /// <summary>
    /// WaveのPath（アドレス）のロード
    /// </summary>
    void PathLoad()
    {
        CSVFile = Resources.Load("Path") as TextAsset; /* Resouces/CSV下のCSV読み込み */
        StringReader reader = new StringReader(CSVFile.text);

        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            PathList.Add(line.Split(',')); // リストに入れる
        }
    }

    /// <summary>
    /// Waveごとの出てくる敵の数のロード
    /// </summary>
    void NorumaKillLoad()
    {
        CSVFile = Resources.Load("Noruma") as TextAsset; /* Resouces/CSV下のCSV読み込み */
        StringReader reader = new StringReader(CSVFile.text);

        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            NorumakillList.Add(line.Split(',')); // リストに入れる
        }
    }

    /// <summary>
    /// 出てくる敵のデータを読み込む
    /// </summary>
    public void EnemyLoad()
    {
        if (int.Parse(GameManagementList[0][1]) >= Wave)
        {
            EnemyDataList.Clear();
            CSVFile = Resources.Load(PathList[Wave - 1][0]) as TextAsset; /* Resouces/CSV下のCSV読み込み */
            StringReader reader = new StringReader(CSVFile.text);

            while (reader.Peek() > -1)
            {
                string line = reader.ReadLine();
                EnemyDataList.Add(line.Split(',')); // リストに入れる
            }
        }
       
    }

}
