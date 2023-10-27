using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJ_selset : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

  public  void robby_buy_butten()
    {


        OBJ_Instance.gameObj = GameObject.Find("Fixed_Robby").transform.GetChild(0).gameObject;
    
    }
   
  public  void house_buy_butten()
    {



        OBJ_Instance.gameObj = GameObject.Find("Fixed_Robby").transform.GetChild(1).gameObject;
    }
    public void downtown_buy_butten()
    {



        OBJ_Instance.gameObj = GameObject.Find("Fixed_Robby").transform.GetChild(2).gameObject;
    }
    public void nature_buy_butten()
    {

        OBJ_Instance.gameObj= GameObject.Find("Fixed_Robby").transform.GetChild(3).gameObject;
    }

    public void filed_buy_butten()
    {



        OBJ_Instance.gameObj = GameObject.Find("Fixed_nature_OBJ");
    }



}
