using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.IO;

public class Save_Road: MonoBehaviour
{
   
    
    // Start is called before the first frame update
    void Start()
    {
        road();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void reset()
    {


        if (DataManager.instance.filename("save_hex") == "save_hex")
        {

            File.Delete(DataManager.instance.filename("save_hex"));
        }
    }

    public void save()
    {
        DataManager.instance.fileNameSting = "save_hex";

        

         DataManager.instance.save();
     
    }
    public void road()
    {
        DataManager.instance.fileNameSting = "save_hex";
      

        DataManager.instance.road();
       
    }
}
