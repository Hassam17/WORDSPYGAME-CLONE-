using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordsGrid : MonoBehaviour
{
    public GameData CurrentGame;
    public GameObject gridsquarePrefab;
    public AplhabetData alphabetdata;
    public float squareOffset = 0.0f;
    public float topPosition;

    private List<GameObject> _squareList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        SpawnGridSquare();
        SetSquarePositon();

    }
    private void SetSquarePositon()
    {
        var squareRect = _squareList[0].GetComponent<SpriteRenderer>().sprite.rect;
        var squareTransform = _squareList[0].GetComponent<Transform>();

        var offset = new Vector2
        {
            x = (squareRect.width * squareTransform.localScale.x + squareOffset) * 0.01f,
        y = (squareRect.height * squareTransform.localScale.y + squareOffset) * 0.01f
        };

        var startPosition = GetFirstSquarePosition();
        int columnNuumber = 0;
        int rowNumber = 0;
        foreach (var square in _squareList)
        {
            if(rowNumber +1 > CurrentGame.selectedBoardData.Rows)
            {
                columnNuumber++;
                rowNumber = 0;
            }
            var positionX = startPosition.x + offset.x *columnNuumber;
            var positionY = startPosition.y- offset.y* rowNumber;
            square.GetComponent<Transform>().position = new Vector2(positionX, positionY);
            rowNumber++;
        }
    }
        
      private Vector2 GetFirstSquarePosition()
    {
        var startposition = new Vector2(0f, transform.position.y);
        var squareRect = _squareList[0].GetComponent<SpriteRenderer>().sprite.rect;
        var squareTransform = _squareList[0].GetComponent<Transform>();
        var squareSize = new Vector2(0f, 0f);

        squareSize.x = squareRect.width* squareTransform.localScale.x;
        squareSize.y=squareRect.height* squareTransform.localScale.y;

        var midWidthPosition = (((CurrentGame.selectedBoardData.Columns - 1) * squareSize.x) / 2) * 0.01f;
        var midWidthHeight = (((CurrentGame.selectedBoardData.Rows - 1) * squareSize.y) / 2) * 0.01f;

        startposition.x = (midWidthPosition != 0) ? midWidthPosition * -1: midWidthPosition;
        startposition.y += midWidthHeight;

        return startposition;
    }


    private void SpawnGridSquare()
    {
        if (CurrentGame != null)
        {
            var squareScale = GetSquareScale(new Vector3(1.5f, 1.5f, 0.1f));
            foreach (var squares in CurrentGame.selectedBoardData.Board)
            {
                foreach (var squareletter in squares.Row)
                {
                    var normalletterData = alphabetdata.AlphabetNormal.Find(data => data.letter == squareletter);
                    var highlightedletterData = alphabetdata.AlphabetHighlighted.Find(data => data.letter == squareletter);
                    var correctletterData = alphabetdata.AlphabetWrong.Find(data => data.letter == squareletter);

                    if (normalletterData.image == null || highlightedletterData.image == null)
                    {
                        Debug.LogError(
                            "All fields in your array should have some letters. Please fill up with random button in your board to add random letter. letter: " + squareletter);
#if UNITY_EDITOR
                        if (UnityEditor.EditorApplication.isPlaying)
                        {
                            UnityEditor.EditorApplication.isPlaying = false;
                        }
#endif
                    }
                    else
                    {
                        _squareList.Add(Instantiate(gridsquarePrefab));
                        _squareList[_squareList.Count -1].GetComponent<GridSquare>().SetSprite(normalletterData,correctletterData,highlightedletterData);
                        _squareList[_squareList.Count - 1].transform.SetParent(this.transform);
                        _squareList[_squareList.Count - 1].GetComponent<Transform>().position = new Vector3 (0f,0f,0f);
                        _squareList[_squareList.Count - 1].transform.localScale = squareScale;
                        _squareList[_squareList.Count - 1].GetComponent<GridSquare>().SetIndex(_squareList.Count - 1);

                    }
                }
            }
        }
    }

    private Vector3 GetSquareScale(Vector3 defaultScale)
    {
        var finalScale = defaultScale;
        var adjustment = 0.01f;

        while (shouldScaleDown(finalScale))
        {
            finalScale.x -= adjustment;
            finalScale.y -= adjustment;

            if (finalScale.x <= 0 || finalScale.y <= 0)
            {
                finalScale.x = adjustment;
                finalScale.y = adjustment;
                return finalScale;
            }
        }
        return finalScale;
    }

    private bool shouldScaleDown(Vector3 targetScale)
    {
        var squareRect = gridsquarePrefab.GetComponent<SpriteRenderer>().sprite.rect;
        var squareSize = new Vector2(0f, 0f);
        var startPosition = new Vector2(0f, 0f);

        squareSize.x = (squareRect.width - targetScale.x) * squareOffset;
        squareSize.y = (squareRect.height - targetScale.y) * squareOffset;

        var midWidthPosition = ((CurrentGame.selectedBoardData.Columns * squareSize.x) / 2) * 0.01f;
        var midWidthHeight = ((CurrentGame.selectedBoardData.Rows * squareSize.y) / 2) * 0.01f;
        startPosition.x = (midWidthPosition != 0) ? midWidthPosition * -1 : midWidthPosition;
        startPosition.y = midWidthHeight;

        return startPosition.x < GetHalfScreenWidth() * -1 || startPosition.y > topPosition;
    }

    private float GetHalfScreenWidth()
    {
        float height = Camera.main.orthographicSize * 2;
        float width = (1.7f * height) * Screen.width / Screen.height;
        return width / 2;
    }
}
