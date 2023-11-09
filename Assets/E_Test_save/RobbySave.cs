using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobbySave : MonoBehaviour
{

    // Start is called before the first frame update
    void Awake()
    {
        //DataManager.instance.LoadDataRobby();
    }

    // Update is called once per frame
    void Update()
    {



        StartCoroutine(turm());

    }

    IEnumerator turm()
    {
        yield return null;
       // DataManager.instance.SaveDataRobby(); 
        yield return new WaitForSeconds(1f);

       // DataManager.instance.LoadDataRobby();

    }
}
