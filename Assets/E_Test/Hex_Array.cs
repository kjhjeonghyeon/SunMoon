using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hex_Array : MonoBehaviour
{

    Vector3 mousePoint;
    Vector3 mouseDirecter;
    Vector3 mouseDirecter_nomal;
    float mouseSize;
    float mouseAngle;
    float mouseSizePositive;
    float subface = 0.5f;
    float dot = 0.57f;
    float subfaceD = 0.5f * 2;//ab
    float dotD = 0.57f * 3;//cd
    float angle = 0;



    bool[] near = new bool[12];
    bool[] selectD = new bool[2];//Ÿ�Ծȿ��� �´� ������ ������Ʈ�� Ȱ��ȭ�ϴ� �������Լ�


    float[] hexPosition = new float[12]; // ũ�Ⱑ 12�� �迭�� ���� �� �ʱ�ȭ


    int faultFace;//���� 
    int faultDot;


    GameObject gameObject;
    GameObject[] gamobj = new GameObject[12];
    /**/     public GameObject gameObject1;


    bool mach(float a, float b)
    {
        if (Mathf.Abs(b - a) < 10f)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    float machDistance(float a, float b)
    {
        return Mathf.Abs(b - a);
    }
    private void Awake()
    {
        gameObject = GameObject.FindGameObjectWithTag("Hex_A");
    }

    void Start()
    {//���콺 ��ġ
        array();
        selectD[0] = false;//subfaceD
        selectD[1] = false;//dotD


    }
    // Update is called once per frame
    void Update()
    {// ���콺 ����

        //����5. 3�� ��  4�� ��� true �϶� ���� ������


        mousePoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
              Input.mousePosition.y, -Camera.main.transform.position.z));

        mouseDirecter = mousePoint - Vector3.zero;
        mouseDirecter_nomal = (mousePoint - Vector3.zero).normalized;
        mouseSize = Vector3.Magnitude(mouseDirecter); ;
        mouseSizePositive = Mathf.Abs(mouseSize);
        mouseAngle = Quaternion.FromToRotation(mousePoint, Vector3.zero).eulerAngles.y;



        //����� ���� �Ǻ�(���⺰ ������Ʈ����)->1��.����� 1���� �ƹ��͵� ���þȵɼ�����/2.�Ǵ� ���ǰ� �о� 2���� ���õɼ�����-> mach �Լ� �����ؼ� ������ 1������
        for (int p = 0; p < 12; p++)
        {
            if (mach(mouseAngle, hexPosition[p]) == true)
            {
                near[p] = true;//����

                return;

            }
            if (mach(mouseAngle, hexPosition[p]) == false)
            {
                near[p] = false;

            }
        }
       
        //���̰Ÿ��� �� �������̴�-> ���� ���� ��ġ�� ������ ���ð����ϰԵ�
        if (machDistance(mouseSizePositive % subfaceD, 0) > 0.5)
        {

            selectD[0] = true;// ���� ab
            selectD[1] = false;
        }
        if (machDistance(mouseSizePositive % dotD, 0) > 0.5)
        {

            selectD[1] = true;//���� cd
            selectD[0] = false;


        }





        //�����Ÿ�
        for (int p = 0; p < 12; p++)
        {
            float a = mouseSizePositive / subfaceD;
            int b = (int)a;
            float subface1 = 0.5f* b;
            float dot1 = 0.57f* b;
            //a

            gamobj[3] = Instantiate(gameObject1, new Vector3(subface * 2f, 0, dot * 0), Quaternion.identity);
            gamobj[9] = Instantiate(gameObject1, new Vector3(subface * -2f, 0, dot * 0), Quaternion.identity);

            //d
            gamobj[1] = Instantiate(gameObject1, new Vector3(subface * 3f, 0, dot * 1 + subface * 0.5f), Quaternion.identity);
            gamobj[4] = Instantiate(gameObject1, new Vector3(subface * -3f, 0, +dot * 1 + subface * 0.5f), Quaternion.identity);
            gamobj[7] = Instantiate(gameObject1, new Vector3(subface * -3f, 0, -dot * 1 - subface * 0.5f), Quaternion.identity);
            gamobj[10] = Instantiate(gameObject1, new Vector3(subface * 3f, 0, -dot * 1 - subface * 0.5f), Quaternion.identity);
            //b
            gamobj[2] = Instantiate(gameObject1, new Vector3(subface * 1, 0, dot * 1 + subface * 0.5f), Quaternion.identity);
            gamobj[5] = Instantiate(gameObject1, new Vector3(subface * -1, 0, dot * 1 + subface * 0.5f), Quaternion.identity);
            gamobj[8] = Instantiate(gameObject1, new Vector3(subface * -1, 0, -dot * 1 - subface * 0.5f), Quaternion.identity);
            gamobj[11] = Instantiate(gameObject1, new Vector3(subface * 1, 0, -dot * 1 - subface * 0.5f), Quaternion.identity);
            //c
            gamobj[0] = Instantiate(gameObject1, new Vector3(subface * 0, 0, dot * 3), Quaternion.identity);
            gamobj[6] = Instantiate(gameObject1, new Vector3(subface * 0, 0, -dot * 3), Quaternion.identity);

            if (near[p])
            {
                if (selectD[0])
                {
                    //b���� �׿����� ��ġ�ϸ� ��
                    
                    if(p==3)

                  Instantiate  (gamobj[3]  );
                    else if(p==9)
                  Instantiate  (gamobj[9]  );
                    else if (p == 0)
                        Instantiate  (gamobj[0]  );
                    else if (p == 6)
                        Instantiate (gamobj[6]);
                               



                }
                else if (selectD[1])
                {
                    //d
                    if (p == 1)
                        Instantiate  (gamobj[1]  );
                    else if (p == 4)
                        Instantiate  (gamobj[4]  );
                    else if (p == 7)
                        Instantiate  (gamobj[7]  );
                    else if (p == 10)
                        Instantiate(gamobj[10]);
                    //b       
                    else if (p == 2)
                        Instantiate  (gamobj[2]  );
                    else if (p == 5)
                        Instantiate  (gamobj[5]  );
                    else if (p == 8)
                        Instantiate  (gamobj[8]  );
                    else if (p == 11)
                        Instantiate(gamobj[11]);

                }



            }
        }
        ////a
        //gamobj[3] = Instantiate(gameObject1, new Vector3(subface * 2f, 0, dot * 0), Quaternion.identity);
        //gamobj[9] = Instantiate(gameObject1, new Vector3(subface * -2f, 0, dot * 0), Quaternion.identity);

        ////d
        //gamobj[1] = Instantiate(gameObject1, new Vector3(subface * 3f, 0, dot * 1 + subface * 0.5f), Quaternion.identity);
        //gamobj[4] = Instantiate(gameObject1, new Vector3(subface * -3f, 0, +dot * 1 + subface * 0.5f), Quaternion.identity);
        //gamobj[7] = Instantiate(gameObject1, new Vector3(subface * -3f, 0, -dot * 1 - subface * 0.5f), Quaternion.identity);
        //gamobj[10] = Instantiate(gameObject1, new Vector3(subface * 3f, 0, -dot * 1 - subface * 0.5f), Quaternion.identity);
        ////b
        //gamobj[2] = Instantiate(gameObject1, new Vector3(subface * 1, 0, dot * 1 + subface * 0.5f), Quaternion.identity);
        //gamobj[5] = Instantiate(gameObject1, new Vector3(subface * -1, 0, dot * 1 + subface * 0.5f), Quaternion.identity);
        //gamobj[8] = Instantiate(gameObject1, new Vector3(subface * -1, 0, -dot * 1 - subface * 0.5f), Quaternion.identity);
        //gamobj[11] = Instantiate(gameObject1, new Vector3(subface * 1, 0, -dot * 1 - subface * 0.5f), Quaternion.identity);
        ////c
        //gamobj[0] = Instantiate(gameObject1, new Vector3(subface * 0, 0, dot * 3), Quaternion.identity);
        //gamobj[6] = Instantiate(gameObject1, new Vector3(subface * 0, 0, -dot * 3), Quaternion.identity);










        //float subfaceD = 0.5f * 2;//ab
        //float dotD = 0.57f * 3;//cd
        //float subface = 0.5f;
        //float dot = 0.57f;
        //�׿����� ��ġ






        //���� ���� �߽����� �Ÿ������� ���ϴµ� (+�� ������) ���� 2��(�Ÿ�)->������ ���õɼ����� /��ģ�°� �Ժ�����
        //if (Mathf.Equals(mouseSizePositive, mouseSizePositive % subfaceD > 0.5))
        //{

        //    if (machDistance(mouseSizePositive % subfaceD, 0) > 0.5)
        //    {

        //        selectD[0] = true;

        //    }
        //    faultFace = (int)sF;
        //}

        //else if (Mathf.Equals(mouseSizePositive, mouseSizePositive % dotD > 0.5))
        //{

        //    faultDot = (int)sD;
        //    selectD[1] = true;
        //}






        //����2.4���� ABCDŸ��(��������������)���� ������-���������� ����


        //AŸ��
        //hexPosition[3];
        //hexPosition[9];
        //BŸ��
        //hexPosition[1];
        //hexPosition[4];
        //hexPosition[7];
        //hexPosition[10];

        //if (((mouseAngle == hexPosition[3]) || (mouseAngle == hexPosition[9])))
        //{

        //    //����4.Ÿ���� ����->����5�� 1�� ��� ������Ʈ�� ���õ�
        //    //������Ʈ����(���: ����)


        //}

        //if (((mouseAngle == hexPosition[1]) || (mouseAngle == hexPosition[4]) || (mouseAngle == hexPosition[7]) || (mouseAngle == hexPosition[10])))
        //{
        //    selectITtyp[1] = true;
        //}





        //}

        //else if (Mathf.Equals(mouseSizePositive, mouseSizePositive % dotD > 0.5))
        //{


        //    selectD[1] = true;

        ////CŸ��

        //   hexPosition[0];
        //   hexPosition[6];
        ////DŸ��
        //   hexPosition[2];
        //   hexPosition[5];
        //   hexPosition[8];
        //   hexPosition[11];

        ////CŸ��
        //if (((mouseAngle == hexPosition[0]) || (mouseAngle == hexPosition[6])))

        //{
        //    selectITtyp[2] = true;
        //}

        //////DŸ��
        //if (((mouseAngle == hexPosition[2]) || (mouseAngle == hexPosition[5]) || (mouseAngle == hexPosition[8]) || (mouseAngle == hexPosition[11])))
        //{
        //    selectITtyp[3] = true;
        //}














        //������ ������ ǥ���ɶ� ��ġ�°�
        if (Mathf.Equals(mouseSizePositive, mouseSizePositive % subfaceD < 0.5 && mouseSizePositive % subfaceD > 0.57))
        {

        }
        else if (Mathf.Equals(mouseSizePositive, mouseSizePositive % dotD < 0.5 && mouseSizePositive % dotD > 0.57))
        {
        }


    }

    private void array()
    {




        //   0 / 30 / 60 / 90 / 120 / 150 / 180 / 210 / 240 / 270 / 300 / 330

        for (int t = 0; t < 12; t++)
        {

            for (int j = 0; j < 4; j++)
            {

                if (30f * t == 180 * j + 90)//Atyp
                {


                    hexPosition[t] = 30f * t;
                    near[t] = false;


                }
                else if (30f * t == 90 * j + 30) //Btyp
                {

                    hexPosition[t] = 30f * t;
                    near[t] = false;

                }
                else if (30f * t == 180 * j)//Ctyp
                {
                    hexPosition[t] = 30f * t;
                    near[t] = false;


                }
                else if (30f * t == 90 * j + 60)//DTyp
                {
                    hexPosition[t] = 30f * t;
                    near[t] = false;

                }
            }

        }
    }
}









