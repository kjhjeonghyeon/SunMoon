using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuySystem : MonoBehaviour
{

    Transform perent;
    private void Awake()
    {
        perent = GetComponent<Transform>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Buy_Active_Button()
    {
        perent.GetChild(0).gameObject.SetActive(false);
        perent.GetChild(2).gameObject.SetActive(false);
        perent.GetChild(3).gameObject.SetActive(true);

    }
    public void Buy_Active_Button_UnActive()
    {
        perent.GetChild(3).gameObject.SetActive(false);
        perent.GetChild(2).gameObject.SetActive(true);
        perent.GetChild(0).gameObject.SetActive(true);

    }

    public void Robby_Buy_Button()
    {
        //해당 오브젝트 인스턴트에 넣기
     
        
    }
}
