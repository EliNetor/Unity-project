using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public Text canvasText1;
    void Start()
    {
        Invoke("DisableText", 5f);
    }
    void DisableText()
    {
        canvasText1.enabled = false;
    }
 }
