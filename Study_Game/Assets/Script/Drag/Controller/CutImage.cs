using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutImage : MonoBehaviour
{
    public ImageModel imageData;
    
    LoadPuzzle puzzleData;
    public List<RawImage> BasePuzzleObject = new List<RawImage>();
    float[] imageValue = new float[2];
    // Start is called before the first frame update
    void Start()
    {
        puzzleData = this.GetComponent<LoadPuzzle>();
        //WidthValue = 1f / pLoadPuzzle.Width;
        //HeightValue = 1f / pLoadPuzzle.Height;
        ImageView.CaculatorSliptImageValue(imageValue, puzzleData.puzzleData);
    }

    void Update()
    {
        if(imageData.LoadDone == true)
        {
            ImageView.SliptImage(imageData, puzzleData.puzzleData, imageValue, BasePuzzleObject, imageData.BaseImage);
            imageData.LoadDone = false;
        }
    }
}
