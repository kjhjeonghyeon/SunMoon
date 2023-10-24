using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Edit_Active : MonoBehaviour
{
    
    Transform parent;
    // Start is called before the first frame update
    void Start()
    {

        parent = gameObject.transform;
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

   public void editButten_Active()
    {
        foreach (Transform child in parent.GetComponentsInChildren <Transform>())
        {

            if(child.gameObject.name== "Edit_Butten")
            {
               child.gameObject.SetActive(false);
                Debug.Log("Active");
            }
            if (child.gameObject.name == "EditButton_Active_Butten")
            {
                child.gameObject.SetActive(true);

            }
          

        }



    }

    public void editButten_UnActive()
    {
        foreach (Transform child in parent.GetComponentInChildren<Transform>().transform)
        {

            if (child.gameObject.name == "Edit_Butten")
            {
                child.gameObject.SetActive(true);

            }
            if (child.gameObject.name == "EditButton_Active_Butten")
            {
                child.gameObject.SetActive(false);

            }


        }
    }
}
