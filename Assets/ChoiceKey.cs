using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChoiceKey : MonoBehaviour
{
    Button button;

    void Start()
    {
        button = GameObject.Find("Canvas/Buttons/Start").GetComponent<Button>();

        button.Select();
    }
}
