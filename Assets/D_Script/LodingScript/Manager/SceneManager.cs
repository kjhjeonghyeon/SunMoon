using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{

   
    public static int next =1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


   public static void Next(int nextSceneNumber)
    {
        next = nextSceneNumber;
        
    }
    public void LoadScene()
    {
        
        SceneManager.LoadScene(0);
        PlayerPrefs.SetInt("next", next);
        PlayerPrefs.Save();
   
    }
}
