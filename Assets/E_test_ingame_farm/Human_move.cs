using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class Human_move : MonoBehaviour
{

    public PlayableDirector timelin;
    public PlayableDirector timelin2;

    public GameObject plantLv0;
    public GameObject plantParent;
    public GameObject objnull;
    public GameObject boxs;
    GameObject[] boxpos = new GameObject[9];


    int count = 0;
    int activecount = 0;
    // Start is called before the first frame update

    List<GameObject> plant = new List<GameObject>();

    public GameObject directer;
    bool isHit;
    RaycastHit hit;
    Vector3 install;
    GameObject my;

    #region components
    Animator anim;
        #endregion
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();


        plantParent = Instantiate(plantParent);
    }
    private void Start()
    {
        my = gameObject;
    }
    // Update is called once per frame
    void Update()
    {

        pos();

        move();
        motion();

    }





    void OnDrawGizmos()
    {

        float maxDistance = 0.5f;

        // Physics.Raycast (레이저를 발사할 위치, 발사 방향, 충돌 결과, 최대 거리)
        isHit = Physics.Raycast(directer.transform.position, directer.transform.forward, out hit, maxDistance);

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
            timelin.Play();
            if (timelin.time == 11)
            {
                timelin.Stop();
                timelin.time = 0.0f;
            }

            activecount++;

            timelin2.Play();

            if (timelin.time >= 11)
            {
                timelin2.Stop();
                timelin2.time = 0.0f;


                plant[plant.Count - activecount].transform.position = install;
                plant[plant.Count - activecount].SetActive(true);


            }
        }

    }

    public void buy()
    {
        count++;





        plant.Add(Instantiate(plantLv0, plantParent.transform));

        GameObject.Find("PlantParent(Clone)").transform.GetChild(count - 1).gameObject.SetActive(false);







    }

    void pos()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {

            for (int a = 0; a < 10; a++)
            {
                boxpos[a] = boxs.transform.GetChild(a).gameObject;
                if (isHit == true)
                {

                    if (hit.transform.GetComponent<GameObject>().gameObject == boxpos[a])
                    {
                        install = boxpos[a].transform.position;
                        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, boxpos[a].transform.position, 10f);
                    }
                }
            }



        }

    }


    private void move()
    {
        float speed = 5f;
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
           
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * -speed * Time.deltaTime);
          

        }
   
            


        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward *speed * Time.deltaTime);
           

        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.forward *- speed * Time.deltaTime);
           
        }
     
        

        
          
       
           







    }


    void motion()
    {

        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)))
        {


            anim.SetTrigger("move1");

        }

        else if (Input.GetKey(KeyCode.UpArrow))
        {


            anim.SetTrigger("move1");

        }

        else if (Input.GetKey(KeyCode.DownArrow) )
        {

            anim.SetTrigger("move2");
        }

        else if (Input.GetKey(KeyCode.UpArrow) && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)))
        {


            anim.SetTrigger("move1");

        }

        else if (Input.GetKey(KeyCode.DownArrow) && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)))
        {

            anim.SetTrigger("move2");
        }
        else

            anim.SetTrigger("move0");


        //anim.ResetTrigger("move2");
        //anim.ResetTrigger("move1");
        //anim.ResetTrigger("move0");
    }
}

