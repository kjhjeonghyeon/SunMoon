
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Screen_Move : MonoBehaviour
{
    int count_R = 6;
    int count_L = 6;
    int count_F = 3;
    int count_B = 3;

    CinemachineVirtualCamera v_camera;
    Vector3 origin;

    private void Start()
    {
        v_camera = GameObject.FindAnyObjectByType<CinemachineVirtualCamera>();
        origin = v_camera.transform.position;
    }
    private void Update()
    {
    }
    public void rightmove()
    {
        if (count_R > 0)
        {
            v_camera.transform.position = Vector3.MoveTowards(v_camera.transform.position, new Vector3(v_camera.transform.position.x + 3, v_camera.transform.position.y, v_camera.transform.position.z), 1f);
                count_R--;
            if (count_L < 13)
            count_L++;
        }
    }
    public void lefttmove()
    {
        if (count_L> 0)
        {
            v_camera.transform.position = Vector3.MoveTowards(v_camera.transform.position, new Vector3(v_camera.transform.position.x - 3, v_camera.transform.position.y, v_camera.transform.position.z), 1f);
            count_L--;
            if (count_R < 13)
                count_R++;
        }
    }
    public void Backmove()
    {
        if (count_B > 0)
        { 
            v_camera.transform.position = Vector3.MoveTowards(v_camera.transform.position, new Vector3(v_camera.transform.position.x, v_camera.transform.position.y, v_camera.transform.position.z + 10), 1f);
            count_B--;
            if (count_F < 7)
                count_F++;


        }
    }
    public void fowardmove()
    {
        if (count_F > 0)
        {
            v_camera.transform.position = Vector3.MoveTowards(v_camera.transform.position, new Vector3(v_camera.transform.position.x, v_camera.transform.position.y, v_camera.transform.position.z - 10), 1f);
            count_F--;
            if (count_B < 7)
                count_B++;
        }
    }

}