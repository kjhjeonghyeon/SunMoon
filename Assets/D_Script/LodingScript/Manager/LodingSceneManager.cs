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


    //�޼ҵ� �����ε���->���������� ������//static���� �ϳ��� ���� ���������� �Ѿ������,��üȭ �ʿ����/public->��𼭵� ȣ�Ⱑ��
    //public void LoadScene(int nextName)
    //{
    //    nextScene = nextName;


    //    Debug.Log(" ����?");

    //}
    IEnumerator LoadScene2()
    {
        
        //�������� �纸�ؾ� �ڸ�ƾ����=�Լ������� ����,����ȭ����ȭ���� ����
        yield return null;
        AsyncOperation nextSceneLoad = SceneManager.LoadSceneAsync(nextScene);
        nextSceneLoad.allowSceneActivation = false;

        while (!nextSceneLoad.isDone)
        {

            //���������� ����(������ �ʿ䰡������) ���������� �������� �����͸� �� ��Ƹ��� �ٷλ�����ϱ��
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
