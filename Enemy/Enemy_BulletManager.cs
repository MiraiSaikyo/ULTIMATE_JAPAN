using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///　敵の弾のダメージを管理する
/// </summary>
public class Enemy_BulletManager : MonoBehaviour {

    /// <summary>
    ///  銃の威力
    /// </summary>
    public float Power;

    /// <summary>
    ///  敵の銃から弾にSendMessageで受け取る
    /// </summary>
    void BulletPower(float Damage)
    {
        Power = Damage;
    }
}
