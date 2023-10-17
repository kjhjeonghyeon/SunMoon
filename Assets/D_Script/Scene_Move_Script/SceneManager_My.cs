using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

    //[¾À->·Îµù->¾À]¿¡¼­ ¿ø·¡ ¾À¿¡¼­ (´ÙÀ½¾ÀÀÌ) ¸î¹ø¤Š¾ÀÀ¸·Î °¥Áö ¾Ë·ÁÁÜ
public class SceneManager_My : MonoBehaviour
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
        
        PlayerPrefs.SetInt("next", next);
        SceneManager.LoadScene(0);
   

        
   
    }
}
