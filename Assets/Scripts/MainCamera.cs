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

        // 初回カメラ移動
        if (m_Move)
        {
            Map map = GameObject.Find("StageManager").GetComponent<StageManager>().Map;

            if (m_Index == -1 && m_OldIndex == -1)
            {
                m_Index = map.GetGoalIndex();

                Vector3 CameraPos = map.GetMapPosition(m_Index);
                CameraPos.z = -10.0f;

                if (RPGCamera)
                {
                    Vector2 min = Camera.main.ViewportToWorldPoint(Vector2.zero);
                    Vector2 max = Camera.main.ViewportToWorldPoint(Vector2.one);

                    CameraPos.x = Mathf.Clamp(CameraPos.x, (max.x - min.x) / 2, map.m_MapX * CellLength - (max.x - min.x) / 2);
                    CameraPos.y = Mathf.Clamp(CameraPos.y, -map.m_MapY * CellLength + (max.y - min.y) / 2, -(max.y - min.y) / 2);
                }

                m_StartPosition = m_EndPosition = transform.position = CameraPos;
                m_OldIndex = m_Index;

                return;
            }

            // フェード中
            if (FadeManager.Instance.Fading)
            {
                return;
            }

            if (!m_Lerp)
            {
                bool move = true;
                bool right, left, up, down;
                right = left = up = down = true;

                for (int i = 1; move; i++)
                {
                    // 右方向検索
                    if (right)
                    {
                        int index = GetMapType(m_Index, 1, i);

                        if (map.GetMapType(index) == Map.MapType.Hole) right = false;
                        if (map.GetMapType(index) == Map.MapType.Wall) right = false;
                        if (map.GetMapType(index) == Map.MapType.Arrow || map.GetMapType(index) == Map.MapType.Start)
                        {
                            if (m_OldIndex == index)
                            {
                                right = false;
                            }
                            else
                            {
                                StartMove(index, i, ref move);

                                if (map.GetMapType(index) == Map.MapType.Start)
                                {
                                    m_Start = true;
                                }
                                break;
                            }
                        }
                    }

                    if (left)
                    {
                        int index = GetMapType(m_Index, -1, i);

                        if (map.GetMapType(index) == Map.MapType.Hole) left = false;
                        if (map.GetMapType(index) == Map.MapType.Wall) left = false;
                        if (map.GetMapType(index) == Map.MapType.Arrow || map.GetMapType(index) == Map.MapType.Start)
                        {
                            if (m_OldIndex == index)
                            {
                                left = false;
                            }
                            else
                            {
                                StartMove(index, i, ref move);


                                if (map.GetMapType(index) == Map.MapType.Start)
                                {
                                    m_Start = true;
                                }
                                break;
                            }
                        }
                    }

                    if (up)
                    {
                        int index = GetMapType(m_Index, -map.m_MapX, i);

                        if (map.GetMapType(index) == Map.MapType.Hole) up = false;
                        if (map.GetMapType(index) == Map.MapType.Wall) up = false;
                        if (map.GetMapType(index) == Map.MapType.Arrow || map.GetMapType(index) == Map.MapType.Start)
                        {
                            if (m_OldIndex == index)
                            {
                                up = false;
                            }
                            else
                            {
                                StartMove(index, i, ref move);

                                if (map.GetMapType(index) == Map.MapType.Start)
                                {
                                    m_Start = true;
                                }
                                break;
                            }
                        }
                    }

                    if (down)
                    {
                        int index = GetMapType(m_Index, map.m_MapX, i);

                        if (map.GetMapType(index) == Map.MapType.Hole) down = false;
                        if (map.GetMapType(index) == Map.MapType.Wall) down = false;
                        if (map.GetMapType(index) == Map.MapType.Arrow || map.GetMapType(index) == Map.MapType.Start)
                        {
                            if (m_OldIndex == index)
                            { 
                                down = false;
                            }
                            else
                            {
                                StartMove(index, i, ref move);

                                if (map.GetMapType(index) == Map.MapType.Start)
                                {
                                    m_Start = true;
                                }
                                break;
                            }
                        }
                    }
                }
            }
            
            {
                Vector3 CameraPos;

                if ((m_Weight += (m_Value * Time.deltaTime * 10.0f)) >= 1.0f)
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
                    Vector2 min = Camera.main.ViewportToWorldPoint(Vector2.zero);
                    Vector2 max = Camera.main.ViewportToWorldPoint(Vector2.one);

                    CameraPos.x = Mathf.Clamp(CameraPos.x, (max.x - min.x) / 2, map.m_MapX * CellLength - (max.x - min.x) / 2);
                    CameraPos.y = Mathf.Clamp(CameraPos.y, -map.m_MapY * CellLength + (max.y - min.y) / 2, -(max.y - min.y) / 2);
                }

                transform.position = CameraPos;
            }
        }
        else
        {
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

            Vector3 CameraPos = Player.transform.position;

            CameraPos.z = -10.0f;

            if (RPGCamera)
            {
                Vector2 min = Camera.main.ViewportToWorldPoint(Vector2.zero);
                Vector2 max = Camera.main.ViewportToWorldPoint(Vector2.one);

                CameraPos.x = Mathf.Clamp(CameraPos.x, (max.x - min.x) / 2, map.m_MapX * CellLength - (max.x - min.x) / 2);
                CameraPos.y = Mathf.Clamp(CameraPos.y, -map.m_MapY * CellLength + (max.y - min.y) / 2, -(max.y - min.y) / 2);
            }

            transform.position = CameraPos;

        }
    }

    private int GetMapType(int index, int dir, int i)
    {
        return index + i * dir;
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
}
