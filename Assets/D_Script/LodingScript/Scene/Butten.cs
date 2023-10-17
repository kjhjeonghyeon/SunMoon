using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butten : MonoBehaviour
{
   public int goScene = 0;
    SceneManage sceneManage = new SceneManage();
    void Start()
    {
        SceneManage.Next(goScene);
        sceneManage.LoadScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
