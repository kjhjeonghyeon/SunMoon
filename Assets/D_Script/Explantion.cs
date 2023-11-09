using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explantion : MonoBehaviour
{
    public Transform explation;
    int count_explantion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
   public void Papper_Explation()
    {
        count_explantion++;

        if (count_explantion == 1)
        {

            explation.GetChild(1).gameObject.SetActive(true);//º≥∏È√¢


            explation.GetComponentInChildren<Animator>().SetTrigger("move");
            count_explantion++;

        }
        else if (count_explantion == 3)
        {
            explation.GetComponentInChildren<Animator>().SetBool("remove", true);
            StartCoroutine(Story_button());
            count_explantion = 0;
        }
     //   Debug.Log(count_explantion);


    }
    IEnumerator Story_button()
    {
        yield return new WaitForSeconds(1f);

        explation.GetChild(1).gameObject.SetActive(false);
    }

}
