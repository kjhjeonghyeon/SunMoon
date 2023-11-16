using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Rendering;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Toon.Universal.Samples;
using UnityEngine.UIElements;

public class House_PlayerMove : MonoBehaviour

{
    Rigidbody rb;

    private float speed = 0.9f;
    Animator anim;
   // public GameObject direction;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move();

    }


    private void move()
    {
        float speed = 2f;
        Vector3 v_v;
        v_v.x = Input.GetAxis("Horizontal");
        v_v.z = Input.GetAxis("Vertical");


        //Vector3 Angle= new Vector3(0, 30, 0);
        //Vector3 Angle_B= new Vector3(0, 180, 0);
        //Vector3 direter= new Vector3(0, 30, 0);

        // transform.position+= new Vector3(v_v.x, 0, v_v.z) * speed * Time.deltaTime;

        //if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftControl))
        //{

        //  //  transform.Rotate(new Vector3(0, 1 * 0.5f, 0), Space.World);
        //   transform.rotation= Quaternion.Euler(directer_R);
        //}
        //else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.LeftControl))
        //{
        //    //transform.Rotate(new Vector3(0, -1 * 0.5f, 0), Space.World);
        //    transform.rotation = Quaternion.Euler(directer_L);
        //}
        //if(Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftControl))
        //{
        //   transform.rotation= Quaternion.Euler(directer_F);

        //}
        //else if(Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftControl))
        //{
        //   transform.rotation= Quaternion.Euler(directer_B);

        //}

        //  if (Input.anyKey)
        //  {
        //      float a = 0;
        //      a+=10;

        //      transform.rotation = Quaternion.Lerp(Quaternion.identity, Quaternion.Euler(0, a * v_v.x, 0), 5f);
        ////  Quaternion togat= Quaternion.LookRotation()
        //  }
        anim.SetFloat("X", Input.GetAxis("Horizontal"));
        anim.SetFloat("Y", Input.GetAxis("Vertical"));

        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Rotate(new Vector3(0, v_v.x, 0), 2);


        }
        //    GetComponent<Rigidbody>().velocity = new Vector3(v_v.x, 0, v_v.z) * speed;
        if (Input.GetKey(KeyCode.UpArrow) )
        {

            transform.Translate(transform.forward * speed * Time.deltaTime,Space.World);


        }
        else if (Input.GetKey(KeyCode.DownArrow) )
        {
            transform.Translate(transform.forward * speed * -1 * Time.deltaTime,Space.World);
        }



       
    }



}


