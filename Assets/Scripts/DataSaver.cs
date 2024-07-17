using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSaver : MonoBehaviour
{
   public static int ReadCategoryCurrentIndexValues(string name)
    {
        var value = -1;
        if (PlayerPrefs.HasKey(name))
        {
            value = PlayerPrefs.GetInt(name);
        }
        return value;
    }

    public static void SaveCategoryData(string catergoryName,int currentIndex)
    {
        PlayerPrefs.SetInt(catergoryName, currentIndex);
        PlayerPrefs.Save();
    }
    public static void ClearGameData(GameLevelData gameLevelData)
    {
        foreach(var data in gameLevelData.data)
        {
            PlayerPrefs.SetInt(data.CategoryName, -1);
        }
        //Unlock the 1st level
        PlayerPrefs.SetInt(gameLevelData.data[0].CategoryName, 0);
        PlayerPrefs.Save();
    }
}
