using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using UnityEngine;

public class pointSave : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        DataManager.instance.LoadDataPoint();
    }

    // Update is called once per frame
    void Update()
    {

            
     
            StartCoroutine(turm());

    }

    IEnumerator turm()
    {
        yield return null;
        DataManager.instance.SaveDataPoint();
        yield return new WaitForSeconds(1f);
       
        DataManager.instance.LoadDataPoint();
       
    }
}
