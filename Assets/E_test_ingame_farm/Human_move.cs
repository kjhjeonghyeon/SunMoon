using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class Human_move : MonoBehaviour
{

    public PlayableDirector timelin;
    public PlayableDirector timelin2;

    public GameObject plantLv0;
    public GameObject plant_Lv0_preview;
    public GameObject plantParent;
    public GameObject objnull;
    public GameObject boxs;
    GameObject[] boxpos = new GameObject[12];


    int count = 0;
    int activecount = 1;
    // Start is called before the first frame update

    List<GameObject> plant = new List<GameObject>();

    public GameObject directer;
    bool isHit;
    RaycastHit hit;
    Vector3 install;
    GameObject my;
    public LayerMask layerMask;
    #region components
    Animator anim;
    Transform mypos;
    #endregion
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        mypos = GetComponent<Transform>();

        plantParent = Instantiate(plantParent);
    }
    private void Start()
    {
        pos_obj();
        my = gameObject;
    }
    // Update is called once per frame
    void Update()
    {


        move();

        pos();


        seed_active();

    }





    void OnDrawGizmos()
    {

        float maxDistance = 0.5f;


        // Physics.Raycast (레이저를 발사할 위치, 발사 방향, 충돌 결과, 최대 거리)
        isHit = Physics.Raycast(directer.transform.position, directer.transform.forward, out hit, maxDistance, layerMask);



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



        if (count > 0)
        {

            if (activecount == count)//갯수제한-> 1개씩
            {

                activecount++;
                timelin.Play();


                timelin2.Play();
                if (install != null)
                {
                    mypos.position = install;

                    plant_Lv0_preview.transform.position = install;
                }


            }
        }

    }

    private void seed_active()
    {
        if (timelin.time >= 11)
        {
            timelin.Stop();
            timelin.time = 0.0f;

        }



        if (timelin2.time >= 11)
        {
            timelin2.Stop();
            timelin2.time = 0.0f;

            plant[plant.Count - 1].transform.position = install;
            plant[plant.Count - 1].SetActive(true);


        }
    }

    public void buy()
    {
        if (count < activecount)//갯수제한-> 1개씩
        {
            count++;





            plant.Add(Instantiate(plantLv0, plantParent.transform));

            plantParent.transform.GetChild(count - 1).gameObject.SetActive(false);




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

                    install = new Vector3(boxpos[a].transform.position.x, gameObject.transform.position.y, boxpos[a].transform.position.z);



                    //Debug.Log(install);


                }
            }
        }






    }


    private void move()
    {
        float speed = 5f;

        Vector3 v_v;
        v_v.x = -1 * Input.GetAxis("Horizontal");
        v_v.z = -1 * Input.GetAxis("Vertical");




        GetComponentInChildren<Rigidbody>().velocity = new Vector3(v_v.x, 0, v_v.z) * speed;


        anim.SetFloat("X", GetComponentInChildren<Rigidbody>().velocity.x);
        anim.SetFloat("Y", GetComponentInChildren<Rigidbody>().velocity.z);






    }


}

