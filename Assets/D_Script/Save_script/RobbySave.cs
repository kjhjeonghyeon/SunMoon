using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RobbySave : MonoBehaviour
{


    public GameObject hex;

    // Start is called before the first frame update
    void Awake()
    {

    }
    private void Start()
    {
        Load();

        //DataManager.instance.LoadDataRobby();
        //Invoke("LoadDataRobby", 2f);
        //for (int i = 0; i < hex.transform.childCount; i++)
        //{



        //    DataManager.instance.robbyList[i].hexname = hex.transform.GetChild(i).gameObject.name ;

        //    DataManager.instance.robbyList[i].position = hex.transform.GetChild(i).position;
        //    DataManager.instance.robbyList[i].ative = hex.transform.GetChild(i).gameObject.activeSelf;

        //    DataManager.instance.robbyDatas.robbyData = DataManager.instance.robbyList[i];
        //}



        //DataManager.instance.SaveDataRobby();


    }

   

    public void Save()
    {

        for (int i = 0; i < hex.transform.childCount; i++)
        {
           


            DataManager.instance.robbyDatas.robbyData[i].hexname = hex.transform.GetChild(i).gameObject.name.ToString();
            DataManager.instance.robbyDatas.robbyData[i].position = hex.transform.GetChild(i).position;
            DataManager.instance.robbyDatas.robbyData[i].ative = hex.transform.GetChild(i).gameObject.activeSelf;

          
        }
        StartCoroutine(turm());

    }

    IEnumerator turm()
    {

        yield return null;
        DataManager.instance.SaveDataRobby();




    }
    void Load()
    {
        DataManager.instance.LoadDataRobby();
        for (int i = 0; i < hex.transform.childCount; i++)
        {


            hex.transform.GetChild(i).gameObject.name = DataManager.instance.robbyDatas.robbyData[i].hexname;
            hex.transform.GetChild(i).position = DataManager.instance.robbyDatas.robbyData[i].position;
            hex.transform.GetChild(i).gameObject.SetActive(DataManager.instance.robbyDatas.robbyData[i].ative);

        }


    }

}