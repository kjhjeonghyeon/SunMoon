using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
//버튼으로 이동할 씬을 정해주니 하이어라키에 적어주기
public class Butten : SceneManager_My
{
    

   public int goScene = 0;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  public void nextSceneButten()
    {

        SceneManager_My.Next(goScene);


        LoadScene();

    }
}
