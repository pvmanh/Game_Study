using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageView
{
    //tinh thong so image de cat
    public static float[] CaculatorSliptImageValue(float[] imageValue, PuzzleModel puzzleData)
    {
        imageValue = new float[2];
        imageValue[0] = 1f / puzzleData.Width;
        imageValue[1] = 1f / puzzleData.Height;
        return imageValue;
    }
    //ham cat anh
    public static void SliptImage(ImageModel imageData, PuzzleModel puzzleData, float[] imageValue, List<RawImage> BasePuzzleObject, Texture2D BaseImage)
    {
        imageValue = CaculatorSliptImageValue(imageValue, puzzleData);
        //lay thong so tinh dc
        imageData.WidthValue = imageValue[0];
        imageData.HeightValue = imageValue[1];
        //thong so dau vao
        imageData.x = 0f;
        imageData.y -= imageData.HeightValue;

        int k = 0;

        for (int i = 0; i < puzzleData.Height; i++)
        {
            for (int j = 0; j < puzzleData.Width; j++)
            {
                //phong hinh theo thong so tinh dc
                BasePuzzleObject[k].texture = BaseImage;
                BasePuzzleObject[k].uvRect = new Rect(imageData.x, imageData.y, imageData.WidthValue, imageData.HeightValue);
                BasePuzzleObject[k].GetComponent<ImgControl>().TagValueImg = k;
                //thong so theo cot
                imageData.x += imageData.WidthValue;
                k++;
            }
            //thong so theo hangg
            imageData.y -= imageData.HeightValue;
            imageData.x = 0f;
        }
    }
    //ham them texture
    public static void RandomNumberTexture(TextureModel textureData)
    {
        for (int h = 0; h < textureData.TexturePuzzle.Length; h++)
        {
            textureData.NumRandomTexture.Add(h);
        }
    }
    //Ham random texture
    public static void RandomTexture(TextureModel textureData, PuzzleModel puzzleData)
    {
        //random 1 so ngau nhien trong so luong texture count dc - 1
        textureData.ran_Num_Texture = Random.Range(0, (textureData.NumRandomTexture.Count - 1));
        //lay hinh random tai vi tri random dc gan va list
        textureData.list_Texture[puzzleData.level - 1] = textureData.NumRandomTexture[textureData.ran_Num_Texture];
        //xoa so random dc 
        textureData.NumRandomTexture.RemoveAt(textureData.ran_Num_Texture);
    }
    //gan hinh vao rawimage
    public static void LoadRawTexture(RawImage img, Texture2D texture)
    {
        img.texture = texture;
    }
}
