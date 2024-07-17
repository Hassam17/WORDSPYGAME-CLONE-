using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPopup : MonoBehaviour
{
    public GameObject winPopup;

    void Start()
    {
        winPopup.SetActive(false);
    }

    private void OnEnable()
    {
        GameEvents.OnBoardCompleted += ShowWinPopup;
    }

    private void OnDisable()
    {
        GameEvents.OnBoardCompleted -= ShowWinPopup;
    }

    private void ShowWinPopup()
    {
        StartCoroutine(ShowWinPopupWithDelay());
    }

    private IEnumerator ShowWinPopupWithDelay()
    {
        yield return new WaitForSeconds(3f);
        winPopup.SetActive(true);
    }

    public void LoadNextLevel()
    {
        GameEvents.LoadNextLevelMethod();
    }
}
