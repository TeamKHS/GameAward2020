using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect : MonoBehaviour
{
    // Update is called once per frame
    void Start()
    {
        GameObject.Find("MaskStage00").SetActive(!Buttons.Stage00);
        GameObject.Find("MaskStage01").SetActive(!Buttons.Stage01);
        GameObject.Find("MaskStage02").SetActive(!Buttons.Stage02);
        GameObject.Find("MaskStage03").SetActive(!Buttons.Stage03);
    }
}
