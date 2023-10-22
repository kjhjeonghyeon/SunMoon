using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HexSetting : MonoBehaviour
{
    ////��obj����Ʈ�� �޴� ����Ʈ
    //List<List<GameObject>> allList = new List<List<GameObject>>();

    ////��obj����Ʈ
    //List<GameObject> Hex_A = new List<GameObject>();
    //List<GameObject> Hex_B = new List<GameObject>();



    float[] hexPosition = new float[12]; // ũ�Ⱑ 12�� �迭�� ���� �� �ʱ�ȭ
    List<float>[] hexGroup = new List<float>[4]; // ũ�Ⱑ 12�� �迭�� ���� �� �ʱ�ȭ

    Vector3 mousePoint;
    float mouseAngle;

 //   public int FindIndex(Predicate<T> match);

    GameObject[] gA = new GameObject[2];  
    GameObject[] gB = new GameObject[4];  
    GameObject[] gC = new GameObject[2];  
    GameObject[] gD = new GameObject[4];  
    private void Awake()
    {
        //    //obj�������°Թ���
        //    Hex_A.AddRange(GameObject.FindGameObjectsWithTag("Hex_A"));
        //    Hex_B.AddRange(GameObject.FindGameObjectsWithTag("Hex_B"));

        //    allList.Add(Hex_A);
        //    allList.Add(Hex_B);

        //    List<GameObject> selectedList = allList[0]; // �� ��� Hex_A�� �����մϴ�.
        //    GameObject k = selectedList[0]; // Hex_A ����Ʈ�� ù ��° ������Ʈ�� �����մϴ�.

    }


    void Start()
    {
        hex_array();
        //ī�޶���ġ->���콺��ġ
       mousePoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, -Camera.main.transform.position.z));


    }


    void Update()
    {


        mouseAngle=Quaternion.FromToRotation(mousePoint, Vector3.zero).eulerAngles.y;


    }
    private void hex_array()
    {

        //0/30/60/90/120/150/180/210/240/270/300/330

        //for (int t = 0; t < 12; t++)
        //{

        //    for (int j = 0; j < 4; j++)
        //    {

        //        if (30f * t == 180 * j + 90)//Atyp
        //        {

        //            hexPosition[t] = 30f * t;
        //            hexGroup[0].Add(hexPosition[t]);

        //        }
        //        else if (30f * t == 90 * j + 30) //Btyp
        //        {

        //            hexPosition[t] = 30f * t;
        //            hexGroup[1].Add(hexPosition[t]);
        //        }
        //        else if (30f * t == 180 * j)//Ctyp
        //        {
        //            hexPosition[t] = 30f * t;

        //            hexGroup[2].Add(hexPosition[t]);
        //        }
        //        else if (30f * t == 90 * j + 60)//DTyp
        //        {
        //            hexPosition[t] = 30f * t;
        //            hexGroup[3].Add(hexPosition[t]);
        //        }
        //    }
        //}

        //�� �迭�� ������ ����

        for (int j = 0; j < 4; j++)
        {
            aTyp_D(j);
            bTyp_D(j);
            cTyp_D(j);
            dTyp_D(j);

        }

    }


    void aTyp()
    {//������� ��� Ȯ���ȼ��ִµ� ���⵵�ؼ�  �밡�� �ϱ����
     // tlqk ����
        //Atyp
        if (mouseAngle == hexGroup[0][0])
        {
           
        }

        if (mouseAngle == hexGroup[0][1])
        {

        }



    }

    void bTyp()
    {
        if (mouseAngle == hexGroup[1][0])
        {

        }

        if (mouseAngle == hexGroup[1][1])
        {

        }

        if (mouseAngle == hexGroup[1][2])
        {

        }

        if (mouseAngle == hexGroup[1][3])
        {

        }

    }

    void cTyp()
    {

        if (mouseAngle == hexGroup[2][0])
        {

        }

        if (mouseAngle == hexGroup[2][1])
        {

        }

    }
    void dTyp()
    {
        if (mouseAngle == hexGroup[3][0])
        {

        }
        if (mouseAngle == hexGroup[3][1])
        {

        }
        if (mouseAngle == hexGroup[3][2])
        {

        }
        if (mouseAngle == hexGroup[3][3])
        {

        }

    }




















    void aTyp_D(int j)
    {

        //Atyp_Dirrecter

        hexPosition[j] = 180 * j + 90;
        hexGroup[0].Add(hexPosition[j]);
    }

    void bTyp_D(int j)
    {
        //Btyp_Dirrecter

        hexPosition[j] = 30f * 90 * j + 30;
        hexGroup[1].Add(hexPosition[j]);
    }

    void cTyp_D(int j)
    {

        //Ctyp_Dirrecter
        hexPosition[j] = 180 * j;

        hexGroup[2].Add(hexPosition[j]);
    }
    void dTyp_D(int j)
    {
        //Dtyp_Dirrecter
        hexPosition[j] = 90 * j + 60;

        hexGroup[3].Add(hexPosition[j]);
    }
}

