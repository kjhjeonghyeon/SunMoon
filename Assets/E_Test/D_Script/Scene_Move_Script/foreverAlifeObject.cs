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
        //    Debug.Log("���װ��ӿ�����Ʈ �߰� �׸��� ����");
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
        //    Debug.Log("���װ��ӿ�����Ʈ �߰��� ����Ȯ�� �� �����ذ�ٶ�");
        //}
       
    }

    // Update is called once per frame
    void Update()
    {

    }
}
