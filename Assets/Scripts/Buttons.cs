using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public void NewGame()
    {
        StageManager.StageIndex = 0;
        FadeManager.Instance.LoadScene("Game", 2.0f);
    }

    public void ToStageSelect()
    {
        FadeManager.Instance.LoadScene("Stageselect", 2.0f);
    }

    public void End()
    {
        Application.Quit();
        return;
    }

    public void ToStage00()
    {
        StageManager.StageIndex = 0;
        FadeManager.Instance.LoadScene("Game", 2.0f);
    }

    public void ToStage01()
    {
        StageManager.StageIndex = 1;
        FadeManager.Instance.LoadScene("Game", 2.0f);

    }

    public void ToStage02()
    {
        StageManager.StageIndex = 2;
        FadeManager.Instance.LoadScene("Game", 2.0f);

    }

    public void ToStage03()
    {
        StageManager.StageIndex = 3;
        FadeManager.Instance.LoadScene("Game", 2.0f);
    }

    public void ToTitle()
    {
        FadeManager.Instance.LoadScene("Title", 2.0f);
    }

    public void ReStart()
    {
        FadeManager.Instance.LoadScene("Game", 2.0f);
    }

}
