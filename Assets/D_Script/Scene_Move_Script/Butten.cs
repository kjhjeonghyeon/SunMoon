using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Butten : MonoBehaviour
{
   public int goScene = 0;
    SceneManager_My sceneManager_My;
    void Start()
    {
        sceneManager_My=new SceneManager_My();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  public void nextSceneButten()
    {

        SceneManager_My.Next(goScene);


        sceneManager_My.LoadScene();

    }
}
