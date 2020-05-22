using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Map m_Map;
    private Judgement m_Judgement;

    private bool m_Move;
    public bool IsMove
    {
        get { return m_Move; }
        set { m_Move = value; }
    }

    // 線形補間用
    private Vector3 m_StartPosition;
    private Vector3 m_EndPosition;
    private float m_Weight;
    private float m_Value;

    public Vector3 StartPosition
    {
        get { return m_StartPosition; }
        set { m_StartPosition = value; }
    }
    public Vector3 EndPosition
    {
        get { return m_EndPosition; }
        set { m_EndPosition = value; }
    }

    void Start()
    {
        {
            GameObject obj = GameObject.Find("StageManager");
            StageManager stageManager = obj.GetComponent<StageManager>();
            m_Map = stageManager.Map;
        }
        {
            GameObject obj = GameObject.Find("Judgement");
            m_Judgement = obj.GetComponent<Judgement>();
        }

        m_Move = false;
        m_Weight = 0.0f;
        m_Value = 0.01f;
    }

    void Update()
    {
        // 動いている
        if (m_Move)
        {
            Vector3 nextPosition = new Vector3();
            nextPosition = m_StartPosition * (1.0f - m_Weight) + m_EndPosition * m_Weight;
            if ((m_Weight += m_Value) >= 1.0f)
            {
                SetPlayerPosition(m_EndPosition);
                m_Move = false;
            }
            else
            {
                SetPlayerPosition(nextPosition);
            }
        }
        else
        {
            // マップ情報
            int[] map = m_Map.GetMap;
            int mapX = m_Map.m_MapX;
            int mapY = m_Map.m_MapY;

            bool move = false;
            int dir = 0;

            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                dir = 1;
                move = true;
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                dir = -1;
                move = true;
            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                dir = -mapX;
                move = true;
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                dir = mapX;
                move = true;
            }

            // オレの位置
            int index = m_Map.GetMapIndex((Vector2)this.transform.position);

            for (int i = 1; move; i++)
            {
                int nextIndex = index + i * dir;
                Vector3 nextPosition;
                m_Move = true;

                if (map[nextIndex] == (int)Map.MapType.Floor || map[nextIndex] == (int)Map.MapType.Non)
                {
                    continue;
                }

                switch (map[nextIndex])
                {
                    case (int)Map.MapType.Wall:
                        nextIndex -= dir;

                        // 配列番号から位置を算出
                        m_StartPosition = m_Map.GetMapPosition(index);
                        m_EndPosition = m_Map.GetMapPosition(nextIndex);
                        m_Weight = 0.0f;
                        break;

                    case (int)Map.MapType.Hole:
                        // 配列番号から位置を算出
                        nextPosition = m_Map.GetMapPosition(nextIndex);

                        break;

                    case (int)Map.MapType.Goal:
                        // 配列番号から位置を算出
                        nextPosition = m_Map.GetMapPosition(nextIndex);

                        break;
                }
                break;
            }
        }
    }

    private void SetPlayerPosition(Vector3 position)
    {
        this.transform.position = position;
    }
}
