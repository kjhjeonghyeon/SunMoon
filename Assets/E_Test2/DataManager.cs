using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;


public class OBjData
{

    public int Hex_robby;

   
    



}

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public OBjData nowOBJ=new OBjData();

 

    string path;

   public string fileNameSting ="filename" ;

   public string filename(string filename)
    {
        fileNameSting = filename;
        return fileNameSting;
    }
    // Start is called before the first frame update
    private void Awake()
    {
        #region ΩÃ±€≈Ê
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
         
       DontDestroyOnLoad(gameObject);
        #endregion
        path = Application.persistentDataPath + "/";
        
    }
    void Start()
    {
        
    }

    public void road()
    {
        string data = File.ReadAllText(path + filename(fileNameSting));
        nowOBJ = JsonUtility.FromJson<OBjData>(data);
    }

    public void save()
    {
        string data = JsonUtility.ToJson(nowOBJ);
        File.WriteAllText(path + filename(fileNameSting), data);



        
  
    }

    // Update is called once per frame
    void Update()
    {
         
    }
}
