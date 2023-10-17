using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foreverAlifeObject : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        //if (GameObject.Find("GameManager").gameObject)
        //{

        //GameObject bugGamemanager = GameObject.Find("GameManager");
        //    Debug.Log("버그게임오브젝트 발견 그리고 삭제");
        //    Destroy(bugGamemanager);
        //}
    

    }
    // Start is called before the first frame update
    void Start()
    {


        //if (GameObject.Find("GameManager") == null)
        //{
        //    DontDestroyOnLoad(gameObject);

        //}
        //else
        //{
        //    Debug.Log("버그게임오브젝트 발견함 문제확인 후 직접해결바람");
        //}
       
    }

    // Update is called once per frame
    void Update()
    {

    }
}
