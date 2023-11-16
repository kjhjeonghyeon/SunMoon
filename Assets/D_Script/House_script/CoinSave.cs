using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using UnityEngine;

public class CoinSave : MonoBehaviour
{ float count = 0;
    void Awake()
    {
    }
    private void Start()
    {
        if (DataManager.instance.newNowCoin ==true)
        {
            DataManager.instance.SaveDataCoin();

            DataManager.instance.nowCoin.coin = 0;


        }
        if (DataManager.instance.newNowCoin == false)
        {

            DataManager.instance.LoadDataCoin();
        }
       
    }
    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        //DataManager.instance.newNowRobby = false;
        if(count%1==0)
        StartCoroutine(turm());

    }

    IEnumerator turm()
    {
        yield return null;
        DataManager.instance.SaveDataCoin();
      //  yield return new WaitForSeconds(3f);
        yield return null;
        DataManager.instance.newNowCoin = false;
        DataManager.instance.LoadDataCoin();

    }
}
