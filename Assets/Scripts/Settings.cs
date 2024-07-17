using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public GameLevelData levelData;

    public void ClearData()
    {
        DataSaver.ClearGameData(levelData);
    }
}
