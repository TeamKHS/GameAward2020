using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judgement : MonoBehaviour
{
    private enum Status
    {
        Non = 0,
        Hole,
        Goal,
        Miss,
        GameOver,

    }

    private Status m_Status;
    private float m_Time;
    private bool m_End;
  

    // Start is called before the first frame update
    public void Initialize()
    {
        m_Status = Status.Non;
        m_Time = 0.0f;
        m_End = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (m_End)
        {
            return;
        }

        switch (m_Status)
        {
            case Status.Non:
                break;

            case Status.Hole:
                UpdateHole();
                break;

            case Status.Goal:
                UpdateGoal();
                break;

            case Status.Miss:
                UpdateMiss();
                    break;

            case Status.GameOver:
                UpdateGameOver();
                break;
        }
    }
    private void UpdateHole()
    {
        Player player = GameObject.Find("Player").GetComponent<Player>();

        if (!player.IsMove)
        {
            Debug.Log("堕ちたな");

            m_Time += Time.deltaTime;

            if (3.0f <= m_Time)
            {
                m_Status = Status.GameOver;
            }

        }
    }

    private void UpdateGoal()
    {
        Player player = GameObject.Find("Player").GetComponent<Player>();
        Map map = GameObject.Find("StageManager").GetComponent<StageManager>().Map;

        if (!player.IsMove)
        {
            Debug.Log("ゴール");
            m_Status = Status.Non;
        }
    }

    private void UpdateMiss()
    {
        Player player = GameObject.Find("Player").GetComponent<Player>();
        player.PlayerStop();

        Debug.Log("死");
       
        m_Time += Time.deltaTime;

        if (3.0f <= m_Time)
        {
            m_Status = Status.GameOver;
        }
    }

    private void UpdateGameOver()
    {
        FadeManager.Instance.LoadScene("Gameover", 2.0f);
        MainCamera camera = GameObject.Find("Main Camera").GetComponent<MainCamera>();
        camera.Active = false;
        Singleton<SoundPlayer>.Instance.Release();

        m_Status = Status.Non;
        m_End = true;
    }

    public void Wall()
    {
    }

    public void Hole()
    {
        m_Status = Status.Hole;
    }

    public void Goal()
    {
        m_Status = Status.Goal;
    }

    public void Miss()
    {
        m_Status = Status.Miss;
        GameObject.Find("Player").GetComponent<Player>().Miss = true;
    }



    //public void GameOver()
    //{
    //    m_Status = Status.GameOver;
    //}
}
