using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public bool RPGCamera;
    private GameObject Player = null;
    private GameObject Stage = null;
    private Map map = null;
    private float CellLength = 0;

    public float LookMapSpeed = 10.0f;
    private bool m_Active = false;
    private bool m_Move = false;
    private bool m_Start = false;
    private int m_Index = 0;
    private int m_OldIndex = 0;
    private bool m_Lerp = false;
    private Vector3 m_StartPosition;
    private Vector3 m_EndPosition;
    private float m_Weight;
    private float m_Value;

    public bool Active
    {
        set { m_Active = value; }
    }
    public bool Move
    {
        set { m_Move = value; }
    }

    public void Initialize()
    {
        this.Player = GameObject.Find("Player");
        this.map = GameObject.Find("Stage").GetComponent<Map>();
        this.Stage = GameObject.Find("Stage");
        CellLength = Stage.GetComponent<Grid>().cellSize.x;

        m_Active = true;
        m_Start = false;
        m_Move = true;
        m_Index = m_OldIndex = -1;
        m_Lerp = false;
       
        m_StartPosition = m_EndPosition = Vector3.zero;
        m_Weight = m_Value = 0.0f;
    }

    void Update()
    {
        if (!m_Active)
        {
            return;
        }
        Vector3 CameraPos = Vector3.zero;

        // 初回カメラ移動
        if (m_Move)
        {
            Map map = GameObject.Find("StageManager").GetComponent<StageManager>().Map;

            if (m_Index == -1 && m_OldIndex == -1)
            {
                m_Index = map.GetGoalIndex();

                CameraPos = map.GetMapPosition(m_Index);
                CameraPos.z = -10.0f;

                if (RPGCamera)
                {
                    CameraPos = RPG(CameraPos);
                }
                m_StartPosition = m_EndPosition = CameraPos;
                m_OldIndex = m_Index;
                SetCameraPosition(CameraPos);

                return;
            }

            // フェード中
            if (FadeManager.Instance.Fading)
            {
                return;
            }

            if (!m_Lerp)
            {
                bool move, right, left, up, down;
                move = right = left = up = down = true;

                for (int i = 1; move; i++)
                {
                    if (right)
                        if (Search(ref right, 1, i, ref move))
                            break;
                    if (left)
                        if (Search(ref left, -1, i, ref move))
                            break;
                    if (up)
                        if (Search(ref up, -map.m_MapX, i, ref move))
                            break;
                    if (down)
                        if (Search(ref down, map.m_MapX, i, ref move))
                            break;
                }
            }

            if ((m_Weight += (m_Value * Time.deltaTime * LookMapSpeed)) >= 1.0f)
            {
                CameraPos = m_EndPosition;
                CameraPos.z = -10.0f;

                m_Lerp = false;   // 移動フラグ

                if (m_Start)
                {
                    m_Move = false;
                    Singleton<SoundPlayer>.Instance.PlayBGM();
                }
            }
            else
            {
                // 線形補間
                CameraPos = m_StartPosition * (1.0f - m_Weight) + m_EndPosition * m_Weight;
                CameraPos.z = -10.0f;
            }
            if (RPGCamera)
            {
                CameraPos = RPG(CameraPos);
            }

            SetCameraPosition(CameraPos);
        }
        else
        {
            // 音無かったら再生開始
            if (!Singleton<SoundPlayer>.Instance.IsPlayingBGM())
            {
                if (!FadeManager.Instance.Fading)
                {
                    Singleton<SoundPlayer>.Instance.PlayBGM();
                }
            }
            if (Player == null)
            {
                this.Player = GameObject.Find("Player");
            }

            if (map == null)
            {
                this.map = GameObject.Find("Stage").GetComponent<Map>();
            }

            if (Stage == null)
            {
                this.Stage = GameObject.Find("Stage");
                CellLength = Stage.GetComponent<Grid>().cellSize.x;
            }

            CameraPos = Player.transform.position;
            CameraPos.z = -10.0f;

            if (RPGCamera)
            {
                CameraPos = RPG(CameraPos);
            }

            SetCameraPosition(CameraPos);
        }
    }

    bool Search(ref bool dirFlag, int dir, int i, ref bool move)
    {
        int index = m_Index + i * dir;

        if (map.GetMapType(index) == Map.MapType.Hole) dirFlag = false;
        if (map.GetMapType(index) == Map.MapType.Wall) dirFlag = false;
        if (map.GetMapType(index) == Map.MapType.Arrow || map.GetMapType(index) == Map.MapType.Start)
        {
            if (m_OldIndex == index)
            {
                dirFlag = false;
                return false;
            }
            else
            {
                StartMove(index, i, ref move);

                if (map.GetMapType(index) == Map.MapType.Start)
                {
                    m_Start = true;
                }
                return true;
            }
        }
        return false;
    }

    private void StartMove(int index, int i, ref bool move)
    {
        move = false;
        m_Lerp = true;

        m_StartPosition = map.GetMapPosition(m_Index);
        m_EndPosition = map.GetMapPosition(index);
        m_Weight = 0.0f;
        m_Value = 1.0f / i;

        m_OldIndex = m_Index;
        m_Index = index;
    }

    private Vector3 RPG(Vector3 pos)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(Vector2.zero);
        Vector2 max = Camera.main.ViewportToWorldPoint(Vector2.one);

        pos.x = Mathf.Clamp(pos.x, (max.x - min.x) / 2, map.m_MapX * CellLength - (max.x - min.x) / 2);
        pos.y = Mathf.Clamp(pos.y, -map.m_MapY * CellLength + (max.y - min.y) / 2, -(max.y - min.y) / 2);

        return pos;
    }

    private void SetCameraPosition(Vector3 position)
    {
        transform.position = position;
    }
}
