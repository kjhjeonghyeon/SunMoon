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

public class Human_move_farm : MonoBehaviour
{
<<<<<<< HEAD

    public PlayableDirector timelin;
    public PlayableDirector timelin2;

    public GameObject plantLv0;
    public GameObject plant_Lv0_preview;
    public GameObject plantParent;
    public GameObject objnull;
    public GameObject boxs;
    GameObject[] boxpos = new GameObject[12];

=======
  //  public TextMeshProUGUI text;

    public PlayableDirector timelin;
    public PlayableDirector timelin2;
    public PlayableDirector timeline3;

    public GameObject plantLv0_Parent;
    public GameObject plant_Lv0_preview;
    public GameObject plantParent;


    public GameObject boxs;
    GameObject[] boxpos = new GameObject[12];

    int liveCount = 0;
>>>>>>> parent of 3db0c795 (jsonìœ¼ë¡œ ì ìˆ˜ê¸°ë¡í•¨)

    int count = 0;
    int activecount = 1;
    bool waterButtonOn = false;
    // Start is called before the first frame update

    List<GameObject> plant = new List<GameObject>();

    public GameObject directer;
    bool isHit;
    RaycastHit hit;
    Vector3 install;
    GameObject my;
    public LayerMask layerMask;
<<<<<<< HEAD
=======
    public LayerMask layerMask_planted;


    

>>>>>>> parent of 3db0c795 (jsonìœ¼ë¡œ ì ìˆ˜ê¸°ë¡í•¨)
    #region components
    Animator anim;
    Transform mypos;
    #endregion
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        mypos = GetComponent<Transform>();

<<<<<<< HEAD
        plantParent = Instantiate(plantParent);
=======
       // text.text=PlayerPrefs.GetInt("point").ToString();
>>>>>>> parent of 3db0c795 (jsonìœ¼ë¡œ ì ìˆ˜ê¸°ë¡í•¨)
    }
    private void Start()
    {
        pos_obj();
        my = gameObject;
<<<<<<< HEAD
=======



>>>>>>> parent of 3db0c795 (jsonìœ¼ë¡œ ì ìˆ˜ê¸°ë¡í•¨)
    }
    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD


=======
        Debug.Log(PlayerPrefs.GetInt("point"));
      
>>>>>>> parent of 3db0c795 (jsonìœ¼ë¡œ ì ìˆ˜ê¸°ë¡í•¨)
        move();

        pos();


        seed_active();

<<<<<<< HEAD
=======
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

>>>>>>> parent of 3db0c795 (jsonìœ¼ë¡œ ì ìˆ˜ê¸°ë¡í•¨)
    }





    void OnDrawGizmos()
    {

        float maxDistance = 0.5f;


        // Physics.Raycast (·¹ÀÌÀú¸¦ ¹ß»çÇÒ À§Ä¡, ¹ß»ç ¹æÇâ, Ãæµ¹ °á°ú, ÃÖ´ë °Å¸®)
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

        if (waterButtonOn)
        {


            if (isHit == true)
            {

                if (count > 0)
                {
                    if (activecount == count)//°¹¼öÁ¦ÇÑ-> 1°³¾¿
                    {

                        activecount++;
                        timelin.Play();


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

<<<<<<< HEAD
   public void Water()
=======
    public void Water()
    {
        waterButtonOn = true;


    }
    public void Plant()
>>>>>>> parent of 3db0c795 (jsonìœ¼ë¡œ ì ìˆ˜ê¸°ë¡í•¨)
    {
        waterButtonOn = false;
    }
   public void Plant()
    {
<<<<<<< HEAD
        waterButtonOn = true;
=======


        Vector3 plantnow = hit2.collider.gameObject.transform.position;

        installed = plantnow;



            //Debug.Log(install);
            if (isHit_planted)
            {
                mypos.position = installed;
                timeline3.Play();

            //int k=0;
            //k++;
            //int l;
            //l= PlayerPrefs.GetInt("point");

            //text.text = (k + l).ToString();
            //PlayerPrefs.SetInt("point",k+l );
           
            }
        for (int a = 0; a < 12; a++)
        {
            if (boxpos[a].transform.position == installed)
            {
                boxpos[a].SetActive(true);

            }




        }

>>>>>>> parent of 3db0c795 (jsonìœ¼ë¡œ ì ìˆ˜ê¸°ë¡í•¨)
    }

    private void seed_active()
    {
<<<<<<< HEAD

=======
        int count_repeat = 0;
       
            
>>>>>>> parent of 3db0c795 (jsonìœ¼ë¡œ ì ìˆ˜ê¸°ë¡í•¨)
        if (timelin.time >= 11)
        {
            timelin.Stop();
            timelin.time = 0.0f;

        }



        if (timelin2.time >= 11)
        {
<<<<<<< HEAD
            timelin2.Stop();
            timelin2.time = 0.0f;

            plant[plant.Count - 1].transform.position = install;
            plant[plant.Count - 1].SetActive(true);
=======
                        plant_Lv0_preview.SetActive(false);
            count_repeat++;
            timelin2.Stop();
            timelin2.time = 0.0f;
            plant[plant.Count - count_repeat].transform.position = install;
            plant[plant.Count - count_repeat].SetActive(true);
>>>>>>> parent of 3db0c795 (jsonìœ¼ë¡œ ì ìˆ˜ê¸°ë¡í•¨)


        }
    }

    public void buy()
    {
        if (waterButtonOn)
        {

            if (count < activecount)//°¹¼öÁ¦ÇÑ-> 1°³¾¿
            {
                count++;





                plant.Add(Instantiate(plantLv0, plantParent.transform));

                plantParent.transform.GetChild(count - 1).gameObject.SetActive(false);




            }
        }


    }
<<<<<<< HEAD
=======


    public void Grow()
    {

    }
>>>>>>> parent of 3db0c795 (jsonìœ¼ë¡œ ì ìˆ˜ê¸°ë¡í•¨)
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
        float speed = 2f;

        Vector3 v_v;
        v_v.x = -1 * Input.GetAxis("Horizontal");
        v_v.z = -1 * Input.GetAxis("Vertical");




        GetComponentInChildren<Rigidbody>().velocity = new Vector3(v_v.x, 0, v_v.z) * speed;


        anim.SetFloat("X", GetComponentInChildren<Rigidbody>().velocity.x);
        anim.SetFloat("Y", GetComponentInChildren<Rigidbody>().velocity.z);






    }


}

