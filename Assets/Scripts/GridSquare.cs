 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSquare : MonoBehaviour
{
    public int SquareIndex {get; set;}
    private AplhabetData.letterData _normaLLetterData;
    private AplhabetData.letterData _selectedLLetterData;
    private AplhabetData.letterData _correctLetterData;

    private SpriteRenderer _dipslayImage;

    private bool _selected;
    private bool _clicked;
    private int _index = -1;
    private bool _correct;
    private AudioSource _soundSource;
    public void SetIndex(int index)
    {
        _index = index;
    }

    public int GetIndex() 
    { 
        return _index;
    }    
    void Start()
    {
        _selected = false;
        _clicked = false;
        _dipslayImage = GetComponent<SpriteRenderer>();
        _correct = false;
        _soundSource = GetComponent<AudioSource>();


    }

    private void OnEnable()
    {
        GameEvents.OnEnableSquareSelection += OnEnableSquareSelection;
        GameEvents.OnDisableSquareSelection += OnDisableSquareSelection;
        GameEvents.OnSelectSquare += SelectSquare;
        GameEvents.OnCorrectWord += CorrectWord;

    }
    private void OnDisable()
    {

        GameEvents.OnEnableSquareSelection -= OnEnableSquareSelection;
        GameEvents.OnDisableSquareSelection -= OnDisableSquareSelection;
        GameEvents.OnSelectSquare -= SelectSquare;
        GameEvents.OnCorrectWord -= CorrectWord;
    }
    private void CorrectWord(string word,List<int> squareIndexes)
    {
        if(_selected && squareIndexes.Contains(_index))
        {
            _correct = true;
            _dipslayImage.sprite = _correctLetterData.image;
        }
        _selected = false;
        _clicked = false;
    }
    public void OnEnableSquareSelection()
    {
        _clicked = true;
        _selected = false;
    }
    private void OnDisableSquareSelection()
    {
        _clicked = false;
        _selected = false;

        if (_correct == true)
            _dipslayImage.sprite = _correctLetterData.image;
        else
            _dipslayImage.sprite = _normaLLetterData.image;
        
            
        

    }
    private void SelectSquare(Vector3 position)
    {
        if (this.gameObject.transform.position == position)
            _dipslayImage.sprite = _selectedLLetterData.image;
    }

    public void SetSprite(AplhabetData.letterData normaLLetterData, AplhabetData.letterData selectedLetterData, AplhabetData.letterData correctLetterData)
    {
        _normaLLetterData = normaLLetterData;
        _selectedLLetterData = selectedLetterData;
        _correctLetterData = correctLetterData;

        GetComponent<SpriteRenderer>().sprite = _normaLLetterData.image;

    }

    private void OnMouseDown()
    {
        OnEnableSquareSelection();
        GameEvents.EnableSquareSelectionMethod();
        CheckSquare();
        _dipslayImage.sprite = _selectedLLetterData.image;

    }
    private void OnMouseEnter()
    {
        CheckSquare();

    }
    private void OnMouseUp()
    {
        GameEvents.ClearSelectionMethod();
        GameEvents.DisableSquareSelectionMethod();
       
    }
    public void CheckSquare()
    {
        if(_selected == false && _clicked == true)
        {
            if(SoundManager.instance.IsSoundFxMuted()== false)
            {
                _soundSource.Play();
            }
            _selected = true;
            GameEvents.CheckSquareMethod(_normaLLetterData.letter,gameObject.transform.position,_index);

        }
    }
    
}
