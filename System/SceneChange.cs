using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;  // これを追加

public class SceneChange : MonoBehaviour
{

    public string Scene;

    // Use this for initialization

    void Start()
    {

    }

    // Update is called once per frame

    void Update()
    {

       if(Input.GetKeyDown(KeyCode.Space))
        {
            // Aキーを押すとシーン遷移する
            SceneManager.LoadScene(Scene);
        }


    }

}
