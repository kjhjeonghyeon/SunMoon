using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    GameObject[] gamobj = new GameObject[12];
    float subface = 0.5f;
    float dot = 0.57f;
    public GameObject gameObject1;
    // Start is called before the first frame update

    void Start()
    {
        //gamobj[3] = Instantiate(gameObject1, new Vector3(0, 0, subface * 2), Quaternion.identity);
        //gamobj[9] = Instantiate(gameObject1, new Vector3(0, 0, subface * 2), Quaternion.identity);

        //gamobj[1] = Instantiate(gameObject1, new Vector3(dot * 2, 0, subface), Quaternion.identity);
        //gamobj[4] = Instantiate(gameObject1, new Vector3(-dot * 2, 0, -subface), Quaternion.identity);
        //gamobj[7] = Instantiate(gameObject1, new Vector3(-dot * 2, 0, subface), Quaternion.identity);
        //gamobj[10] = Instantiate(gameObject1, new Vector3(dot * 2, 0, -subface), Quaternion.identity);

        //gamobj[0] = Instantiate(gameObject1, new Vector3(dot * 3, 0, 0), Quaternion.identity);
        //gamobj[6] = Instantiate(gameObject1, new Vector3(dot * 3, 0, 0), Quaternion.identity);

        //gamobj[2] = Instantiate(gameObject1, new Vector3(dot * 2, 0, subface * 3), Quaternion.identity);
        //gamobj[5] = Instantiate(gameObject1, new Vector3(-dot * 2, 0, -subface * 3), Quaternion.identity);
        //gamobj[8] = Instantiate(gameObject1, new Vector3(-dot * 2, 0, subface * 3), Quaternion.identity);
        //gamobj[11] = Instantiate(gameObject1, new Vector3(dot * 2, 0, -subface * 3), Quaternion.identity);


        gamobj[3] =  Instantiate(gameObject1, new Vector3(subface *2f ,0, dot*0)      ,Quaternion.identity);
        gamobj[9] =  Instantiate(gameObject1, new Vector3(subface *-2f,0, dot *0), Quaternion.identity);


        gamobj[1] =  Instantiate(gameObject1, new Vector3(subface *3f ,0, dot *1 + subface*0.5f)      ,Quaternion.identity);
        gamobj[4] =  Instantiate(gameObject1, new Vector3(subface *-3f,0,+dot *1 + subface * 0.5f)      ,Quaternion.identity);
        gamobj[7] =  Instantiate(gameObject1, new Vector3(subface *-3f,0,-dot *1- subface * 0.5f)      ,Quaternion.identity);
        gamobj[10] = Instantiate(gameObject1, new Vector3(subface *3f ,0,- dot *1 - subface * 0.5f), Quaternion.identity);

        gamobj[2] =  Instantiate(gameObject1, new Vector3(subface *1 ,0, dot *1 + subface * 0.5f)      ,Quaternion.identity);
        gamobj[5] =  Instantiate(gameObject1, new Vector3(subface *-1,0, dot *1 + subface * 0.5f)      ,Quaternion.identity);
        gamobj[8] =  Instantiate(gameObject1, new Vector3(subface *-1,0,- dot *1 - subface * 0.5f)      ,Quaternion.identity);
        gamobj[11] = Instantiate(gameObject1, new Vector3(subface *1 ,0, -dot *1 - subface * 0.5f),Quaternion.identity);

        gamobj[0] =  Instantiate(gameObject1, new Vector3(subface *0 ,0, dot*3   )   ,Quaternion.identity);
        gamobj[6] =  Instantiate(gameObject1, new Vector3(subface *0 ,0, -dot*3  ), Quaternion.identity);


       

    }

    // Update is called once per frame
    void Update()
    {
    }
}
