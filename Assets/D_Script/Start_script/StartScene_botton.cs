using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene_botton : MonoBehaviour
{

   public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setting_button()
    {
        canvas.transform.GetChild(4).gameObject.SetActive(true);

    }
    public void setting_button_X()
    {
        canvas.transform.GetChild(4).gameObject.SetActive(false);

    }
   

    public void end_button()
    {
     Application.Quit();
    }
    public void ending_button()
    {
        canvas.transform.GetChild(5).gameObject.SetActive(true);
        
    }
}
