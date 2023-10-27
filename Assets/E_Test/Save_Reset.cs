using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;
using UnityEngine.UIElements;

//public class Save_Reset : MonoBehaviour
//{

//    public GameObject[] Hex;
//    public GameObject background;
//    // Start is called before the first frame update
//    void Start()
//    {
//        road();
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }

//    public void reset()
//    {


//        if (DataManager.instance.filename("save_hex") == "save_hex")
//        {

//            File.Delete(DataManager.instance.filename("save_hex"));
//        }
//    }

//    public void save()
//    {
//        DataManager.instance.fileNameSting = "save_hex";
//        DataManager.instance.nowOBJ.Hex_robby_objCount = GameObject.Find("Array_Hex_Group(Clone)").transform.childCount;
//        if (DataManager.instance.nowOBJ.Hex_robby_objCount < 10)
//        {

//            for (int a = 1; a <= GameObject.Find("Array_Hex_Group(Clone)").transform.childCount; a++)
//            {

//                Hex[a] = Instantiate(GameObject.Find("Array_Hex_Group(Clone)").transform.GetChild(a).gameObject, GameObject.Find("Array_Hex_Group(Clone)").transform);

//                DataManager.instance.nowOBJ.hex[a] = Hex[a];
//            }

//        }
//        else
//        {
//            Debug.Log("설치안되 레벨업해야 설치할수있어");
//        }

//        DataManager.instance.save();
//        Debug.Log(DataManager.instance.nowOBJ.hex[2].name);
//    }
//    public void road()
//    {
//        DataManager.instance.fileNameSting = "save_hex";
//        DataManager.instance.nowOBJ.hex[0] = background;

//        DataManager.instance.road();
//        if (DataManager.instance.nowOBJ.hex[0] != null)
//            {

//            for (int a = 0; a < GameObject.Find("Array_Hex_Group(Clone)").transform.childCount; a++)
//            {
//                Instantiate(DataManager.instance.nowOBJ.hex[a]);
//            }
//        }
//    }
//}

