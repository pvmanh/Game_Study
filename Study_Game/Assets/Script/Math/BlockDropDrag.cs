using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BlockDropDrag : MonoBehaviour
{
    private void Update() {
        LayoutRebuilder.MarkLayoutForRebuild(GetComponent<RectTransform>());
    }
}
