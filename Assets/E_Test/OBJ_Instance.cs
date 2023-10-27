using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJ_Instance : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }
   

       public static GameObject gameObj=null;

    public static GameObject GameOBJ()
    {


        if (GameObject.Find("Fixed_Robby").gameObject.active == true)
        {

            if (GameObject.Find("Fixed_Robby").transform.GetChild(0).gameObject == gameObj)
            {
                //startScene

                return gameObj;
            }
            else if (GameObject.Find("Fixed_Robby").transform.GetChild(1).gameObject == gameObj)
            {//house
                return gameObj;
            }
            else if (GameObject.Find("Fixed_Robby").transform.GetChild(2).gameObject == gameObj)
            {
                //downtown
                return gameObj;
            }
            else if (GameObject.Find("Fixed_Robby").transform.GetChild(3).gameObject == gameObj)
            {//lake
                return gameObj;
            }
            else
            {
                //fild
                return gameObj;
                //
            }

        }
        //else if (GameObject.Find(" Fixed_nature").gameObject.active == true)
        //{
        //    nature_Hex_OBJ(gameObject);
        //}

        else
        {

            Debug.Log("로비의 설치오브젝트를 찾지못한상태");
        }

        return null;



    }







        public void randomNature( )
        {

            int a = 0;
            a = Random.Range(0, 4);
            GameObject[] b = new GameObject[1];
            b[0] = GameObject.Find("Fixed").transform.GetChild(0).transform.GetChild(a).gameObject;
            b[1] = GameObject.Find("Fixed").transform.GetChild(1).transform.GetChild(a).gameObject;

      



        }
    

    //void nature_Hex_OBJ(GameObject gameObject)
    //{
    //    if (GameObject.Find("Fixed_nature").transform.GetChild(0).gameObject.active = true)
    //    {
            
    //        Anmmal_OBJ(gameObject);
    //    }
    //   else if (GameObject.Find("Fixed_nature").transform.GetChild(1).gameObject.active = true)
    //    {
    //        Anmmal_OBJ(gameObject);
    //    }

    //    else if (GameObject.Find("Fixed_nature").transform.GetChild(2).gameObject.active = true)
    //    {
    //        Anmmal_OBJ(gameObject);
    //    }
    //    else if (GameObject.Find("Fixed_nature").transform.GetChild(3).gameObject.active = true)
    //    {

    //        Anmmal_OBJ(gameObject);
    //    }
    //    else if (GameObject.Find("Fixed_nature").transform.GetChild(4).gameObject.active = true)
    //    {
    //        Anmmal_OBJ(gameObject);
    //    }
    //    else
    //    {
    //        Debug.Log("로비의 설치오브젝트를 찾지못한상태");

    //    }
    //}

    //GameObject Anmmal_OBJ(GameObject gameObject)
    //{
    //    if (GameObject.Find("Fixed_nature_OBJ").transform.GetChild(0).gameObject.active = true)
    //    {
    //        return gameObject;
    //    }
    //    else if (GameObject.Find("Fixed_nature_OBJ").transform.GetChild(1).gameObject.active = true)
    //    {
    //        return gameObject;
    //    }

    //    else if (GameObject.Find("Fixed_nature_OBJ").transform.GetChild(2).gameObject.active = true)
    //    {
    //        return gameObject;
    //    }
    //    else if (GameObject.Find("Fixed_nature_OBJ").transform.GetChild(3).gameObject.active = true)
    //    {
    //        return gameObject;
    //    }
    //    else if (GameObject.Find("Fixed_nature_OBJ").transform.GetChild(4).gameObject.active = true)
    //    {
    //        return gameObject;
    //    }
    //    else
    //    {
    //        Debug.Log("로비의 설치오브젝트를 찾지못한상태");

    //    }
    //        return null;
    //}
}
