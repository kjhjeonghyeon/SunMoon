using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_farm : MonoBehaviour
{

    public Transform parent_Canvars;
    int count_explantion = 0;
    Animator anim;
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
        //buy_»óÁ¡
        parent_Canvars.GetChild(3).gameObject.SetActive(true);
    


    }

    public void Papper_buy_x()
    {
        parent_Canvars.GetChild(0).gameObject.SetActive(true);
        //buy_»óÁ¡
        parent_Canvars.GetChild(3).gameObject.SetActive(false);

    }

   public void Papper_Explation()
    {
<<<<<<< HEAD
        count_explantion++;
  
        if (count_explantion == 1)
        {
      
        parent_Canvars.GetChild(4).transform.GetChild(1).gameObject.SetActive(true);//¼³¸éÃ¢


            anim.SetTrigger("move");
            count_explantion++;

        }
       else if (count_explantion == 3)
        {
            anim.SetBool("remove",true);
            StartCoroutine(Story_button());
            count_explantion = 0;
        }
        Debug.Log(count_explantion);

=======
        parent_Canvars.GetChild(1).gameObject.SetActive(false);
        parent_Canvars.GetChild(2).gameObject.SetActive(false);
>>>>>>> parent of 3db0c795 (jsonìœ¼ë¡œ ì ìˆ˜ê¸°ë¡í•¨)

    }
    IEnumerator Story_button()
    {
<<<<<<< HEAD
        yield return new WaitForSeconds(1f);
        
        parent_Canvars.GetChild(4).transform.GetChild(1).gameObject.SetActive(false);
=======
        parent_Canvars.GetChild(1).gameObject.SetActive(true);
        parent_Canvars.GetChild(2).gameObject.SetActive(true);
>>>>>>> parent of 3db0c795 (jsonìœ¼ë¡œ ì ìˆ˜ê¸°ë¡í•¨)
    }

   

}
