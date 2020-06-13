using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private int m_Index;
    private int m_OldIndex;
    private float m_Time;

    private bool m_Active;
    private bool m_Miss;

    public bool Miss
    {
        set { m_Miss = value; }
    }

    void Start()
    {
        m_Index = m_OldIndex = 0;
        m_Active = false;
        m_Time = 0.0f;
        m_Miss = false;
    }

    public void Action(Player player)
    {
        if (m_Miss) return;

        Map map = GameObject.Find("StageManager").GetComponent<StageManager>().Map;

        m_Index = map.GetMapIndex(player);

        // マス侵入時
        if (m_Index != m_OldIndex)
        {
            m_Active = true;
            m_Time = 0.0f;
        }
        m_OldIndex = m_Index;

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

            // コントローラー
            // 縦
            if (Singleton<Pad>.Instance.IsClick_Up())
            {
                player.PlayerMove(Player.DirectionType.Up);
                m_Active = false;
                return;
            }
            if (Singleton<Pad>.Instance.IsClick_Down())
            {
                player.PlayerMove(Player.DirectionType.Down);
                m_Active = false;
                return;
            }

            // 横
            if (Singleton<Pad>.Instance.IsClick_Right())
            {
                player.PlayerMove(Player.DirectionType.Right);
                m_Active = false;
                return;
            }
            if (Singleton<Pad>.Instance.IsClick_Left())
            {
                player.PlayerMove(Player.DirectionType.Left);
                m_Active = false;
                return;
            }


            if (!player.IsMove)
            {
                m_Time += Time.deltaTime;

                // 止まってから死亡までの許容時間
                if (0.1f <= m_Time)
                {
                    Judgement judgement = GameObject.Find("Judgement").GetComponent<Judgement>();
                    judgement.Miss();
                    m_Active = false;
                }
            }
        }
    }
}
