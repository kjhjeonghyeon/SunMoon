using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    List<GameObject> managerList = new List<GameObject>();
    // Start is called before the first frame update
    private void Awake()
    {


    }

    void Start()
    {

        managerList.Add(gameObject.GetComponentInChildren<GameObject>().gameObject);


        





    }

    // Update is called once per frame
    void Update()
    {

        SceneNowNumber();

    }


    void SceneNowNumber()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            managerList[0].SetActive(false);
            managerList[1].SetActive(true);
        }
        else
        {
            managerList[0].SetActive(true);
            managerList[1].SetActive(false);
        }

    }


}
