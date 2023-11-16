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
    float count = 0;
    bool countbool = false;

    GameObject other_C;
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





    }

    void tableCount()
    {
        table.Stop();
        table.time = 0.0f;
        pointCount -= 10;
        coinCount += 5;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        countbool = false;
        StartCoroutine(triggerOff());
    }

    IEnumerator triggerOff()
    {
        yield return new WaitForSeconds(5f);
        other_C.GetComponent<BoxCollider>().isTrigger = true;

    }
    void cookCount()
    {

        cooking.Stop();
        cooking.time = 0.0f;
        pointCount -= 10;
        coinCount += 5;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        countbool = false;
        StartCoroutine(triggerOff());

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
        Debug.Log("무조권 성립");
        if (!countbool)
        {
        count+=Time.deltaTime;

        }
        
        if (other.gameObject.layer == 11)//layer=table
        {
        other_C = other.gameObject;

            other.GetComponent<BoxCollider>().isTrigger = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);

            textPoint.text = putinfoPoint().ToString();
            textCoin.text = putinfoCount().ToString();
            table.Play();

            if (count >= 11.5f)
            {
                tableCount();
                countbool = true;
                count = 0;
            }


        }
        else if (other.gameObject.layer == 12 )//layer=cooking
        {
        other_C = other.gameObject;
            other.GetComponent<BoxCollider>().isTrigger = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);

            textPoint.text = putinfoPoint().ToString();
            textCoin.text = putinfoCount().ToString();
            cooking.Play();


            if (count >= 7.5f)
            {
                cookCount();
                countbool = true;
                count = 0;
            }
        }
        
    }

}
