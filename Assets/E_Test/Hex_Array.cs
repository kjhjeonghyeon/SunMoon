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
    bool[] selectD = new bool[2];//타입안에서 맞는 방항의 오브젝트를 활성화하는 참거짓함수


    float[] hexPosition = new float[12]; // 크기가 12인 배열을 선언 및 초기화


    int faultFace;//단층 
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
    {//마우스 위치
        array();
        selectD[0] = false;//subfaceD
        selectD[1] = false;//dotD


    }
    // Update is called once per frame
    void Update()
    {// 마우스 방향

        //조건5. 3번 과  4번 모두 true 일때 방향 결정됨


        mousePoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
              Input.mousePosition.y, -Camera.main.transform.position.z));

        mouseDirecter = mousePoint - Vector3.zero;
        mouseDirecter_nomal = (mousePoint - Vector3.zero).normalized;
        mouseSize = Vector3.Magnitude(mouseDirecter); ;
        mouseSizePositive = Mathf.Abs(mouseSize);
        mouseAngle = Quaternion.FromToRotation(mousePoint, Vector3.zero).eulerAngles.y;



        //가까운 각도 판별(방향별 오브젝트선택)->1번.가까운 1개나 아무것도 선택안될수있음/2.또는 범의가 넓어 2개가 선택될수있음-> mach 함수 조절해서 무조건 1번으로
        for (int p = 0; p < 12; p++)
        {
            if (mach(mouseAngle, hexPosition[p]) == true)
            {
                near[p] = true;//방향

                return;

            }
            if (mach(mouseAngle, hexPosition[p]) == false)
            {
                near[p] = false;

            }
        }
       
        //사이거리가 원 범위안이다-> 패턴 끼리 겹치는 부위중 선택가능하게됨
        if (machDistance(mouseSizePositive % subfaceD, 0) > 0.5)
        {

            selectD[0] = true;// 패턴 ab
            selectD[1] = false;
        }
        if (machDistance(mouseSizePositive % dotD, 0) > 0.5)
        {

            selectD[1] = true;//패턴 cd
            selectD[0] = false;


        }





        //단층거리
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
                    //b곱해 겜오브제 설치하면 끝
                    
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
        //겜오브제 설치






        //점과 원의 중심점의 거리가지고 비교하는데 (+원 범위안) 종류 2개(거리)->단층이 선택될수있음 /겹친는거 규별가능
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






        //조건2.4가지 ABCD타입(내가따로정리함)으로 나누기-각도에따라 나눔


        //A타입
        //hexPosition[3];
        //hexPosition[9];
        //B타입
        //hexPosition[1];
        //hexPosition[4];
        //hexPosition[7];
        //hexPosition[10];

        //if (((mouseAngle == hexPosition[3]) || (mouseAngle == hexPosition[9])))
        //{

        //    //조건4.타입을 선택->조건5의 1번 경우 오브제트가 선택됨
        //    //오브젝트생성(고려: 단층)


        //}

        //if (((mouseAngle == hexPosition[1]) || (mouseAngle == hexPosition[4]) || (mouseAngle == hexPosition[7]) || (mouseAngle == hexPosition[10])))
        //{
        //    selectITtyp[1] = true;
        //}





        //}

        //else if (Mathf.Equals(mouseSizePositive, mouseSizePositive % dotD > 0.5))
        //{


        //    selectD[1] = true;

        ////C타입

        //   hexPosition[0];
        //   hexPosition[6];
        ////D타입
        //   hexPosition[2];
        //   hexPosition[5];
        //   hexPosition[8];
        //   hexPosition[11];

        ////C타입
        //if (((mouseAngle == hexPosition[0]) || (mouseAngle == hexPosition[6])))

        //{
        //    selectITtyp[2] = true;
        //}

        //////D타입
        //if (((mouseAngle == hexPosition[2]) || (mouseAngle == hexPosition[5]) || (mouseAngle == hexPosition[8]) || (mouseAngle == hexPosition[11])))
        //{
        //    selectITtyp[3] = true;
        //}














        //원으로 범위가 표현될때 겹치는곳
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









