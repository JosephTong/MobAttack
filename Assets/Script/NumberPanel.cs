using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public enum NumberPanelOperation
{
    Add = 0,
    Minus,
    multiply
}

public class NumberPanel : MonoBehaviour
{
    public NumberPanelOperation Operation;
    public float Number = 0;
    public int Id = 0;
    [SerializeField] private TMP_Text m_Text;

    private void Start() {
        string showtext = "";
        switch (Operation)
        {
            case NumberPanelOperation.Add:
                showtext +="+";
                break;
            case NumberPanelOperation.Minus:
                showtext +="-";
                break;
            case NumberPanelOperation.multiply:
                showtext +="X";
                break;
            default:
                break;
        }
        m_Text.text = showtext+Number.ToString("0.#");
    }
}
