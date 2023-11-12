using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing;
using UnityEngine.UI;

public class PointData
{
    // �̸�, ����, ����, �������� ����
    public string name;
    public int point;


}

[System.Serializable]
public class RobbyDatas
{public List<RobbyData> robbyData= new List<RobbyData>();
   // public RobbyData robbyData = new RobbyData();
}

[System.Serializable]
public class RobbyData
{
    // �̸�, ����, ����, �������� ����
    public string hexname;
    public Vector3 position;
    public bool ative;

    //public RobbyData(string hexname, Vector3 position, bool ative)
    //{
    //    this.hexname = hexname;
    //    this.position = position;
    //    this.ative = ative;
    //}


}

public class CoinData
{
    // �̸�, ����, ����, �������� ����
    public string name;
    public int coin;

}
public class FoodData
{

    public string name;
    public string foodtype;
    public int price;



}

//DAta ����
//Point
//Coin
//Food

public class DataManager : MonoBehaviour
{
    public static DataManager instance; // �̱�������

    public PointData nowPoint = new PointData(); // �÷��̾� ������ ����
    public CoinData nowCoin = new CoinData();
    public FoodData nowFood = new FoodData();

    public RobbyDatas robbyDatas = new RobbyDatas();
 //   public List<RobbyData> robbyList=new List<RobbyData>();
 
    //public RobbyData nowRobby = new RobbyData();






    string path_Point; // ���
    string path_Point_; // ���
    string path_Robby; // ���
    string path_Robby_; // ���


    //  public int nowSlot = 0; // ���� ���Թ�ȣ

    private void Awake()
    {
        // nowRobbyList = new List<RobbyData>();







        #region �̱���
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        #endregion

        path_Point = "D:\\github\\SunMoon\\Assets\\Resourse\\SaveData" + "Point" + ".json";	// ��� ����
        path_Point_ = "E:\\github\\SunMoon\\Assets\\Resourse\\SaveData" + "Point" + ".json";	// ��� ����
        path_Robby = "D:\\github\\SunMoon\\Assets\\Resourse"; // ��� ����
        path_Robby_ = "E:\\github\\SunMoon\\Assets\\Resourse"; // ��� ����
    
    }
    public void SaveDataPoint()
    {
        string pointData = JsonUtility.ToJson(nowPoint);
        File.WriteAllText(path_Point_, pointData);
    }
    public void LoadDataPoint()
    {
        string pointData = File.ReadAllText(path_Point_);
        nowPoint = JsonUtility.FromJson<PointData>(pointData);
    }





    public void SaveDataRobby()
    {
        string robbyData = JsonUtility.ToJson(robbyDatas, true);
        string path = Path.Combine(path_Robby_, "SaveDataRobby.json");
        File.WriteAllText(path, robbyData);
    }

    public void LoadDataRobby()
    {
        string path = Path.Combine(path_Robby_, "SaveDataRobby.json");
        string robbyData = File.ReadAllText(path);

        //Debug.Log(robbyData);

        
        robbyDatas = JsonUtility.FromJson<RobbyDatas>(robbyData);

        //for (int i = 0; i < 6; i++)
        //{
        //    // DataManager.instance.robbyList.Clear(); 


        //    DataManager.instance.robbyDatas.robbyData.Add(DataManager.instance.robbyList[i]);
        //    DataManager.instance.robbyList.Add(DataManager.instance.robbyList[i]);
        //}
            //if (robbyList.Count != 0)
            //{

            //for(int i=0; i < robbyList.Count; i++)
            //{
            //    robbyDatas.robbyData.Add(robbyList[i]);
            //}
            //}
            //else
            //{
            //    Debug.Log("robbyList ����");

            //}

            //if (robbyDatas != null)
            //{



            //}
            //else
            //{
            //    Debug.Log("������");
            //}

            //for (int a = 0; a < 5; a++)
            //{
            //    nowRobby = JsonUtility.FromJson<RobbyData>(robbyData);

            //    robbyList[a] = nowRobby;
            //}

        }
    }