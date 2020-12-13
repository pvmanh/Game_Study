using UnityEngine;
using System.Collections;
using System;
using TMPro;

[Serializable]
[CreateAssetMenu(fileName = "InputValidator - Input Field Validator.asset", menuName = "TextMeshPro/Input Validators/Input Field Validator")]

public class TypeDocValidator : TMP_InputValidator
{
    public override char Validate(ref string text, ref int pos, char ch)
    {
        if (ch == ' ')
        {
            return (char)0;
        }
        else
        {
            pos += 1;
            text += ch;
            return ch;
        }
    }
}
