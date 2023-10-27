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
    
   public Transform canvars;

    public GameObject parentOBJ;
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
 
        canvars.GetChild(0).gameObject.SetActive(false);
        canvars.GetChild(1).gameObject.SetActive(true);
    

        parentOBJ.transform.GetChild(2).gameObject.SetActive(true);
        parentOBJ.transform.GetChild(3).transform.GetChild(0).gameObject.SetActive(true);
        parentOBJ.transform.GetChild(3).transform.GetChild(1).gameObject.SetActive(true);

    }

    public void editButten_UnActive()
    {

        canvars.GetChild(0).gameObject.SetActive(true);
        canvars.GetChild(1).gameObject.SetActive(false);

        

        parentOBJ.transform.GetChild(2).gameObject.SetActive(false);
        parentOBJ.transform.GetChild(3).transform.GetChild(0).gameObject.SetActive(false);
        parentOBJ.transform.GetChild(3).transform.GetChild(1).gameObject.SetActive(false);
    }

    private void OnEnable()
    {
     
    }
}
