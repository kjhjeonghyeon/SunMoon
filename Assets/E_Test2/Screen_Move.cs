
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;
using static UnityEngine.EventSystems.PointerEventData;

public class Screen_Move : MonoBehaviour
{

    int horizontal_count_R = 5;
    int horizontal_count_L = 5;

    int veltical_count_B = 5;
    int veltical_count_F = 5;




    CinemachineVirtualCamera v_camera;

    Vector3 origin;

  


    private void Start()
    {
        v_camera = GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>();



        origin = v_camera.transform.position;



    }
    private void Update()
    {


    }


    public void rightmove()
    {
       
        if (horizontal_count_R > 0)
        {

            v_camera.transform.position = Vector3.MoveTowards(v_camera.transform.position, new Vector3(v_camera.transform.position.x + 3, v_camera.transform.position.y, v_camera.transform.position.z), 1f);


            horizontal_count_R--;
            horizontal_count_L++;



        }





    }


    public void lefttmove()
    {
       
        if (horizontal_count_L > 0)
        {
            v_camera.transform.position = Vector3.MoveTowards(v_camera.transform.position, new Vector3(v_camera.transform.position.x - 3, v_camera.transform.position.y, v_camera.transform.position.z), 1f);


            horizontal_count_R++;
            horizontal_count_L--;
        }





    }
    public void Backmove()
    {
       
        if (veltical_count_B > 0)
        {

            v_camera.transform.position = Vector3.MoveTowards(v_camera.transform.position, new Vector3(v_camera.transform.position.x, v_camera.transform.position.y, v_camera.transform.position.z + 10), 1f);
            veltical_count_B--;
            veltical_count_F++;
        }


    }
    public void fowardmove()
    {
       
        if (veltical_count_F > 0)
        {

            v_camera.transform.position = Vector3.MoveTowards(v_camera.transform.position, new Vector3(v_camera.transform.position.x, v_camera.transform.position.y, v_camera.transform.position.z - 10), 1f);
            veltical_count_B++;
            veltical_count_F--;
        }


    
    }





   

}