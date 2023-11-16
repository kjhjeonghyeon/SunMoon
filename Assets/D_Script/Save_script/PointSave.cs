using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using UnityEngine;

public class pointSave : MonoBehaviour
{
    float count;
    // Start is called before the first frame update
    void Awake()
    {
    }
    private void Start()
    {
        if (DataManager.instance.newNowPoint == true)
        {

            DataManager.instance.SaveDataPoint();
            DataManager.instance.nowPoint.point = 0;


        }
        if (DataManager.instance.newNowPoint == false)

            DataManager.instance.LoadDataPoint();
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        //DataManager.instance.newNowRobby = false;
        if (count % 1 == 0)
            StartCoroutine(turm());




    }

    IEnumerator turm()
    {
        yield return null;
        DataManager.instance.SaveDataPoint();
       // yield return new WaitForSeconds(3f);
        yield return null;

        DataManager.instance.LoadDataPoint();
        DataManager.instance.newNowPoint = false;

    }
}
