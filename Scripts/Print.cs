using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Print : MonoBehaviour
{
    public TextMeshPro m_text;


    public void settext(string text)
    {
        m_text.text += "----newline-----"+text;

    }
}
