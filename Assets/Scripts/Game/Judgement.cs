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
        GameOver,
    }

    private Status m_Status;
    private float m_Time;

    // Start is called before the first frame update
    public void Initialize()
    {
        m_Status = Status.Non;
        m_Time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
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

            case Status.GameOver:
                UpdateGameOver();

                break;
        }
    }
    private void UpdateHole()
    {
        Player player = GameObject.Find("Player").GetComponent<Player>();
        Map map = GameObject.Find("StageManager").GetComponent<StageManager>().Map;

        if (!player.IsMove)
        {
            Debug.Log("堕ちたな");
            m_Status = Status.Non;
            player.PlayerStop();
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

    private void UpdateGameOver()
    {
        m_Time += Time.deltaTime;

        Player player = GameObject.Find("Player").GetComponent<Player>();
        Debug.Log("死");

        player.PlayerStop();
        m_Status = Status.Non;

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

    public void GameOver()
    {
        m_Status = Status.GameOver;
    }
}
