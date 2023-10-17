using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
using static UnityEngine.Rendering.DebugUI;

// ��ó�� ���̸� [�ε���->���۾�]���� ���µ� ���Ŀ��� SceneManage������ [��-> �ε�->��] ������ 
public class LodingSceneManager : MonoBehaviour
{


    // public static RodingSceneManager instance;
    int nextScene = 1;


    GameObject lodingBar;



    private void Awake()
    {

        lodingBar = GameObject.Find("Progress Bar");




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
    IEnumerator LoadScene()
    {
        yield return null;

        //�������� �纸�ؾ� �ڸ�ƾ����=�Լ������� ����,����ȭ����ȭ���� ����
        AsyncOperation nextSceneLoad = SceneManager.LoadSceneAsync(nextScene);
        nextSceneLoad.allowSceneActivation = false;

        //���������� ����(������ �ʿ䰡������) ���������� �������� �����͸� �� ��Ƹ��� �ٷλ�����ϱ��
        float barGage = 0;

        while (!nextSceneLoad.isDone)
        {


            barGage = nextSceneLoad.progress;
           


            if (barGage < 0.8)
            {
              
                   
                lodingBar.GetComponent<Slider>().value = barGage;
                


            }
            else
            {

                

                lodingBar.GetComponent<Slider>().value = 1;
                yield return new WaitForSeconds(3f);
                nextSceneLoad.allowSceneActivation = true;

            }
            yield return null;
        }



    }
}
