
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Array_Hex : MonoBehaviour
{
    float[] Direction = new float[12];
    float[] Direction_boundery = new float[12];
    // float Direction_patten = 777;// 각도 예외까지 합친 숫자 7

    float subface = 0.5f;
    float dot = 0.58f;//삼각형계산기로 다시 해줌


    Vector3 mousePoint;
    Vector3 mouseDirecter;
    float mouseSize;

    public GameObject parentobj_select;

  
   
   //ameObject select_x;

    public Transform parentobj;
    GameObject obj;
    GameObject obj_suv;


    public GameObject parentobj_nature;
    public GameObject parentobj_filed;
    public GameObject parentobj_robby;

    public GameObject mouse;

    Vector3 centerposition;
    float correctionValue;

    Vector3 mousePointxz;
    //63.43f//26.57f




    bool mach50(float a, float b)
    {
        if (Mathf.Abs(b - a) < 50)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    bool mach90(float a, float b)
    {
        if (Mathf.Abs(b - a) < 90)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    bool machVecter(Vector3 a, Vector3 b)
    {

        if ((Mathf.Abs(b.x - a.x) < 0.5f) && (Mathf.Abs(b.x - a.x) < 0.5f))
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





        #region 마우스위치와 원점 또는 오브제트 중심으로 하는 방향크기과 각도

        //마우스위치 에바 사용자이치 생성할꺼 고안하기
        mousePoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
              Input.mousePosition.y, -Camera.main.transform.position.z));

        if (mousePoint.z > 0)
        {
            mousePointxz = new Vector3(mousePoint.x, 0, mousePoint.z * ((mousePoint.z) / 2f) * 10f);//  z음의 방향으로는 안생성 

        }
        else if (mousePoint.z < 0)
        {
            mousePointxz = new Vector3(mousePoint.x, 0, mousePoint.z * ((mousePoint.z) / 2f) * -2f);//  z음의 방향으로는 안생성 

        }
        else
        {
            mousePointxz = new Vector3(mousePoint.x, 0, mousePoint.z);//  z음의 방향으로는 안생성 

        }
        mouseDirecter = new Vector3(mousePointxz.x, 0, mousePointxz.z) - centerposition;
        Vector3 mouseDirecter_O = new Vector3(mousePointxz.x, 0, mousePointxz.z) - Vector3.zero;
        //  Vector3 mouseDirecterLocal = new Vector3(mousePointxz.x, 0, mousePointxz.z) - parentobj_select.transform.position;
        mouseSize = Vector3.Magnitude(mouseDirecter_O);
        float mouseSize_local = Vector3.Magnitude(mouseDirecter);


        float anglet_opposite = Quaternion.FromToRotation(new Vector3(1, 0, 0), mouseDirecter_O - centerposition).eulerAngles.y;
        float angle = 360 - anglet_opposite;
        // float localAngle = angle;
        // Debug.Log(mousePoint);

        mouse.transform.position = mousePointxz;

        #endregion


        //센터 옮기는 함수
        float n = (int)mouseSize_local;

        //  parentobj_select.transform.position= centerposition;
        // Debug.Log(n);
        #region //상하와 좌우 오브젝트 존재 영역

        bool mouseSize_Veltical = false;

        if (mouseSize < 4f && mach90(angle, 90))
        {
            mouseSize_Veltical = true;
        }
        else if (mouseSize < 4f && mach90(angle, 270))
        {
            mouseSize_Veltical = true;
        }
        else
        {
            mouseSize_Veltical = false;
        }

        bool mouseSize_Horizontal = false;
        if (mouseSize < 9f && mach90(angle, 0))
        {
            mouseSize_Horizontal = true;
        }
        else if (mouseSize < 9f && mach90(angle, 360))
        {
            mouseSize_Horizontal = true;
        }
        else if (mouseSize < 9f && mach90(angle, 180))
        {
            mouseSize_Horizontal = true;
        }
        else
        {
            mouseSize_Horizontal = false;
        }
        #endregion



        if (mouseSize_Horizontal || mouseSize_Veltical)
        {
            for (int p = 0; p < 6; p++)
            {



                if (mach50(angle, Direction_boundery[p]))
                {
                    if (p == 0)
                    {
                        parentobj_select.transform.position = centerposition;
                        parentobj_select.transform.position += n * new Vector3(subface * 2f, 0, dot * 0);


                    }
                    //가까이있는거랑 안겹치려고 순서이렇게 해놈

                    else if (p == 3)
                    {
                        parentobj_select.transform.position = centerposition;
                        parentobj_select.transform.position += n * new Vector3(subface * -2f, 0, dot * 0);



                    }

                    else if (p == 1)
                    {
                        parentobj_select.transform.position = centerposition;
                        parentobj_select.transform.position += n * new Vector3(subface * 1, 0, dot * 1 + subface * 0.5f);



                    }


                    else if (p == 2)
                    {

                        parentobj_select.transform.position = centerposition;
                        parentobj_select.transform.position += n * new Vector3(subface * -1, 0, dot * 1 + subface * 0.5f);

                    }

                    else if (p == 4)
                    {
                        parentobj_select.transform.position = centerposition;
                        parentobj_select.transform.position += n * new Vector3(subface * -1, 0, -dot * 1 - subface * 0.5f);

                    }
                    else if (p == 5)
                    {
                        parentobj_select.transform.position = centerposition;
                        parentobj_select.transform.position += n * new Vector3(subface * 1, 0, -dot * 1 - subface * 0.5f);






                    }

                }
            }
            centerposition = parentobj_select.transform.position;







            if (Input.GetMouseButtonDown(2))
            {


                obj = GameObjectSelect.obj;
              
                obj.transform.position = centerposition;
            
                obj_suv = GameObjectSelect.obj_suv;
              
                obj_suv.transform.position = centerposition;
               
               
             

            }



            if (Input.GetMouseButtonDown(1) && machVecter(mouse.transform.position, centerposition) && obj != null)
            {
                obj_suv.SetActive ( false);
                obj.SetActive(false);
             
              
                obj.transform.position = parentobj.transform.position;
                    
                obj_suv.transform.position = parentobj.transform.position;

            }

          



        }


    }

  

}


