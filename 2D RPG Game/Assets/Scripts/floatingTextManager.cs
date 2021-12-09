using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class floatingTextManager : MonoBehaviour
{
    public GameObject textPrefab;
    public GameObject textContainer;

    private List<floatingText> floatingTexts = new List<floatingText>();

    private void Update()
    {
        foreach(floatingText txt in floatingTexts)
        {
            txt.updateFloatingText();
        }
    }

    public void Show(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingText FloatText = GetFloatingText();
        FloatText.txt.text = msg;
        FloatText.txt.fontSize = fontSize;
        FloatText.txt.color = color;

        FloatText.go.transform.position = Camera.main.WorldToScreenPoint(position);
        FloatText.motion = motion;
        FloatText.duration = duration;

        FloatText.show();
    }

    private floatingText GetFloatingText()
    {
        floatingText txt = floatingTexts.Find(t => !t.active);
        if (txt == null)
        {
            txt = new floatingText();
            txt.go = Instantiate(textPrefab);
            txt.go.transform.SetParent(textContainer.transform);
            txt.txt = txt.go.GetComponent<Text>();

            floatingTexts.Add(txt);
        }

        return txt;
    }

    
}
