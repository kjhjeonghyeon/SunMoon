using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class LodingSceneManager : MonoBehaviour
{
   // public static RodingSceneManager instance;
   int nextScene  =0;


    GameObject lodingBar;



    private void Awake()
    {
      
        nextScene = PlayerPrefs.GetInt("next");

    }
    void Start()
    {
        StartCoroutine("LoadScene");
      

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    //public  void SceneRodingActivate()
    //{

    //    if (SceneManager.GetActiveScene().buildIndex == 0)
    //    {
    //        StartCoroutine("LoadScene");
    //    }
    //    else
    //    {
    //        SceneManager.LoadScene(0);
    //    }
    //}


    //메소드 오버로딩함->지역변수로 구별함//static으로 하나의 씬만 다음씬으로 넘어갈수있음,객체화 필요없음/public->어디서든 호출가능
    //public void LoadScene(int nextName)
    //{
    //    nextScene = nextName;


    //    Debug.Log(" 들어옴?");

    //}
    IEnumerator LoadScene2()
    {
        
        //한프레임 양보해야 코르틴시작=함수시작을 방지,최적화동기화에도 좋음
        yield return null;
        AsyncOperation nextSceneLoad = SceneManager.LoadSceneAsync(nextScene);
        nextSceneLoad.allowSceneActivation = false;

        while (!nextSceneLoad.isDone)
        {

            //지역변수로 쓰면(전역일 필요가없을떄) 전역변수로 쓸때보다 데이터를 덜 잡아먹음 바로사라지니까요
            float barGage = nextSceneLoad.progress;

            lodingBar.GetComponent<Slider>().value = barGage;


            if (barGage < 0.9)
            {
                Debug.Log(nextScene);

            }

            else
            {
                yield return new WaitForSeconds(2f);
               
                lodingBar.GetComponent<Slider>().value = 1;
                nextSceneLoad.allowSceneActivation = true;

                yield break;

            }

        }

    }
}
