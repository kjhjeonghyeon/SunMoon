using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuySystem : MonoBehaviour
{
   public Transform parent_canvars;

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
        parent_canvars.GetChild(0).gameObject.SetActive(false);
        parent_canvars.GetChild(1).gameObject.SetActive(false);
        parent_canvars.GetChild(2).gameObject.SetActive(true);

    }
    public void Buy_Active_Button_UnActive()
    {
        parent_canvars.GetChild(0).gameObject.SetActive(true);
        parent_canvars.GetChild(1).gameObject.SetActive(true);
        parent_canvars.GetChild(2).gameObject.SetActive(false);

    }

    public void Robby_Buy_Button()
    {
        //해당 오브젝트 인스턴트에 넣기
     
        
    }
}
