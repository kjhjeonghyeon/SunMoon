using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class button_farm : MonoBehaviour
{

    public Transform parent_Canvars;
    int count_explantion = 0;
    Animator anim;

   public PlayableDirector timeline;
    // Start is called before the first frame update
    void Start()
    {
       anim= parent_Canvars.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    public void Papper_buy()
    {
        parent_Canvars.GetChild(0).gameObject.SetActive(false);
        //buy_상점
        parent_Canvars.GetChild(3).gameObject.SetActive(true);
    


    }

    public void Papper_buy_x()
    {
        parent_Canvars.GetChild(0).gameObject.SetActive(true);
        //buy_상점
        parent_Canvars.GetChild(3).gameObject.SetActive(false);

    }
    public void Water()
    {
        parent_Canvars.GetChild(1).gameObject.SetActive(false);
        parent_Canvars.GetChild(2).gameObject.SetActive(false);

    }
    public void Plant()
    {
        parent_Canvars.GetChild(1).gameObject.SetActive(true);
        parent_Canvars.GetChild(2).gameObject.SetActive(true);
    }

   
}
