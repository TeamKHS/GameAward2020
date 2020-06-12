using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private int m_Index;
    private int m_OldIndex;
    private float m_Time;

    private bool m_Active;

    void Start()
    {
        m_Index = m_OldIndex = 0;
        m_Active = false;
        m_Time = 0.0f;
    }

    public void Action(Player player)
    {
        Map map = GameObject.Find("StageManager").GetComponent<StageManager>().Map;

        m_Index = map.GetMapIndex(player);

        // マス侵入時
        if (m_Index != m_OldIndex)
        {
            m_Active = true;
            m_Time = 0.0f;
        }

        if (m_Active)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                player.PlayerMove(Player.DirectionType.Right);
                m_Active = false;
                return;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                player.PlayerMove(Player.DirectionType.Left);
                m_Active = false;
                return;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                player.PlayerMove(Player.DirectionType.Up);
                m_Active = false;
                return;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                player.PlayerMove(Player.DirectionType.Down);
                m_Active = false;
                return;
            }
        }

        if (!player.IsMove)
        {
            m_Time += Time.deltaTime;

            // 止まってから死亡までの許容時間
            if (0.1f <= m_Time)
            {
                Judgement judgement = GameObject.Find("Judgement").GetComponent<Judgement>();
                judgement.GameOver();
            }
        }


        //// 縦
        //if (Input.GetAxis("Vertical") < -0.1f)
        //    player.PlayerMove(Player.DirectionType.Up);
        //if (Input.GetAxis("Vertical") > 0.1f)
        //    player.PlayerMove(Player.DirectionType.Down);

        //// 横
        //if (Input.GetAxis("Horizontal") > 0.1f)
        //    player.PlayerMove(Player.DirectionType.Right);
        //if (Input.GetAxis("Horizontal") < -0.1f)
        //    player.PlayerMove(Player.DirectionType.Left);

        m_OldIndex = m_Index;
    }
}
