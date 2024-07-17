using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net.Mime;
using TMPro;
using UnityEngine.SceneManagement;


public class SelectPuzzleLevel : MonoBehaviour
{
    public GameData gameData;
    public GameLevelData gameLevelData;
    public TextMeshProUGUI catergoryText;
    public Image progressbarfilling;

    private string gameSceneName = "GameScene";

    private bool levelLocked;

    void Start()
    {
        levelLocked = false;
        var button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
        UpdateButtonInformation();
        if (levelLocked)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void UpdateButtonInformation()
    {
        var currentIndex = -1;
        var totalBoards = 0;

        foreach (var data in gameLevelData.data)
        {
            if(data.CategoryName == gameObject.name)
            {
                currentIndex =DataSaver.ReadCategoryCurrentIndexValues(gameObject.name);
                totalBoards = data.boardData.Count;

                if (gameLevelData.data[0].CategoryName == gameObject.name && currentIndex <0)
                {
                    DataSaver.SaveCategoryData(gameLevelData.data[0].CategoryName,0);
         
                    currentIndex = DataSaver.ReadCategoryCurrentIndexValues(gameObject.name);
                    totalBoards =data.boardData.Count;
                }
            }
        }

        if (currentIndex == -1)
        {
            levelLocked =true;
        }

        catergoryText.text =levelLocked ? string.Empty :(currentIndex.ToString() + "/" + totalBoards.ToString());
        progressbarfilling.fillAmount =(currentIndex >0 && totalBoards > 0) ? ((float)currentIndex/(float)totalBoards) :0f;

    }
    private void OnButtonClick()
    {
        gameData.selectedCategoryName = gameObject.name;
        SceneManager.LoadScene(gameSceneName);  
    }
}
