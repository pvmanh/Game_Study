using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadPuzzle : MonoBehaviour
{
    public PuzzleModel puzzleData;
    public TextureModel textureData;
    public TimeModel timeData;
    ImageModel imageData;
    CutImage BaseImage;
    // Start is called before the first frame update
    void Start()
    {
        timeData.timegget = timeData.txt_time.text;
        timeData.timeToDisplay = Time.time;

        textureData.list_Texture = new int[textureData.TexturePuzzle.Length];

        Image.RandomNumberTexture(textureData);
        imageData = this.gameObject.GetComponent<CutImage>().imageData;
        BaseImage = this.gameObject.GetComponent<CutImage>();

        puzzleData.txt_level = GameObject.Find("txt-level").GetComponent<TextMeshProUGUI>();

        Puzzle.LoadPuzzleLevel(puzzleData, textureData, imageData, BaseImage.BasePuzzleObject);
    }

    // Update is called once per frame
    void Update()
    {
        Puzzle.CheckWinPuzzle(puzzleData, textureData, imageData, BaseImage.BasePuzzleObject);
    }

    void FixedUpdate()
    {
        Timer.TimeClock(timeData);
    }
}
