using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEditor.UI;
using UnityEngine.UIElements;

public class Edit_Active : MonoBehaviour
{
    
   public  Transform parent_canvars;

    public Transform parent_selec;

    private void Awake()
    {
        
       
    }
    // Start is called before the first frame update
    void Start()
    {

        

}

    // Update is called once per frame
    void Update()
    {
       
    }

   public void editButten_Active()
    {
        parent_canvars.GetChild(1).gameObject.SetActive(true);
        parent_canvars.GetChild(2).gameObject.SetActive(false);
        parent_canvars.GetChild(4).gameObject.SetActive(true);
        parent_canvars.GetChild(0).gameObject.SetActive(true);


        parent_selec.GetChild(0).gameObject.SetActive(true);
        parent_selec.GetChild(1).gameObject.SetActive(true);



    }

    public void editButten_UnActive()
    {

        parent_canvars.GetChild(1).gameObject.SetActive(false);
        parent_canvars.GetChild(2).gameObject.SetActive(true);
        parent_canvars.GetChild(4).gameObject.SetActive(false);
        parent_canvars.GetChild(0).gameObject.SetActive(true);

        parent_selec.GetChild(0).gameObject.SetActive(false);
        parent_selec.GetChild(1).gameObject.SetActive(false);


    }
}
