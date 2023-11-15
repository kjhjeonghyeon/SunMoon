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
    // 이름, 레벨, 코인, 착용중인 무기
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
    // 이름, 레벨, 코인, 착용중인 무기
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
    // 이름, 레벨, 코인, 착용중인 무기
    public string name = "Coin";
    public int coin=-10000;

}
public class FoodData
{

    public string name;
    public string foodtype;
    public int price;



}

//DAta 종류
//Point
//Coin
//Food

public class DataManager : MonoBehaviour
{
    public static DataManager instance; // 싱글톤패턴

    public PointData nowPoint = new PointData(); // 플레이어 데이터 생성
    public CoinData nowCoin = new CoinData();
    public FoodData nowFood = new FoodData();

    public RobbyDatas robbyDatas = new RobbyDatas();
    //   public List<RobbyData> robbyList=new List<RobbyData>();

    //public RobbyData nowRobby = new RobbyData();






    // string path_Point; // 경로
    string path_Point_; // 경로
                        //  string path_Robby; // 경로
    string path_Robby_; // 경로
    string path_Coin_; // 경로
    string path_; // 경로


    //  public int nowSlot = 0; // 현재 슬롯번호

    private void Awake()
    {
        // nowRobbyList = new List<RobbyData>();







        #region 싱글톤
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

        // path_Point_ = "D:\\github\\SunMoon\\Assets\\Resourse\\SaveData" + "Point" + ".json";	// 경로 지정
        //  path_Point = "E:\\github\\SunMoon\\Assets\\Resourse\\SaveData" + "Point" + ".json";	// 경로 지정
        //path_Point = "E:\\github\\SunMoon\\Assets\\Resourse";	// 경로 지정
        //  path_Robby_ = "D:\\github\\SunMoon\\Assets\\Resourse"; // 경로 지정
        // path_Robby = "E:\\github\\SunMoon\\Assets\\Resourse"; // 경로 지정
        path_ = UnityEngine.Application.persistentDataPath; // 경로 지정
      
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
        //    Debug.Log("robbyList 없음");

        //}

        //if (robbyDatas != null)
        //{



        //}
        //else
        //{
        //    Debug.Log("없구나");
        //}

        //for (int a = 0; a < 5; a++)
        //{
        //    nowRobby = JsonUtility.FromJson<RobbyData>(robbyData);

        //    robbyList[a] = nowRobby;
        //}

    }
}