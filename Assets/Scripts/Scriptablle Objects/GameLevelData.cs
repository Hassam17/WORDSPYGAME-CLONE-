using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class GameLevelData : ScriptableObject
{

    [System.Serializable]
    public struct CategoryData
    {
        public string CategoryName;
        public List<BoardData> boardData;
    }
    public List<CategoryData> data;
}
