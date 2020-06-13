using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ChoiceKey : MonoBehaviour
{
    Button m_Button;
    private int m_Index = 0;
    

    void Start()
    {
        m_Index = -1;
        m_Button = null;

        //if (SceneManager.GetActiveScene().name == "Title")
        //{
        //    m_Button = GameObject.Find("Canvas/Buttons/Start").GetComponent<Button>();
        //    m_Button.Select();
        //}

        //if (SceneManager.GetActiveScene().name == "Stageselect")
        //{
        //    m_Button = GameObject.Find("Canvas/Buttons/Stage1").GetComponent<Button>();
        //    m_Button.Select();
        //}

        //if (SceneManager.GetActiveScene().name == "Stageclear")
        //{
        //    m_Button = GameObject.Find("Canvas/Buttons/NextStage").GetComponent<Button>();
        //    m_Button.Select();
        //}

        //if (SceneManager.GetActiveScene().name == "Gameover")
        //{
        //    m_Button = GameObject.Find("Canvas/Buttons/Retry").GetComponent<Button>();
        //    m_Button.Select();
        //}
    }

    void Update()
    {
        Singleton<Pad>.Instance.PadUpdate();

        if (Singleton<Pad>.Instance.IsClick_AnyKey() && m_Index == -1)
        {
            m_Index = 0;
            return;
        }

        switch (SceneManager.GetActiveScene().name)
        {
            case "Title":
                UpdateTitle();
                break;

            case "Stageselect":
                UpdateStageSelect();
                break;

            case "Stageclear":
                UpdateStageClear();
                break;

            case "Gameover":
                UpdateGameOver();
                break;
        }

        if (Singleton<Pad>.Instance.IsClick_ABXY() && m_Button != null)
        {
            m_Button.onClick.Invoke();
        }
    }

    private void UpdateTitle()
    {
        if (Singleton<Pad>.Instance.IsClick_Up())
        {
            m_Index = Mathf.Max(m_Index - 1, 0);
        }
        if (Singleton<Pad>.Instance.IsClick_Down())
        {
            m_Index = Mathf.Min(m_Index + 1, 2);
        }

        switch (m_Index)
        {
            case 0:
                m_Button = GameObject.Find("Canvas/Buttons/Start").GetComponent<Button>();
                m_Button.Select();
                break;
            case 1:
                m_Button = GameObject.Find("Canvas/Buttons/Selectstage").GetComponent<Button>();
                m_Button.Select();
                break;
            case 2:
                m_Button = GameObject.Find("Canvas/Buttons/Close").GetComponent<Button>();
                m_Button.Select();
                break;
        }
    }
    private void UpdateStageSelect()
    {
        if (Singleton<Pad>.Instance.IsClick_Up())
        {
            if (m_Index == 2)
            {
                m_Index -= 2;
            }
            if (m_Index == 3)
            {
                m_Index -= 2;
            }
        }
        if (Singleton<Pad>.Instance.IsClick_Down())
        {
            if (m_Index == 0)
            {
                m_Index += 2;
            }
            if (m_Index == 1)
            {
                m_Index += 2;
            }
        }
        if (Singleton<Pad>.Instance.IsClick_Right())
        {
            if (m_Index == 0)
            {
                m_Index += 1;
            }
            if (m_Index == 2)
            {
                m_Index += 1;
            }
        }
        if (Singleton<Pad>.Instance.IsClick_Left())
        {
            if (m_Index == 1)
            {
                m_Index -= 1;
            }
            if (m_Index == 3)
            {
                m_Index -= 1;
            }
        }

        switch (m_Index)
        {
            case 0:
                m_Button = GameObject.Find("Canvas/Buttons/Stage1").GetComponent<Button>();
                m_Button.Select();
                break;
            case 1:
                m_Button = GameObject.Find("Canvas/Buttons/Stage2").GetComponent<Button>();
                m_Button.Select();
                break;
            case 2:
                m_Button = GameObject.Find("Canvas/Buttons/Stage3").GetComponent<Button>();
                m_Button.Select();
                break;
            case 3:
                m_Button = GameObject.Find("Canvas/Buttons/Stage4").GetComponent<Button>();
                m_Button.Select();
                break;
        }
    }
    private void UpdateStageClear()
    {
        if (Singleton<Pad>.Instance.IsClick_Right())
        {
            m_Index = Mathf.Min(m_Index + 1, 1);
        }
        if (Singleton<Pad>.Instance.IsClick_Left())
        {
            m_Index = Mathf.Max(m_Index - 1, 0);
        }

        switch (m_Index)
        {
            case 0:
                m_Button = GameObject.Find("Canvas/Buttons/NextStage").GetComponent<Button>();
                m_Button.Select();
                break;
            case 1:
                m_Button = GameObject.Find("Canvas/Buttons/BackToTitle").GetComponent<Button>();
                m_Button.Select();
                break;
        }
    }
    private void UpdateGameOver()
    {
        if (Singleton<Pad>.Instance.IsClick_Right())
        {
            m_Index = Mathf.Min(m_Index + 1, 1);
        }
        if (Singleton<Pad>.Instance.IsClick_Left())
        {
            m_Index = Mathf.Max(m_Index - 1, 0);
        }

        switch (m_Index)
        {
            case 0:
                m_Button = GameObject.Find("Canvas/Buttons/Retry").GetComponent<Button>();
                m_Button.Select();
                break;
            case 1:
                m_Button = GameObject.Find("Canvas/Buttons/BackToTitle").GetComponent<Button>();
                m_Button.Select();
                break;
        }
    }
}
