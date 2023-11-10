
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class Screen_Move : MonoBehaviour
{
    CinemachineVirtualCamera v_camera;
    Vector3 origin;

    private void Start()
    {
        v_camera= GameObject.FindAnyObjectByType<CinemachineVirtualCamera>();
        origin= v_camera.transform.position;
    }
    private void Update()
    {
    }
public void rightmove()
    {

        v_camera.transform.position = Vector3.MoveTowards(v_camera.transform.position ,new Vector3(v_camera.transform.position.x+3 , v_camera.transform.position.y, v_camera.transform.position.z),1f);
    }
    public void lefttmove()
    {

        v_camera.transform.position = Vector3.MoveTowards(v_camera.transform.position, new Vector3(v_camera.transform.position.x-3 , v_camera.transform.position.y, v_camera.transform.position.z),1f);
    }
    public void Backmove()
    {

        v_camera.transform.position = Vector3.MoveTowards(v_camera.transform.position, new Vector3(v_camera.transform.position.x , v_camera.transform.position.y, v_camera.transform.position.z+10), 1f);
    }
    public void fowardmove()
    {

        v_camera.transform.position = Vector3.MoveTowards(v_camera.transform.position, new Vector3(v_camera.transform.position.x, v_camera.transform.position.y, v_camera.transform.position.z - 10), 1f);
    }

}