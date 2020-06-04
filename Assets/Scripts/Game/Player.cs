using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum DirectionType
    {
        Right = 0,
        Left,
        Up,
        Down
    }

    private Map m_Map;
    private Judgement m_Judgement;
    private Gimmick m_Gimmick;

    private bool m_Move;
    private int m_Direction = 0;
    private DirectionType m_DirectionType = DirectionType.Down;

    // 線形補間用
    private Vector3 m_StartPosition;
    private Vector3 m_EndPosition;
    private float m_Weight;
    private float m_Value;
    private float m_Time;

    public bool IsMove
    {
        get { return m_Move; }
        set { m_Move = value; }
    }
    public int Direction
    {
        get { return m_Direction; }
    }
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
        {
            GameObject obj = GameObject.Find("Gimmick");
            m_Gimmick = obj.GetComponent<Gimmick>();
        }

        m_Move = false;
        m_Weight = 0.0f;
        m_Value = 0.0f;
        m_Time = 0.0f;
        Animator anim = this.GetComponent<Animator>();
        anim.SetInteger("Direction", (int)m_DirectionType);
    }

    void Update()
    {
        m_Time += Time.deltaTime;
        Debug.Log(m_Time);
        if (Input.GetKeyDown(KeyCode.Space))
            Singleton<SoundPlayer>.Instance.Play("se");

        m_Gimmick.Action(m_Map.GetMapType(this), this);

        // 動いている
        if (m_Move)
        {
            if ((m_Weight += (m_Value * Time.deltaTime)) >= 1.0f)
            {
                SetEndPosition(); // 移動処理
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
    }

    private void SetPosition(Vector3 position)
    {
        this.transform.position = position;
    }

    public void SetEndPosition()
    {
        SetPosition(m_EndPosition);
    }

    public void PlayerMove(DirectionType dir)
    {
        // マップ情報
        int[] map = m_Map.MapData;
        bool move = true;

        SetDirection(dir);

        // オレの位置
        int index = m_Map.GetMapIndex(this);

        for (int i = 1; move; i++)
        {
            m_Move = true;          // 移動フラグ
            int nextIndex = index + i * m_Direction;

            // 床だったらスルー
            if (map[nextIndex] == (int)Map.MapType.Floor)
            {
                continue;
            }

            switch (map[nextIndex])
            {
                case (int)Map.MapType.Wall:
                    // 壁
                    nextIndex -= m_Direction;
                    m_Judgement.Wall();
                    StartMove(i, index, nextIndex, ref move);
                    break;

                case (int)Map.MapType.Hole:
                    // 穴
                    m_Judgement.Hole(this);
                    StartMove(i, index, nextIndex, ref move);
                    break;

                case (int)Map.MapType.Goal:
                    // ゴール
                    m_Judgement.Goal();
                    StartMove(i, index, nextIndex, ref move);
                    break;
            }
        }
    }

    // プレイヤーの移動停止
    public void PlayerStop()
    {
        m_Move = false;
       // m_StartPosition = m_EndPosition = this.transform.position;
    }

    private void SetDirection(DirectionType dir)
    {
        m_DirectionType = dir;
        Animator anim = this.GetComponent<Animator>();
        anim.SetInteger("Direction", (int)m_DirectionType);

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

    private void StartMove(int i, int index, int nextIndex, ref bool move)
    {
        // 次のマス目に到着する時間
        float time = m_Map.NoteTiming.GetTiming() - m_Time;
            

        // 線形補間の情報
        m_StartPosition = m_Map.GetMapPosition(index);      // 現在地を保存
        m_EndPosition = m_Map.GetMapPosition(nextIndex);    // 進行先を保存
        m_Weight = 0.0f;        // 割合を初期化
        m_Value = 1.0f / time;  // 進むマス数によって速度の変更

        move = false;
    }
}
