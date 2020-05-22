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

    private int m_Direction;
    public int Direction
    {
        get { return m_Direction; }
    }

    // 線形補間用
    private Vector3 m_StartPosition;
    private Vector3 m_EndPosition;
    private float m_Weight;
    private float m_Value;
    private float m_Speed = 0.1f;

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
    public float Weight
    {
        set { m_Weight = value; }
    }
    public float Value
    {
        set { m_Value = value; }
    }
    public float Speed
    {
        get { return m_Speed; }
        set { m_Speed = value; }
    }

    private enum DirectionType
    {
        Right = 0,
        Left,
        Up,
        Down
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
        m_Value = 0.0f;
    }

    void Update()
    {
        // 動いている
        if (m_Move)
        {
            if ((m_Weight += m_Value) >= 1.0f)
            {
                SetPosition(m_EndPosition); // 移動処理
                m_Move = false;             // 移動フラグ
            }
            else
            {
                Vector3 nextPosition = new Vector3();
                // 線形補間
                nextPosition = m_StartPosition * (1.0f - m_Weight) + m_EndPosition * m_Weight;
                SetPosition(nextPosition);  // 移動処理
            }
        }
        else
        {
            // マップ情報
            int[] map = m_Map.GetMap;

            bool move = false;

            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                SetDirection(DirectionType.Right);
                move = true;
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                SetDirection(DirectionType.Left);
                move = true;
            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                SetDirection(DirectionType.Up);
                move = true;
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                SetDirection(DirectionType.Down);
                move = true;
            }

            // オレの位置
            int index = m_Map.GetMapIndex(this);

            for (int i = 1; move; i++)
            {
                int nextIndex = index + i * m_Direction;

                if (map[nextIndex] == (int)Map.MapType.Floor || map[nextIndex] == (int)Map.MapType.Non)
                {
                    continue;
                }

                switch (map[nextIndex])
                {
                    case (int)Map.MapType.Wall:
                        // 壁
                        nextIndex -= m_Direction;
                        m_Judgement.Wall();
                        break;

                    case (int)Map.MapType.Hole:
                        // 穴
                        m_Judgement.Hole();
                        break;

                    case (int)Map.MapType.Goal:
                        // ゴール
                        m_Judgement.Goal();
                        break;
                }

                // 線形補間の情報
                m_StartPosition = m_Map.GetMapPosition(index);      // 現在地を保存
                m_EndPosition = m_Map.GetMapPosition(nextIndex);    // 進行先を保存
                m_Weight = 0.0f;        // 割合を初期化
                m_Value = m_Speed / i;  // 進むマス数によって速度の変更
                m_Move = true;          // 移動フラグ

                break;
            }
        }
    }

    private void SetPosition(Vector3 position)
    {
        this.transform.position = position;
    }

    private void SetDirection(DirectionType dir)
    {
        switch (dir)
        {
            case DirectionType.Right:
                m_Direction = 1;
                break;
            case DirectionType.Left:
                m_Direction = -1;
                break;
            case DirectionType.Up:
                m_Direction = -m_Map.m_MapX;
                break;
            case DirectionType.Down:
                m_Direction = m_Map.m_MapX;
                break;
        }
    }
}
