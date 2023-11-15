using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class House_TimeLine : MonoBehaviour
{
    public PlayableDirector table;
    public PlayableDirector cooking;


    public TextMeshProUGUI textPoint;
    public TextMeshProUGUI textCoin;
    int pointCount = 0;
    int coinCount = 0;
    string savePoint;
    string saveCoin;

    // Start is called before the first frame update
    private void Awake()
    {


    }

    void Start()
    {
      
    }

   
    // Update is called once per frame
    void Update()
    {
        saveLode();
        DataManager.instance.nowPoint.point = putinfoPoint();
        DataManager.instance.nowCoin.coin = putinfoCount();


        if (table.time >= 11.5f)
        {
            table.Stop();
            table.time = 0.0f;
            pointCount -= 10;
            coinCount += 5;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        if (cooking.time >= 7)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            pointCount -= 2;
            coinCount++;
            cooking.Stop();
            cooking.time = 0.0f;
        }
    }


    private void saveLode()
    {
        savePoint = DataManager.instance.nowPoint.point.ToString();
        textPoint.text = savePoint;
        saveCoin = DataManager.instance.nowCoin.coin.ToString();
        textCoin.text = saveCoin;
    }

    int putinfoPoint()
    {
        return int.Parse(savePoint) + pointCount;
    }
    int putinfoCount()
    {
        return int.Parse(saveCoin) + coinCount;
    }


    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.layer == 11)//layer=table
        {
            if (putinfoPoint() > 10 )
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
               
                textPoint.text = putinfoPoint().ToString();
                textCoin.text = putinfoCount().ToString();
                table.Play();

            }


        }
        else if (other.gameObject.layer == 12)//layer=cooking
        {
            if (putinfoPoint() > 2 )
            {
                Debug.Log("무조건 성립");
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
            
                textPoint.text = putinfoPoint().ToString();
                textCoin.text = putinfoCount().ToString();
                cooking.Play();

            }



        }

    }

}
