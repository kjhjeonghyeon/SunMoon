using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexSetting : MonoBehaviour
{
    //겜obj리스트를 받는 리스트
    List<List<GameObject>> allList = new List<List<GameObject>>();

    //겜obj리스트
    List<GameObject> Hex_A = new List<GameObject>();
    List<GameObject> Hex_B = new List<GameObject>();

    float[] hexPosition = new float[12]; // 크기가 12인 배열을 선언 및 초기화


    private void Awake()
    {
        //obj종류에맞게받음
        Hex_A.AddRange(GameObject.FindGameObjectsWithTag("Hex_A"));
        Hex_B.AddRange(GameObject.FindGameObjectsWithTag("Hex_B"));

        allList.Add(Hex_A);
        allList.Add(Hex_B);

        List<GameObject> selectedList = allList[0]; // 이 경우 Hex_A에 접근합니다.
        GameObject k = selectedList[0]; // Hex_A 리스트의 첫 번째 오브젝트에 접근합니다.

    }


    void Start()
    {

    }


    void Update()
    {



      
        //각 1에는 12가지의 각도가 적용되는 식이 나와야함
        //0/30/60/90/120/150/180/210/240/270/300/330
        for (int t = 0; t < 12; t++)
        {
                    hexPosition[t] = 30f*t;
         

        }






    }
}