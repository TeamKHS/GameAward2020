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
    }

    private Status m_Status;
    private Player m_Player;

    // Start is called before the first frame update
    public void Initialize()
    {
        m_Status = Status.Non;
    }

    // Update is called once per frame
    void Update()
    {
        switch (m_Status)
        {
            case Status.Non:
                break;

            case Status.Hole:
                if (m_Player != null && !m_Player.IsMove)
                {
                    Debug.Log("堕ちたな");
                    m_Status = Status.Non;
                }

                break;

            case Status.Goal:

                break;
        }
    }

    public void Wall()
    {
    }

    public void Hole(Player player)
    {
        m_Player = player;
        m_Status = Status.Hole;
    }

    public void Goal()
    {

    }
}
