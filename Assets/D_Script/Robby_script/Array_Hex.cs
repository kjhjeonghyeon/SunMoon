
using System.Collections;
using System.Collections.Generic;
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


    Vector3 center;
    public GameObject selec_find;
    public GameObject selecter;
    public GameObject mouse;
    public GameObject obj;
    public GameObject hex;
    GameObject[] hex_Array = new GameObject[6];
    Vector3 centerposition;
    Vector3 nowpos;
    float correctionValue;

    Vector3 mousePointxz;
    //63.43f//26.57f
    bool bound = false;

    //Ray ray;
    //RaycastHit hit;
    //public LayerMask mask;
    bool mach(float a, float b)
    {
        if (Mathf.Abs(b - a) < 70)
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




        hex_Array[0] = hex.transform.GetChild(0).gameObject;
        hex_Array[1] = hex.transform.GetChild(1).gameObject;
        hex_Array[2] = hex.transform.GetChild(2).gameObject;
        hex_Array[3] = hex.transform.GetChild(3).gameObject;
        hex_Array[4] = hex.transform.GetChild(4).gameObject;
        hex_Array[5] = hex.transform.GetChild(5).gameObject;




    }


    void Update()
    {
        boundery();
        // 

        //ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Physics.Raycast(ray, out hit, Mathf.Infinity, mask);

        //mouse.transform.position = hit.point;

        #region 마우스,hex오브젝트 포지션


        //마우스위치 에바 사용자이치 생성할꺼 고안하기


        mousePoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
              Input.mousePosition.y, -Camera.main.transform.position.z));




        //var mPos = Input.mousePosition;
        //mPos.z *= -1;
        //mouse.transform.position = Camera.main.WorldToScreenPoint(Input.mousePosition);

        //Debug.Log(Input.mousePosition);



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
        //  Vector3 mouseDirecterLocal = new Vector3(mousePointxz.x, 0, mousePointxz.z) - center.transform.position;
        mouseSize = Vector3.Magnitude(mouseDirecter_O);
        float mouseSize_local = Vector3.Magnitude(mouseDirecter);


        float anglet_opposite = Quaternion.FromToRotation(new Vector3(1, 0, 0), mouseDirecter_O - centerposition).eulerAngles.y;
        float angle = 360 - anglet_opposite;
        // float localAngle = angle;
        // Debug.Log(mousePoint);




        #endregion

        //센터 옮기는 함수
        float n = (int)mouseSize_local;

        //  center.transform.position= centerposition;
        // Debug.Log(n);
        for (int p = 0; p < 6; p++)
        {




            if (mach(angle, Direction_boundery[p]))
            {
                if (p == 0)
                {
                    center = centerposition;
                    center += n * new Vector3(subface * 2f, 0, dot * 0);


                }
                //가까이있는거랑 안겹치려고 순서이렇게 해놈

                else if (p == 3)
                {
                    center = centerposition;
                    center += n * new Vector3(subface * -2f, 0, dot * 0);



                }

                else if (p == 1)
                {
                    center = centerposition;
                    center += n * new Vector3(subface * 1, 0, dot * 1 + subface * 0.5f);



                }


                else if (p == 2)
                {

                    center = centerposition;
                    center += n * new Vector3(subface * -1, 0, dot * 1 + subface * 0.5f);

                }

                else if (p == 4)
                {
                    center = centerposition;
                    center += n * new Vector3(subface * -1, 0, -dot * 1 - subface * 0.5f);

                }
                else if (p == 5)
                {
                    center = centerposition;

                    center += n * new Vector3(subface * 1, 0, -dot * 1 - subface * 0.5f);






                }
            }


        }
        centerposition = center;
        if (bound == true)
        {
            selecter.transform.position = center;

            mouse.transform.position = center;
        }


        if (selec_find.transform.GetChild(0).gameObject.activeSelf)
        {

            if (Input.GetMouseButtonDown(1))
            {

                if (bound == true)
                {
                    obj.transform.position = centerposition;
                    obj.SetActive(true);
                    if (obj == hex_Array[5])
                        mouse.GetComponent<Animator>().SetTrigger("select");
                }


            }

            if (Input.GetMouseButtonDown(2))
            {


                for (int a = 0; a < 5; a++)
                {
                    if (hex_Array[a].transform.position == centerposition)
                    {
                        hex_Array[a].SetActive(false);
                    }

                }
            }


        }
        else
        {
            if (Input.GetMouseButtonDown(1))
            {
                mouse.GetComponent<Animator>().SetTrigger("select");
            }
            if (Input.GetMouseButtonDown(2))
            {
                mouse.GetComponent<Animator>().SetTrigger("select");
            }
        }
        // mouse.transform.position = centerposition;



        void boundery()
        {
            if (center.x < 8 && center.x > -8)
            {
                if (center.z < 4 && center.z > -4)
                {
                    bound = true;
                }
            }
            else
            {

                bound = false;
            }

        }
    }

        public void Lobby()
        {
            obj = hex_Array[1];
        }

        public void Farm()
        {



            obj = hex_Array[2];
        }
        public void House()
        {

            obj = hex_Array[3];
        }

        public void Wiled()
        {
            obj = hex_Array[4];

        }

        public void Lake()
        {
            obj = hex_Array[5];
        }
        public void save()
        {
            obj = hex_Array[0];
        }


    } 

