using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    public void updateText(string message) {
        text.text = message;
    }
}
