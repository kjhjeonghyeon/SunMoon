using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
//��ư���� �̵��� ���� �����ִ� ���̾��Ű�� �����ֱ�
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
