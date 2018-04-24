using System.Collections;
using System.Collections.Generic;
using UnityEngine;




/// <summary>
/// Objectを持つための処理
/// </summary>
public class Grab : MonoBehaviour {

    /// <summary>
    /// 回転の情報を入れる変数
    /// </summary>
    private Quaternion lastRootation, currentRoation;
    /// <summary>
    /// 持った物のObjectの情報を入れる変数
    /// </summary>
    private GameObject grabbedObject;
    /// <summary>
    /// 握っているかのフラグ
    /// </summary>
    public bool grabbing;
    /// <summary>
    /// LayerMaskの情報を入れる変数
    /// </summary>
    public LayerMask grabMask;
    /// <summary>
    /// layerの距離
    /// </summary>
    public float grabRadius;
    /// <summary>
    /// どの手で持つか
    /// </summary>
    public OVRInput.Controller controller;
    /// <summary>
    /// どのボタンで持つか
    /// </summary>
    public string buttonName;
    /// <summary>
    /// 持った時のTagを指定
    /// </summary>
    public string having_TagName;



  



    /// <summary>
    /// 初期化
    /// </summary>
    void Start()
    {
        grabbing = false;
    }



    /// <summary>
    /// 握っているとき
    /// </summary>
    void GrabObject()
    {

        grabbing = true;
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(transform.position, grabRadius, transform.forward, 0f, grabMask);
        if(hits.Length>0)
        {
            int closestHit = 0;

            for(int i = 0;i<hits.Length;i++)
            {
                if (hits[i].distance < hits[closestHit].distance) closestHit = i;
            }

            grabbedObject = hits[closestHit].transform.gameObject;
            grabbedObject.layer = 0;//レイヤーをデフォルトにする
            grabbedObject.GetComponent<Rigidbody>().isKinematic = true;                                             //掴んだ瞬間Rigidbodyを消す
            grabbedObject.transform.position = transform.position;                                                  //掴んだオブジェクトに手の座標を入れて動かす
            grabbedObject.transform.parent = transform;                                                             //親離れ　自立する
            grabbedObject.transform.rotation = transform.rotation;
            grabbedObject.tag = having_TagName;//タグの名前変更

            
        }

    }



    /// <summary>
    /// 握っていないとき
    /// </summary>
    void DropObject()
    {
        grabbing = false;
        if(grabbedObject != null)
        {
            grabbedObject.transform.parent = null;
            grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
            grabbedObject.GetComponent<Rigidbody>().velocity = OVRInput.GetLocalControllerVelocity(controller);
            grabbedObject.GetComponent<Rigidbody>().angularVelocity = GetAngularVelocity();
            grabbedObject.layer = 8;//レイヤーをデフォルトにする
            grabbedObject.tag = "Untagged";
            grabbedObject = null;
        }
    }

    /// <summary>
    /// Objectの回転
    /// </summary>

    Vector3 GetAngularVelocity()
    {
        Quaternion deltaRotation = currentRoation * Quaternion.Inverse(lastRootation);
        return new Vector3(Mathf.DeltaAngle(0, deltaRotation.eulerAngles.x), Mathf.DeltaAngle(0, deltaRotation.eulerAngles.y), Mathf.DeltaAngle(0, deltaRotation.eulerAngles.z));
    }



    /// <summary>
    /// 持つオブジェクトの処理
    /// </summary>
    void Update () {
        //Debug.DrawRay(transform.position, transform.forward,Color.red);
        if (grabbedObject != null)
        {
            lastRootation = currentRoation;
            currentRoation = grabbedObject.transform.rotation;
        }


        if (!grabbing  && Input.GetAxis(buttonName) == 1)//何も持っていなかったら
        {
                GrabObject();//持っていたら
            
        }
        if (grabbing && Input.GetAxis(buttonName) < 1)//何か持っていたら
        {
            DropObject();//離したら
        }


  


    }
}
