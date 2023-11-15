using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using UnityEngine;

public class CoinSave : MonoBehaviour
{
    void Awake()
    {
    }
    private void Start()
    {
        if (DataManager.instance.nowCoin.coin == -10000)
        {

            DataManager.instance.SaveDataCoin();
            DataManager.instance.nowCoin.coin = 0;
        }

        DataManager.instance.LoadDataCoin();
       
    }
    // Update is called once per frame
    void Update()
    {



        StartCoroutine(turm());

    }

    IEnumerator turm()
    {
        yield return null;
        DataManager.instance.SaveDataCoin();
        yield return new WaitForSeconds(1f);

        DataManager.instance.LoadDataCoin();

    }
}
