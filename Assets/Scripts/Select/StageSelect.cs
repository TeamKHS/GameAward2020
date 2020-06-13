using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect : MonoBehaviour
{
    // Update is called once per frame

    void Start()
    {
        GameObject buttons;

        buttons = GameObject.Find("Canvas").transform.Find("Buttons").gameObject;

        buttons.transform.Find("Stage1").transform.Find("MaskStage00").gameObject.SetActive(!Buttons.Stage00);
        buttons.transform.Find("Stage2").transform.Find("MaskStage01").gameObject.SetActive(!Buttons.Stage01);
        buttons.transform.Find("Stage3").transform.Find("MaskStage02").gameObject.SetActive(!Buttons.Stage02);
        buttons.transform.Find("Stage4").transform.Find("MaskStage03").gameObject.SetActive(!Buttons.Stage03);

        //    GameObject.Find("MaskStage01").SetActive(!Buttons.Stage00);
        //    GameObject.Find("MaskStage01").SetActive(!Buttons.Stage01);
        //    GameObject.Find("MaskStage02").SetActive(!Buttons.Stage02);
        //    GameObject.Find("MaskStage03").SetActive(!Buttons.Stage03);
    }
}
