using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectToRobbyFromScene : MonoBehaviour, IPointerClickHandler
{

    Butten butten;
    public int goScene;
    // Start is called before the first frame update
    void Start()
    {

        butten = new Butten();

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void OnPointerClick(PointerEventData eData)
    {
        Debug.Log(1);

        if (eData.clickCount == 2)
        {
            Debug.Log("double click!");
            butten.goScene = goScene;
            butten.nextSceneButten();

        }


    }


}
