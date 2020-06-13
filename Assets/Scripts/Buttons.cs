using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    static bool m_Stage00 = false;
    static bool m_Stage01 = false;
    static bool m_Stage02 = false;
    static bool m_Stage03 = false;

    public static bool Stage00
    {
        get { return m_Stage00; }
        set { m_Stage00 = value; }
    }
    public static bool Stage01
    {
        get { return m_Stage01; }
        set { m_Stage01 = value; }
    }
    public static bool Stage02
    {
        get { return m_Stage02; }
        set { m_Stage02 = value; }
    }
    public static bool Stage03
    {
        get { return m_Stage03; }
        set { m_Stage03 = value; }
    }

    public void NewGame()
    {
        StageManager.StageIndex = 0;
        StageManager.LookMap = true;
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
        if (!m_Stage00) return;

        StageManager.StageIndex = 0;
        StageManager.LookMap = true;
        FadeManager.Instance.LoadScene("Game", 2.0f);
    }

    public void ToStage01()
    {
        if (!m_Stage01) return;

        StageManager.StageIndex = 1;
        StageManager.LookMap = true;
        FadeManager.Instance.LoadScene("Game", 2.0f);

    }

    public void ToStage02()
    {
        if (!m_Stage02) return;

        StageManager.StageIndex = 2;
        StageManager.LookMap = true;
        FadeManager.Instance.LoadScene("Game", 2.0f);

    }

    public void ToStage03()
    {
        if (!m_Stage03) return;

        StageManager.StageIndex = 3;
        StageManager.LookMap = true;
        FadeManager.Instance.LoadScene("Game", 2.0f);
    }

    public void ToTitle()
    {
        FadeManager.Instance.LoadScene("Title", 2.0f);
    }

    public void ReStart()
    {
        StageManager.LookMap = false;
        FadeManager.Instance.LoadScene("Game", 2.0f);
    }

    public void NextStage()
    {
        int index = StageManager.StageIndex + 1;

        switch (index)
        {
            case 0:
                if (!m_Stage00) return;

                ToStage00();
                break;

            case 1:
                if (!m_Stage01) return;

                ToStage01();
                break;

            case 2:
                if (!m_Stage02) return;

                ToStage02();
                break;

            case 3:
                if (!m_Stage03) return;

                ToStage03();
                break;

            case 4:
                ToTitle();
                break;
        }
    }

    public static bool IsStageActive(int index)
    {
        switch (index)
        {
            case 0:
                return m_Stage00;
            case 1:
                return m_Stage01;
            case 2:
                return m_Stage02;
            case 3:
                return m_Stage03;
        }

        return false;
    }
    public static void SetStageActive(int index, bool active)
    {
        switch (index)
        {
            case 0:
                m_Stage00 = active;
                break;

            case 1:
                m_Stage01 = active;
                break;

            case 2:
                m_Stage02 = active;
                break;

            case 3:
                m_Stage03 = active;
                break;
        }
    }
}
