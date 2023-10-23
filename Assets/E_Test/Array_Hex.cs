
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Array_Hex : MonoBehaviour
{
    float[] Direction = new float[12];
    float[] Direction_boundery = new float[12];
    float Direction_patten = 777;// 각도 예외까지 합친 숫자 7

    float subface = 0.5f;
    float dot = 0.58f;//삼각형계산기로 다시 해줌


    Vector3 mousePoint;
    Vector3 mouseDirecter;
    float mouseSize;

    public GameObject centeObj;
    public Transform parentobj;
    public GameObject mouse;
    public GameObject obj;
    Vector3 centerposition;


    //63.43f//26.57f

    bool mach(float a, float b)
    {
        if (Mathf.Abs(b - a) < 25)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    //bool machV(Vector3 a, Vector3 b)
    //{


    //    if (Mathf.Abs(Vector3.Magnitude(centerposition - a) - Vector3.Magnitude(centerposition - b)) < 0.5f)
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }

    //}


    float machDistance(float a, float b)
    {
        return Mathf.Abs(b - a);
    }


    void Start()
    {
        centerposition = Vector3.zero;
        parentobj = Instantiate(parentobj);
        mouse = Instantiate(mouse, parentobj);
        centeObj = Instantiate(centeObj, parentobj);
   
    //centeObj = Instantiate(centeObj);

    //Direction[3] = 90;
    //Direction[9] = 270;

    ////d
    //Direction[1] = 30;
    //Direction[4] = 120;
    //Direction[7] = 210;
    //Direction[10] = 300;
    ////b
    //Direction[2] = 60;
    //Direction[5] = 150;
    //Direction[8] = 240;
    //Direction[11] = 330;
    ////c
    //Direction[0] = 0;
    //Direction[6] = 180;

    //경계선
    //Direction_boundery[0] = 40.76f;
    //Direction_boundery[3] = 180 + 40.76f;
    //Direction_boundery[1] = 90;
    //Direction_boundery[2] = 180 - 40.76f;
    //Direction_boundery[4] = 270;
    //Direction_boundery[5] = 360 - 49.76f;

    //63.43f//26.57f
    Direction_boundery[0] = 0;
        Direction_boundery[3] = 180;
        Direction_boundery[1] = 90 - 26.57f;
        Direction_boundery[2] = 90 + 26.57f;
        Direction_boundery[4] = 270 - 26.57f;
        Direction_boundery[5] = 270 + 26.57f;




        //for (int a = 0; a < 12; a++)
        //{
        //    for (int p = 0; p < 12; p++)
        //    {
        //        if (mach(Direction[a], Direction[p]))
        //        {
        //            for (int t = 0; t < 7; t++)
        //            {
        //                //각도에따른 넘버가 부여됨-> 넘버가 호출될떄 실행되는 함수 만들기
        //                Direction_patten[a] = machnumder(Direction[a], Direction[p]);
        //            }
        //        }
        //    }
        //}

        //-> 임으로 부여해야함



        //a
        //b





    }


    void Update()
    {
        //마우스위치 에바 사용자이치 생성할꺼 고안하기
        mousePoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
              Input.mousePosition.y, -Camera.main.transform.position.z));
        Vector3 mousePointxz = new Vector3(mousePoint.x, 0, mousePoint.z);
        mouseDirecter = new Vector3(mousePointxz.x, 0, mousePointxz.z) - centerposition;
        Vector3 mouseDirecter_O = new Vector3(mousePointxz.x, 0, mousePointxz.z) - Vector3.zero;
        //  Vector3 mouseDirecterLocal = new Vector3(mousePointxz.x, 0, mousePointxz.z) - centeObj.transform.position;
        mouseSize = Vector3.Magnitude(mouseDirecter_O);
        float mouseSize_local = Vector3.Magnitude(mouseDirecter);


        //     mouseDirecter = (new Vector3(mousePoint.x, 0, mousePoint.z) - centeObj.transform.position).normalized;
        //Vector3 mouseDirecterLocal = new Vector3(mousePoint.x, 0, mousePoint.z) - centeObj.transform.position;
        //mouseSize = Vector3.Magnitude(mouseDirecterLocal);

        float anglet_opposite = Quaternion.FromToRotation(new Vector3(1, 0, 0), mouseDirecter_O - centerposition).eulerAngles.y;
        float angle = 360 - anglet_opposite;
        // float localAngle = angle;
        Debug.Log(mousePoint);

        mouse.transform.position = mousePointxz;


        //// 임으로 번호 1개당 위치 한개가 매칭// 임의 번호와 배열번호가 같아지면 함수실행
        //if (Direction_patten== 0)
        //{
        //    GameObjectPosition[1] = new Vector3(subface * 1, 0, dot * 1 + subface * 0.5f);

        //}
        //else if (Direction_patten== 1)
        //{

        //    GameObjectPosition[0] = new Vector3(subface * 2f, 0, dot * 0);
        //}
        //else if (Direction_patten== 2)
        //{

        //    GameObjectPosition[2] = new Vector3(subface * -1, 0, dot * 1 + subface * 0.5f);
        //}
        //else if (Direction_patten == 3)
        //{
        //    GameObjectPosition[4] = new Vector3(subface * -1, 0, -dot * 1 - subface * 0.5f);
        //}
        //else if (Direction_patten== 4)
        //{
        //    GameObjectPosition[3] = new Vector3(subface * -2f, 0, dot * 0);

        //}
        //else if (Direction_patten== 5)
        //{
        //    GameObjectPosition[5] = new Vector3(subface * 1, 0, -dot * 1 - subface * 0.5f);

        //}
        ////a
        //gamobj[0] = Instantiate(gameObject1, new Vector3(subface * 2f, 0, dot * 0), Quaternion.identity);
        //gamobj[3] = Instantiate(gameObject1, new Vector3(subface * -2f, 0, dot * 0), Quaternion.identity);


        ////b
        //gamobj[1] = Instantiate(gameObject1, new Vector3(subface * 1, 0, dot * 1 + subface * 0.5f), Quaternion.identity);
        //gamobj[2] = Instantiate(gameObject1, new Vector3(subface * -1, 0, dot * 1 + subface * 0.5f), Quaternion.identity);
        //gamobj[4] = Instantiate(gameObject1, new Vector3(subface * -1, 0, -dot * 1 - subface * 0.5f), Quaternion.identity);
        //gamobj[5] = Instantiate(gameObject1, new Vector3(subface * 1, 0, -dot * 1 - subface * 0.5f), Quaternion.identity);

        //센터 옮기는 함수
        float n = (int)mouseSize_local;

        //  centeObj.transform.position= centerposition;
        // Debug.Log(n);
        for (int p = 0; p < 6; p++)
        {



            if (mach(angle, Direction_boundery[p]))
            {
                if (p == 0)
                {
                    centeObj.transform.position = centerposition;
                    centeObj.transform.position += n * new Vector3(subface * 2f, 0, dot * 0);


                }


                else if (p == 3)
                {
                    centeObj.transform.position = centerposition;
                    centeObj.transform.position += n * new Vector3(subface * -2f, 0, dot * 0);



                }

                else if (p == 1)
                {
                    centeObj.transform.position = centerposition;
                    centeObj.transform.position += n * new Vector3(subface * 1, 0, dot * 1 + subface * 0.5f);



                }


                else if (p == 2)
                {

                    centeObj.transform.position = centerposition;
                    centeObj.transform.position += n * new Vector3(subface * -1, 0, dot * 1 + subface * 0.5f);

                }

                else if (p == 4)
                {
                    centeObj.transform.position = centerposition;
                    centeObj.transform.position += n * new Vector3(subface * -1, 0, -dot * 1 - subface * 0.5f);

                }
                else if (p == 5)
                {
                    centeObj.transform.position = centerposition;
                    centeObj.transform.position += n * new Vector3(subface * 1, 0, -dot * 1 - subface * 0.5f);






                }

            }
        }
        centerposition = centeObj.transform.position;



        if (Input.GetMouseButtonDown(0))
        {


            Instantiate(obj, centerposition, Quaternion.identity, parentobj);
        }




        //센터오브제 비교 현제 마우스 위치   centerposition을 옮겨줘야해
        //mach -> ture 

        //for (int p = 0; p < 6; p++)
        //{



        //    if (mach(angle, Direction_boundery[p]))
        //    {
        //        if (p == 0)
        //        {
        //            if (Input.GetMouseButtonDown(0))
        //            {
        //                centeObj.transform.position += n * new Vector3(subface * 2f, 0, dot * 0);

        //                Instantiate(centeObj);
        //            }
        //            if (Instantiate(centeObj) != null)
        //                centerposition = centeObj.transform.position;
        //        }


        //        else if (p == 3)
        //        {
        //            if (Input.GetMouseButtonDown(0))
        //            {
        //                centeObj.transform.position += n * new Vector3(subface * -2f, 0, dot * 0);
        //                Instantiate(centeObj);
        //            }
        //            if (Instantiate(centeObj) != null)
        //                centerposition = centeObj.transform.position;

        //        }

        //        else if (p == 1)
        //        {

        //            if (Input.GetMouseButtonDown(0))
        //            {
        //                centeObj.transform.position += n * new Vector3(subface * 1, 0, dot * 1 + subface * 0.5f);
        //                Instantiate(centeObj);
        //            }
        //            if (Instantiate(centeObj) != null)
        //                centerposition = centeObj.transform.position;

        //        }


        //        else if (p == 2)
        //        {
        //            if (Input.GetMouseButtonDown(0))
        //            {
        //                centeObj.transform.position += n * new Vector3(subface * -1, 0, dot * 1 + subface * 0.5f);
        //                Instantiate(centeObj);
        //            }
        //            if (Instantiate(centeObj) != null)
        //                centerposition = centeObj.transform.position;
        //        }

        //        else if (p == 4)
        //        {
        //            if (Input.GetMouseButtonDown(0))
        //            {
        //                centeObj.transform.position += n * new Vector3(subface * -1, 0, -dot * 1 - subface * 0.5f);
        //                Instantiate(centeObj);
        //            }
        //            if (Instantiate(centeObj) != null)
        //                centerposition = centeObj.transform.position;

        //        }
        //        if (p == 5)
        //        {
        //            if (Input.GetMouseButtonDown(0))
        //            {
        //                centeObj.transform.position += n * new Vector3(subface * 1, 0, -dot * 1 - subface * 0.5f);
        //                Instantiate(centeObj);
        //            }
        //            if (Instantiate(centeObj) != null)
        //                centerposition = centeObj.transform.position;

        //        }

        //    }
        //}



        //   if (mouseSize > 0.58)
        //    {

        //        for (int p = 0; p < 6; p++)
        //        {
        //            if (mach(localAngle, Direction_boundery[p]))
        //            {
        //                if (p == 0)
        //                {

        //                    centeObj.transform.position = new Vector3(subface * 1, 0, dot * 1 + subface * 0.5f);
        //                }
        //                else if (p == 3)
        //                {
        //                    centeObj.transform.position = new Vector3(subface * -1, 0, -dot * 1 - subface * 0.5f);
        //                }
        //                else if (p == 1)
        //                    centeObj.transform.position = new Vector3(subface * 2f, 0, dot * 0);

        //                else if (p == 2)
        //                {
        //                    centeObj.transform.position = new Vector3(subface * -1, 0, dot * 1 + subface * 0.5f);
        //                }
        //                else if (p == 4)
        //                {

        //                    centeObj.transform.position = new Vector3(subface * -2f, 0, dot * 0);

        //                }
        //                else if (p == 5)
        //                {
        //                    centeObj.transform.position = new Vector3(subface * 1, 0, -dot * 1 - subface * 0.5f);
        //                }

        //            }




        //        }
        //    }


        //}




    }

}

