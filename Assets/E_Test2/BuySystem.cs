using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuySystem : MonoBehaviour
{

   public  Transform canvas;
   public  GameObject parentOBJ;
   
    private void Awake()
    {
        
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }







    public void Buy_Active_Button()
    {
       
        canvas.GetChild(0).gameObject.SetActive(false);
        canvas.GetChild(2).gameObject.SetActive(false);
        canvas.GetChild(3).gameObject.SetActive(true);

        parentOBJ.transform.GetChild(2).gameObject.SetActive(false);
        parentOBJ.transform.GetChild(3).transform.GetChild(0).gameObject.SetActive(false);
        parentOBJ.transform.GetChild(3).transform.GetChild(1).gameObject.SetActive(false);

     
    }
    public void Buy_Active_Button_UnActive()
    {
        canvas.GetChild(0).gameObject.SetActive(true);
        canvas.GetChild(2).gameObject.SetActive(true);
        canvas.GetChild(3).gameObject.SetActive(false);

        parentOBJ.transform.GetChild(2).gameObject.SetActive(true);
        parentOBJ.transform.GetChild(3).transform.GetChild(0).gameObject.SetActive(true);
        parentOBJ.transform.GetChild(3).transform.GetChild(1).gameObject.SetActive(true);


    }

}
