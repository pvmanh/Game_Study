using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object 
{
    public static void RandomObjectPosition(ObjectModel objectData)
    {
        foreach (Transform ChildPuzzle in objectData.Object_Area)
        {
            objectData.Object_Rect = ChildPuzzle.GetComponent<RectTransform>();
            objectData.x = Random.Range(objectData.xMin, objectData.xMax);
            objectData.y = Random.Range(objectData.yMin, objectData.yMax);
            objectData.Object_Rect.localPosition = new Vector2(objectData.x, objectData.y);
        }
    }
}
