using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing;
using UnityEngine.UI;
using UnityEngine.Device;

[System.Serializable]
public class PointData
{
    // �̸�, ����, ����, �������� ����
    public string name = "Point";
    public int point=-10000;


}

[System.Serializable]
public class RobbyDatas
{
    public List<RobbyData> robbyData = new List<RobbyData>();
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

[System.Serializable]
public class CoinData
{
    // �̸�, ����, ����, �������� ����
    public string name = "Coin";
    public int coin=-10000;

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






    // string path_Point; // ���
    string path_Point_; // ���
                        //  string path_Robby; // ���
    string path_Robby_; // ���
    string path_Coin_; // ���
    string path_; // ���


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

        // path_Point_ = "D:\\github\\SunMoon\\Assets\\Resourse\\SaveData" + "Point" + ".json";	// ��� ����
        //  path_Point = "E:\\github\\SunMoon\\Assets\\Resourse\\SaveData" + "Point" + ".json";	// ��� ����
        //path_Point = "E:\\github\\SunMoon\\Assets\\Resourse";	// ��� ����
        //  path_Robby_ = "D:\\github\\SunMoon\\Assets\\Resourse"; // ��� ����
        // path_Robby = "E:\\github\\SunMoon\\Assets\\Resourse"; // ��� ����
        path_ = UnityEngine.Application.persistentDataPath; // ��� ����
      
        path_Point_ = path_;
        path_Robby_ = path_;
        path_Coin_ = path_;

    }
    public void SaveDataPoint()
    {


        string pointData = JsonUtility.ToJson(nowPoint, true);
        string path = Path.Combine(path_Point_, "SaveDataPoint.json");
        File.WriteAllText(path, pointData);
    }
    public void LoadDataPoint()
    {

        string path = Path.Combine(path_Point_, "SaveDataPoint.json");
        string poinData = File.ReadAllText(path);
        Debug.Log(path);
        nowPoint = JsonUtility.FromJson<PointData>(poinData);
    }





    public void SaveDataCoin()
    {


        string coinData = JsonUtility.ToJson(nowCoin, true);
        string path = Path.Combine(path_Coin_, "SaveDataCoin.json");
        File.WriteAllText(path, coinData);
    }
    public void LoadDataCoin()
    {


        string path = Path.Combine(path_Coin_, "SaveDataCoin.json");
        string coinData = File.ReadAllText(path);

        nowCoin = JsonUtility.FromJson<CoinData>(coinData);
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