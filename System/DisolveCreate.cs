﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisolveCreate : MonoBehaviour
{
    public float time = 1f; //フェードの時間を調整できます
    private float threshold = 1f; //フェード用の変数
    public bool isDestroy = false; //これでスクリプトが起動
    public GameObject[] Object; //shaderを使っているObjectを入れる
                  
    

    void Start()
    {
        threshold = 1;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (isDestroy)
        {
            FadeOut();

            if (threshold >= 1f)
            {//透明になったら破棄します
                Destroy(gameObject);
            }
        }
        else
        {
            FadeIn();
        }

    }



    void FadeOut()
    {
        threshold += Time.deltaTime / time;  //数字数えます
        for (int i = 0; i < Object.Length; i++)
        {
            Object[i].GetComponent<Renderer>().material.SetFloat("_Threshold", threshold);// 対応したShaderの数値を変えます
        }
    }
    void FadeIn()
    {


        threshold -= Time.deltaTime / time;  //数字数えます
        for (int i = 0; i < Object.Length; i++)
        {
            Object[i].GetComponent<Renderer>().material.SetFloat("_Threshold", threshold);// 対応したShaderの数値を変えます
        }
        if (threshold <= 0)
        {
            threshold = 0;
        }
    }
}