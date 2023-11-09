using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing;

public class PointData
{
    // 이름, 레벨, 코인, 착용중인 무기
    public string name;
    public int point;


}
public class RobbyData
{
    // 이름, 레벨, 코인, 착용중인 무기
    public string hexname;
    public Vector3 position;

}
public class CoinData
{
    // 이름, 레벨, 코인, 착용중인 무기
    public string name;
    public int coin;

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

    public string path_Point; // 경로
    public string path_Robby; // 경로


    //  public int nowSlot = 0; // 현재 슬롯번호

    private void Awake()
    {
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

        path_Point = "D:\\github\\SunMoon\\Temp\\SaveData/" + "Point" + ".json";	// 경로 지정
        path_Robby = "D:\\github\\SunMoon\\Temp\\SaveData/" + "Robby" + ".json";	// 경로 지정
    }
    public void SaveDataPoint()
    {
        string pointData = JsonUtility.ToJson(nowPoint);
        File.WriteAllText(path_Point, pointData);
    }
    public void LoadDataPoint()
    {
        string pointData = File.ReadAllText(path_Point);
        nowPoint = JsonUtility.FromJson<PointData>(pointData);
    }





    public void SaveDataRobby()
    {
        string pointData = JsonUtility.ToJson(nowPoint);
        File.WriteAllText(path_Robby, pointData);
    }
    public void LoadDataRobby()
    {
        string pointData = File.ReadAllText(path_Robby);
        nowPoint = JsonUtility.FromJson<PointData>(pointData);
    }
}