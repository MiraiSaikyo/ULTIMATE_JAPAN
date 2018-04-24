using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;


/// <summary>
/// 獲得ポイントの管理
/// </summary>
public class Points : MonoBehaviour
{

    /// <summary>
    /// 現在、獲得したポイント
    /// </summary>
    public int Earned_Points;
    /// <summary>
    /// ランキングデータ
    /// </summary>
    public int[] Ranking = new int[100];
    /// <summary>
    /// 順位
    /// </summary>
    public int Rank;
    /// <summary>
    /// 現在、獲得したポイント
    /// </summary>
    Transform CenterEye;
    /// <summary>
    /// 現在、獲得したポイント
    /// </summary>
    Player_Maneger Player_Maneger_;


    private TextAsset CSVFile;
    public List<string[]> SettingList = new List<string[]>();
    StreamWriter StreamWriter_;



    void Awake()
    {
        FastSettingLoad();
        Setting();
    }


    /// <summary>
    /// 変数に情報を入れる処理
    /// </summary>
    void Start()
    {

        RankingLoad();
        CenterEye = GameObject.Find("CenterEyeAnchor").transform;
        Player_Maneger_ = CenterEye.GetComponent<Player_Maneger>();
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            RankingDirect();
            RankingSort();
            RankingSearch();
        }
      
    }



    /// <summary>
    /// ランキングデータのSave
    /// </summary>
    void RankingSave()
    {
      
            PlayerPrefsX.SetIntArray("Ranking", Ranking);
        
    }


    /// <summary>
    /// ランキングデータのロード
    /// </summary>
    void RankingLoad()
    {
        Ranking = PlayerPrefsX.GetIntArray("Ranking");
    }


    /// <summary>
    /// ランキングデータの設定
    /// </summary>
    void RankingReset()
    {
        for (int i = 0; i < Ranking.Length; i++)
        {
            Ranking[i] = 100 - i;
        }
        RankingSave();
    }

    /// <summary>
    /// ランキングデータの降順ソート
    /// </summary>
    void RankingSort()
    {
        Array.Sort(Ranking);
        Array.Reverse(Ranking);
    }


    /// <summary>
    /// 自分のスコアが何位か検索する
    /// </summary>
    void RankingSearch()
    {
       Rank = Array.IndexOf(Ranking, Earned_Points);
    }

    void RankingDirect()
    {
        if (Ranking[99] < Earned_Points)
        {
            Ranking[99] = Earned_Points;
        }
    }

    void FastSettingLoad()
    {
        CSVFile = Resources.Load("Setting") as TextAsset; /* Resouces/CSV下のCSV読み込み */
        StringReader reader = new StringReader(CSVFile.text);

        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            SettingList.Add(line.Split(',')); // リストに入れる
        }
    }

    void Setting()
    {
        if (int.Parse(SettingList[0][0]) == 0)
        {
            RankingReset();
        }


        StreamWriter_ = new StreamWriter(Application.dataPath + "/Resources/Setting.csv", false);
        StreamWriter_.WriteLine("1");
        StreamWriter_.Flush();
        StreamWriter_.Close();
    }

}
