using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexSetting : MonoBehaviour
{
    //��obj����Ʈ�� �޴� ����Ʈ
    List<List<GameObject>> allList = new List<List<GameObject>>();

    //��obj����Ʈ
    List<GameObject> Hex_A = new List<GameObject>();
    List<GameObject> Hex_B = new List<GameObject>();

    float[] hexPosition = new float[12]; // ũ�Ⱑ 12�� �迭�� ���� �� �ʱ�ȭ


    private void Awake()
    {
        //obj�������°Թ���
        Hex_A.AddRange(GameObject.FindGameObjectsWithTag("Hex_A"));
        Hex_B.AddRange(GameObject.FindGameObjectsWithTag("Hex_B"));

        allList.Add(Hex_A);
        allList.Add(Hex_B);

        List<GameObject> selectedList = allList[0]; // �� ��� Hex_A�� �����մϴ�.
        GameObject k = selectedList[0]; // Hex_A ����Ʈ�� ù ��° ������Ʈ�� �����մϴ�.

    }


    void Start()
    {

    }


    void Update()
    {



      
        //�� 1���� 12������ ������ ����Ǵ� ���� ���;���
        //0/30/60/90/120/150/180/210/240/270/300/330
        for (int t = 0; t < 12; t++)
        {
                    hexPosition[t] = 30f*t;
         

        }






    }
}