using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageClear : MonoBehaviour
{
    // Update is called once per frame
    void Start()
    {
        int index = StageManager.StageIndex + 1;

        GameObject.Find("Mask").SetActive(Buttons.IsStageActive(index));
    }
}
