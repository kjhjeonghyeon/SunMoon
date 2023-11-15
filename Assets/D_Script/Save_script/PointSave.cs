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
    }
    private void Start()
    {
        if (DataManager.instance.nowPoint.point == -10000)
        {
            DataManager.instance.SaveDataPoint();
            DataManager.instance.nowPoint.point = 0;
        }

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
