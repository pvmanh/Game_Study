using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageView
{
    public static float[] CaculatorSliptImageValue(float[] imageValue, PuzzleModel puzzleData)
    {
        imageValue = new float[2];
        imageValue[0] = 1f / puzzleData.Width;
        imageValue[1] = 1f / puzzleData.Height;
        return imageValue;
    }
    public static void SliptImage(ImageModel imageData, PuzzleModel puzzleData, float[] imageValue, List<RawImage> BasePuzzleObject, Texture2D BaseImage)
    {
        imageValue = CaculatorSliptImageValue(imageValue, puzzleData);

        imageData.WidthValue = imageValue[0];
        imageData.HeightValue = imageValue[1];

        imageData.x = 0f;
        imageData.y -= imageData.HeightValue;

        int k = 0;

        for (int i = 0; i < puzzleData.Height; i++)
        {
            for (int j = 0; j < puzzleData.Width; j++)
            {
                BasePuzzleObject[k].texture = BaseImage;
                BasePuzzleObject[k].uvRect = new Rect(imageData.x, imageData.y, imageData.WidthValue, imageData.HeightValue);
                BasePuzzleObject[k].GetComponent<ImgControl>().TagValueImg = k;

                imageData.x += imageData.WidthValue;
                k++;
            }

            imageData.y -= imageData.HeightValue;
            imageData.x = 0f;
        }
    }
    public static void RandomNumberTexture(TextureModel textureData)
    {
        for (int h = 0; h < textureData.TexturePuzzle.Length; h++)
        {
            textureData.NumRandomTexture.Add(h);
        }
    }

    public static void RandomTexture(TextureModel textureData, PuzzleModel puzzleData)
    {
        textureData.ran_Num_Texture = Random.Range(0, (textureData.NumRandomTexture.Count - 1));
        textureData.list_Texture[puzzleData.level - 1] = textureData.NumRandomTexture[textureData.ran_Num_Texture];
        textureData.NumRandomTexture.RemoveAt(textureData.ran_Num_Texture);
    }

    public static void LoadRawTexture(RawImage img, Texture2D texture)
    {
        img.texture = texture;
    }
}
