
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
    float correctionValue;

    Vector3 mousePointxz;
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

     
        //63.43f//26.57f
        Direction_boundery[0] = 0;
        Direction_boundery[3] = 180;
        Direction_boundery[1] = 90 - 26.57f;
        Direction_boundery[2] = 90 + 26.57f;
        Direction_boundery[4] = 270 - 26.57f;
        Direction_boundery[5] = 270 + 26.57f;



        





    }


    void Update()
    {







        //마우스위치 에바 사용자이치 생성할꺼 고안하기
        mousePoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
              Input.mousePosition.y, -Camera.main.transform.position.z));

        if (mousePoint.z > 0)
        {
          mousePointxz = new Vector3(mousePoint.x, 0, mousePoint.z * ((mousePoint.z)/2f)*10f);//  z음의 방향으로는 안생성 

        }
       else if (mousePoint.z <0)
        {
          mousePointxz = new Vector3(mousePoint.x, 0, mousePoint.z*((mousePoint.z) / 2f) *-2f);//  z음의 방향으로는 안생성 

        }
        else
        {
            mousePointxz = new Vector3(mousePoint.x, 0, mousePoint.z );//  z음의 방향으로는 안생성 

        }
        mouseDirecter = new Vector3(mousePointxz.x, 0, mousePointxz.z) - centerposition;
        Vector3 mouseDirecter_O = new Vector3(mousePointxz.x, 0, mousePointxz.z) - Vector3.zero;
        //  Vector3 mouseDirecterLocal = new Vector3(mousePointxz.x, 0, mousePointxz.z) - centeObj.transform.position;
        mouseSize = Vector3.Magnitude(mouseDirecter_O);
        float mouseSize_local = Vector3.Magnitude(mouseDirecter);


        float anglet_opposite = Quaternion.FromToRotation(new Vector3(1, 0, 0), mouseDirecter_O - centerposition).eulerAngles.y;
        float angle = 360 - anglet_opposite;
        // float localAngle = angle;
        Debug.Log(mousePoint);

        mouse.transform.position = mousePointxz;


      

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



        if (Input.GetMouseButtonDown(2))
        {


            Instantiate(obj, centerposition, Quaternion.identity, parentobj);
        }




      



    }

}

