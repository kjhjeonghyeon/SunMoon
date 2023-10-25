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
    
    Transform parent;
    public Transform editManagerParent;
    private void Awake()
    {
        
       
    }
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
        parent.GetChild(0).gameObject.SetActive(false);
        parent.GetChild(1).gameObject.SetActive(true);
        editManagerParent.GetChild(0).gameObject.SetActive(true);





    }

    public void editButten_UnActive()
    {

        parent.GetChild(0).gameObject.SetActive(true);
        parent.GetChild(1).gameObject.SetActive(false);

        editManagerParent.GetChild(0).gameObject.SetActive(false);// code는 발동해서 오브젝트가 안꺼짐->수정해

    }
}
