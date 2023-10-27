using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class GameObjectSelect : MonoBehaviour
{

    public static GameObjectSelect instance;
    public static GameObject obj;
    public static GameObject obj_suv;


  
                  
    public Transform parentobj;
    public GameObject parentobj_nature;
    public GameObject parentobj_filed;
    public GameObject parentobj_robby;
    void Start()
    {



        GameObjectSelect.obj = parentobj.GetChild(0).gameObject;
        GameObjectSelect.obj_suv = parentobj.GetChild(1).gameObject;




     

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void robby_buy_butten()
    {
     

        parentobj_robby.transform.GetChild(0).gameObject.SetActive(true);
        GameObjectSelect.obj = parentobj_robby.transform.GetChild(0).gameObject;
   



    }

    public void house_buy_butten()
    {
       
        parentobj_robby.transform.GetChild(1).gameObject.SetActive(true);
        GameObjectSelect.obj = parentobj_robby.transform.GetChild(1).gameObject;



    }
    public void downtown_buy_butten()
    {
       
        parentobj_robby.transform.GetChild(3).gameObject.SetActive(true);
        GameObjectSelect.obj = parentobj_robby.transform.GetChild(3).gameObject;




    }
    public void nature_buy_butten()
    {
        nature();
    }

    public void filed_buy_butten()
    {


        filed();


    }
    //상황에 맞게 다시구성(예비)
    void nature()
    {
        parentobj_nature.transform.GetChild(0).gameObject.SetActive(true);
        parentobj_nature.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);


       GameObjectSelect.obj = parentobj_nature.transform.GetChild(0).gameObject;
       GameObjectSelect.obj_suv = parentobj_nature.transform.GetChild(0).transform.GetChild(0).gameObject;

    }
    void filed()
    {
        parentobj_filed.transform.GetChild(0).gameObject.SetActive(true);
        parentobj_filed.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);


        GameObjectSelect.obj = parentobj_filed.transform.GetChild(0).gameObject;
        GameObjectSelect.obj_suv = parentobj_filed.transform.GetChild(0).transform.GetChild(0).gameObject;


    }



}
