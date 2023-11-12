using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TMPro;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;
using static UnityEditor.Progress;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class Human_move_farm : MonoBehaviour
{
    public TextMeshProUGUI textPoint;
    string savePoint;

    int pointCount = 0;

    public PlayableDirector timelin;
    public PlayableDirector timelin2;
    public PlayableDirector timeline3;
    public PlayableDirector timeline4_grow;

    public GameObject plantLv0_Parent;
    public GameObject plantLvMax_fruit;
    public GameObject plant_Lv0_preview;
    public GameObject plant_LvMax_preview;
    public GameObject plantParent;
    public GameObject items;
    public GameObject water;

    public GameObject plantLvMax_fruit_parent;

    public GameObject boxs;
    GameObject[] boxpos = new GameObject[12];

    int liveCount = 0;
    int count = 0;
    int activecount = 1;
    bool waterButtonOn = false;
    // Start is called before the first frame update

    List<GameObject> plant = new List<GameObject>();

    public GameObject directer;
    bool isHit;
    bool isHit_planted;
    RaycastHit hit;
    RaycastHit hit2;
    Vector3 install;
    Vector3 installed;
    GameObject my;
    public LayerMask layerMask;
    public LayerMask layerMask_planted;


    int activeCount;
    Vector3 plantnow;
    #region components
    Animator anim;
    Transform mypos;
    #endregion
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        mypos = GetComponent<Transform>();


        // Debug.Log(savePoint + "," + savePoint.ToString().GetType());
    }
    private void Start()
    {
        pos_obj();
        my = gameObject;

        savePoint = DataManager.instance.nowPoint.point.ToString();
        textPoint.text = savePoint;




    }


    int putinfoPoint()
    {
        return int.Parse(savePoint) + pointCount;
    }
    // Update is called once per frame
    void Update()
    {

        DataManager.instance.nowPoint.point = putinfoPoint();


        move();

        pos();


        seed_active();

        if (timeline3.time >= 7)
        {
            timeline3.Stop();
            timeline3.time = 0.0f;

        }
        if (timeline3.time >= 5)
        {
            for (int a = 0; a < plantParent.transform.childCount; a++)
            {

                if (plantParent.transform.GetChild(a).transform.position == installed)
                {
                    plant_Lv0_preview.SetActive(false);

                    plantParent.transform.GetChild(a).gameObject.SetActive(false);


                }
            }
        }

    }





    void OnDrawGizmos()
    {

        float maxDistance = 0.5f;


        // Physics.Raycast (레이저를 발사할 위치, 발사 방향, 충돌 결과, 최대 거리)
        isHit = Physics.Raycast(directer.transform.position, directer.transform.forward, out hit, maxDistance, layerMask);
        isHit_planted = Physics.Raycast(directer.transform.position, directer.transform.forward, out hit2, 1f, layerMask_planted);



        Gizmos.color = Color.red;
        if (isHit)
        {
            Gizmos.DrawRay(directer.transform.position, directer.transform.forward * hit.distance);

        }
        else
        {
            Gizmos.DrawRay(directer.transform.position, directer.transform.forward * maxDistance);
        }

    }
    public void seed()
    {

        if (waterButtonOn == false)
        {


            if (isHit == true)
            {

                if (count > 0)
                {


                    pointCount++;
                    textPoint.text = putinfoPoint().ToString();



                    if (activecount == count)//갯수제한-> 1개씩
                    {
                        activecount++;
                        timelin.Play();
                        plant_Lv0_preview.SetActive(true);


                        timelin2.Play();
                        if (install != null)
                        {
                            mypos.position = install;

                            plant_Lv0_preview.transform.position = install;

                            for (int a = 0; a < 12; a++)
                            {
                                if (boxpos[a].transform.position == install)
                                {
                                    boxpos[a].SetActive(false);

                                }




                            }
                        }


                    }
                }
            }

        }
    }
    public void Grow()
    {

        if (isHit_planted)
        {

            Vector3 plantnow_growing = hit2.collider.gameObject.transform.position;
            plant_LvMax_preview.transform.position = plantnow_growing;

            timeline4_grow.Play();
            StartCoroutine(Growing());

        }

    }
    IEnumerator Growing()
    {

        yield return new WaitForSeconds(1f);

        hit2.collider.gameObject.SetActive(false);

        yield return new WaitForSeconds(3f);
        Instantiate(plantLvMax_fruit, plant_LvMax_preview.transform.position, Quaternion.identity, plantLvMax_fruit_parent.transform);
        plant_LvMax_preview.transform.GetChild(0).gameObject.SetActive(false);
        timeline4_grow.time = 0;
        timeline4_grow.Stop();
        water.transform.GetChild(0).gameObject.SetActive(false);


    }
    public void Water()
    {
        waterButtonOn = true;


    }
    public void Plant()
    {
        waterButtonOn = false;
    }
    IEnumerator havesting()
    {
        for (int a = 0; a < plantLvMax_fruit_parent.transform.childCount; a++)
        {
            if (plantLvMax_fruit_parent.transform.GetChild(a).gameObject.transform.position == installed)
            {
                pointCount += 7;
                yield return new WaitForSeconds(2f);
                plantLvMax_fruit_parent.transform.GetChild(a).gameObject.SetActive(false);
                yield return new WaitForSeconds(0.5f);
                plantLvMax_fruit_parent.transform.GetChild(a).gameObject.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                plantLvMax_fruit_parent.transform.GetChild(a).gameObject.SetActive(false);
                yield return new WaitForSeconds(0.5f);
                plantLvMax_fruit_parent.transform.GetChild(a).gameObject.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                plantLvMax_fruit_parent.transform.GetChild(a).gameObject.SetActive(false);
            }

        }

    }
    public void havest()
    {


      plantnow = hit2.collider.gameObject.transform.position;

        installed = plantnow;



        //Debug.Log(install);
        if (isHit_planted)
        {

            StartCoroutine(havesting());


            mypos.position = installed;
            timeline3.Play();
            items.transform.position = installed;
            pointCount += 3;
            textPoint.text = putinfoPoint().ToString();





            //int k=0;
            //k++;
            //int l;
            //l= PlayerPrefs.GetInt("point");

            //textPoint.textPoint = (k + l).ToString();
            //PlayerPrefs.SetInt("point",k+l );

        }

        for (int a = 0; a < 12; a++)
        {
            if (boxpos[a].transform.position == installed)
            {
                boxpos[a].SetActive(true);

            }




        }

    }
    private void seed_active()
    {
        int count_repeat = 0;


        if (timelin.time >= 11)
        {
            timelin.Stop();
            timelin.time = 0.0f;

        }



        if (timelin2.time >= 11)
        {
            plant_Lv0_preview.SetActive(false);
            count_repeat++;
            timelin2.Stop();
            plant[plant.Count - count_repeat].transform.position = install;
            plant[plant.Count - count_repeat].SetActive(true);
            activeCount = plant.Count - count_repeat;
            timelin2.time = 0.0f;

        }
    }

    public void buy()
    {
        if (waterButtonOn == false)
        {

            if (count < activecount)//갯수제한-> 1개씩
            {
                count++;



                liveCount = count - 1;

                plant.Add(plantLv0_Parent.transform.GetChild(11 - liveCount).gameObject);

                plant[liveCount].transform.SetParent(plantParent.transform);


                plantParent.transform.GetChild(count - 1).gameObject.SetActive(false);

            }
        }


    }



    void pos_obj()
    {
        for (int a = 0; a < 12; a++)
        {
            boxpos[a] = boxs.transform.GetChild(a).gameObject;



        }
    }
    void pos()
    {
        mypos.position = transform.position;

        for (int a = 0; a < 12; a++)
        {



            if (isHit == true)
            {


                if (hit.collider.gameObject.name == boxpos[a].name)
                {

                    //install = new Vector3(boxpos[a].transform.position.x, gameObject.transform.position.y, boxpos[a].transform.position.z);
                    install = boxpos[a].transform.position;



                    //Debug.Log(install);


                }
            }
        }






    }


    private void move()
    {
        float speed = 2f;

        Vector3 v_v;
        v_v.x = -1 * Input.GetAxis("Horizontal");
        v_v.z = -1 * Input.GetAxis("Vertical");




        GetComponentInChildren<Rigidbody>().velocity = new Vector3(v_v.x, 0, v_v.z) * speed;


        anim.SetFloat("X", GetComponentInChildren<Rigidbody>().velocity.x);
        anim.SetFloat("Y", GetComponentInChildren<Rigidbody>().velocity.z);






    }


}

