using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundToggle : MonoBehaviour
{

    public enum ButtonType
    {
        BackgroundMusic,
        SoundFx
    }
    public ButtonType Type;
    public Sprite onSprite;
    public Sprite offSprite;

    public GameObject button;
    public Vector3 offButtonPosition;
    private Vector3 onButtonPosition;
    private Image image;


    void Start()
    {
        image = GetComponent<Image>();
        image.sprite = onSprite;
        onButtonPosition = button.GetComponent<RectTransform>().anchoredPosition;
        ToggleButton();
    }
    public void ToggleButton()
    {
        var muted = false; 
        if(Type == ButtonType.BackgroundMusic)
        {
            muted = SoundManager.instance.IsBackgroundMusicMuted();
        }
        else
        {
            muted = SoundManager.instance.IsSoundFxMuted();
        }

        if(muted)
        {
            image.sprite = offSprite;
            button.GetComponent<RectTransform>().anchoredPosition= offButtonPosition;
        }
        else
        {
            image.sprite = onSprite;
            button.GetComponent<RectTransform>().anchoredPosition = onButtonPosition;
        }
    }

 
}
