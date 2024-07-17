using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPopup : MonoBehaviour
{
    public GameObject gameOverPopup;
    public GameObject continueGameAfterAdsButton;

    void Start()
    {
        continueGameAfterAdsButton.GetComponent<Button>().interactable = false;
        gameOverPopup.SetActive(false);

        GameEvents.OnGameOver += ShowGameOverPopup;
    }

    private void OnDisable()
    {
        GameEvents.OnGameOver -= ShowGameOverPopup;
    }

    private void ShowGameOverPopup()
    {
        StartCoroutine(ShowGameOverPopupWithDelay());
    }

    private IEnumerator ShowGameOverPopupWithDelay()
    {
        yield return new WaitForSeconds(3f);
        gameOverPopup.SetActive(true);
        continueGameAfterAdsButton.GetComponent<Button>().interactable = true;
    }
}
