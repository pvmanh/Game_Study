using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectModel
{
    [Header("Object Click Position Setting")]
    public Transform Object_Area;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
    [HideInInspector] public RectTransform Object_Rect;
    [HideInInspector] public float x;
    [HideInInspector] public float y;
}
