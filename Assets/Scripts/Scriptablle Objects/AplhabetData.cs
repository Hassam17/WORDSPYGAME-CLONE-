using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class AplhabetData : ScriptableObject

{
    [System.Serializable]

    public class letterData
    {
        public string letter;
        public Sprite image;
    }
    public List<letterData> AlphabetPlain = new List<letterData>();
    public List<letterData> AlphabetNormal = new List<letterData>();
    public List<letterData> AlphabetHighlighted = new List<letterData>();
    public List<letterData> AlphabetWrong = new List<letterData>();


}
