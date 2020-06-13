using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageClear : MonoBehaviour
{
    // Update is called once per frame
    void Start()
    {
        GameObject buttons;
        int index = StageManager.StageIndex + 1;

        buttons = GameObject.Find("Canvas").transform.Find("Buttons").gameObject;

        buttons.transform.Find("NextStage").transform.Find("Mask").gameObject.SetActive(!Buttons.IsStageActive(index));
    }
}
