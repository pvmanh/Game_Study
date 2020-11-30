using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectView
{
    public static float[] CaculatorValueGrid(float[] Value_Width_Height, ObjectModel ObjectModel)
    {
        Value_Width_Height = new float[2];
        Value_Width_Height[0] = 1f / ObjectModel.Width;
        Value_Width_Height[1] = 1f / ObjectModel.Height;
        return Value_Width_Height;
    }
    public static void SplitGridObject(ObjectModel ObjectModel, GameObject gridObject, float[] value_grid, Transform parent)
    {
        ObjectModel.WidthValue = value_grid[0];
        ObjectModel.HeightValue = value_grid[1];
        ObjectModel.xMax += ObjectModel.WidthValue;
        ObjectModel.yMin -= ObjectModel.HeightValue;
        for (int i = 0; i < ObjectModel.Height; i++)
        {
            for (int j = 0; j < ObjectModel.Width; j++)
            {
                var NewGrid = CutPuzzle.CreateObject(gridObject, parent);
                NewGrid.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
                NewGrid.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
                NewGrid.GetComponent<RectTransform>().anchorMin = new Vector2(ObjectModel.xMin, ObjectModel.yMin);
                NewGrid.GetComponent<RectTransform>().anchorMax = new Vector2(ObjectModel.xMax, ObjectModel.yMax);
                ObjectModel.xMin += ObjectModel.WidthValue;
                ObjectModel.xMax += ObjectModel.WidthValue;
            }
            ObjectModel.yMin -= ObjectModel.HeightValue;
            ObjectModel.yMax -= ObjectModel.HeightValue;
            ObjectModel.xMin = 0f;
            ObjectModel.xMax = ObjectModel.WidthValue;
        }
    }
    public static List<GameObject> AddListObjectGrid(List<GameObject> listObject, Transform parentArea)
    {
        foreach(Transform Child in parentArea)
        {
            listObject.Add(Child.gameObject);
        }
        return listObject;
    }
    public static List<int> AddNumber(List<int> listNumber, List<GameObject> listObject)
    {
        for(int i = 0; i < listObject.Count; i++)
        {
            listNumber.Add(i);
        }
        return listNumber;
    }
    public static List<int> AddNumberID(List<int> listNumber, List<GameObject> listObject)
    {
        for (int i = 0; i < (listObject.Count/2); i++)
        {
            listNumber.Add(i);
        }
        return listNumber;
    }
    public static int RandomNumber(List<int> listNumber)
    {  
        return Random.Range(0, (listNumber.Count - 1));
    }
    public static int RandomID(List<int> listID)
    {
        return Random.Range(0, (listID.Count - 1));
    }
    public static int RandomTexture(List<Texture2D> listTexture)
    {
        return Random.Range(0, (listTexture.Count - 1));
    }
    public static void AddIDNumber(List<int> listNumber, List<int> listID, List<GameObject> listObject, List<Texture2D> icon)
    {
        int idNum;
        int iTexture;
        int iObj;
        int realNum;
        int length = listID.Count;

        for (int i = 0; i < length; i++)
        {
            idNum = RandomID(listID);
            iTexture = RandomTexture(icon);

            iObj = RandomNumber(listNumber);
            realNum = listNumber[iObj];
            listObject[realNum].GetComponent<ObjectInfo>().idObject = listID[idNum];
            listObject[realNum].GetComponent<ObjectInfo>().image.GetComponent<RawImage>().texture = icon[iTexture];
            listNumber.RemoveAt(iObj);

            iObj = RandomNumber(listNumber);
            realNum = listNumber[iObj];
            listObject[realNum].GetComponent<ObjectInfo>().idObject = listID[idNum];
            listObject[realNum].GetComponent<ObjectInfo>().image.GetComponent<RawImage>().texture = icon[iTexture];
            listNumber.RemoveAt(iObj);

            icon.RemoveAt(iTexture);
            listID.RemoveAt(idNum);
        }
    }
    public static bool CheckWinClick(GameObject Area)
    {
        int i = 0;
        foreach(Transform Child in Area.transform)
        {
            if(Child)
            {
                i++;
            }
        }
        if(i == 0)
        {
            return true;
        }
        return false;
    }
    public static IEnumerator waitingFlip(List<GameObject> IDSelected)
    {
        yield return new WaitForSeconds(0.5f);
        IDSelected[0].GetComponent<ObjectInfo>().isSelected = false;
        IDSelected[1].GetComponent<ObjectInfo>().isSelected = false;
        IDSelected[0].GetComponent<Animator>().SetTrigger("isBack");
        IDSelected[1].GetComponent<Animator>().SetTrigger("isBack");
        IDSelected.Clear();
    }
    public static IEnumerator waitingFlipBeforeDestroy(List<GameObject> IDSelected)
    {
        yield return new WaitForSeconds(0.5f);
        IDSelected[0].GetComponent<Animator>().SetTrigger("isBack");
        IDSelected[1].GetComponent<Animator>().SetTrigger("isBack");
        CutPuzzle.DestroyObject(IDSelected[0]);
        CutPuzzle.DestroyObject(IDSelected[1]);
        IDSelected.Clear();
    }
}
