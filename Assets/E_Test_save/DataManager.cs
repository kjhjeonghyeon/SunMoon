using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing;

public class PointData
{
    // �̸�, ����, ����, �������� ����
    public string name;
    public int point;


}
public class RobbyData
{
    // �̸�, ����, ����, �������� ����
    public string hexname;
    public Vector3 position;

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
    public RobbyData nowRobby = new RobbyData();

    string path_Point; // ���
    string path_Robby; // ���


    //  public int nowSlot = 0; // ���� ���Թ�ȣ

    private void Awake()
    {
       
       
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

        path_Point = "D:\\github\\SunMoon\\Temp\\SaveData/" + "Point" + ".json";	// ��� ����
        path_Robby = "D:\\github\\SunMoon\\Temp\\SaveData/" + "Robby" + ".json";	// ��� ����
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
    public bool SaveDataPoint_bool()
    {
        string pointData = JsonUtility.ToJson(nowPoint);
        File.WriteAllText(path_Point, pointData);


        if (pointData == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }




    //public void SaveDataRobby()
    //{
    //    string robbyData = JsonUtility.ToJson(nowRobby);
    //    File.WriteAllText(path_Robby, robbyData);
    //}
    //public void LoadDataRobby()
    //{
    //    string robbyData = File.ReadAllText(path_Robby);
    //    nowRobby = JsonUtility.FromJson<RobbyData>(robbyData);
    //}
    //public bool LoadDataRobby_bool()
    //{
    //    string robbyData = File.ReadAllText(path_Robby);
    //    nowRobby = JsonUtility.FromJson<RobbyData>(robbyData);

    //    if (robbyData == null)
    //    {
    //        return false;
    //    }
    //    else
    //    {
    //        return true;
    //    }
    //}
}