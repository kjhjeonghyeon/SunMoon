using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class Human_move : MonoBehaviour
{

   public PlayableDirector timelin;
   public PlayableDirector timelin2;

    public GameObject plantLv0;
    public GameObject plantParent;
    GameObject[] plant;

    int count = -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void seed()
    {
        timelin.Play();
        if(timelin.time == 11)
        {
        timelin.Stop();
            timelin.time = 0.0f;
        }


        timelin2.Play();
        if (timelin.time == 11)
        {
            timelin2.Stop();
            timelin2.time = 0.0f;
        }

    }

    public void buy()
    {    if (Input.GetButtonDown("buy"))
        {
            count++;
            if (count > -1)
            {

            plant[count] = Instantiate(plantLv0, plantParent.transform);
                plant[count].SetActive(false);
            }
        }



    }
}
