using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float DrawTime = 1.0f;
    public bool DrawPos = true;

    private int m_Index;
    private int m_OldIndex;

    private bool m_Success;

    public int OldIndex
    {
        set { m_OldIndex = value; }
    }

    public bool Success
    {
        get { return m_Success; }
    }


    void Start()
    {
        m_Index = m_OldIndex = 0;
        m_Success = true;
    }

    public void Action(Player player)
    {
        Map map = GameObject.Find("StageManager").GetComponent<StageManager>().Map;
        float tilePos = map.GetTilePosition(player);
        m_Index = map.GetMapIndex(player);

        // ノーツマス侵入時
        if (m_Index != m_OldIndex)
        {
            m_Success = false;
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Singleton<Pad>.Instance.IsClick_ABXY()) && !m_Success)
        {
            m_Success = true;
            StartCoroutine(NoteActionDrawStart());
            Singleton<SoundPlayer>.Instance.PlaySE("se");
        }

        m_OldIndex = m_Index;
    }

    IEnumerator NoteActionDrawStart()
    {
        GameObject NoteActionImage = GameObject.Find("Canvas").transform.Find("NoteActionImage").gameObject;
        if (DrawPos)
        {
            GameObject Player = GameObject.Find("Player");
            GameObject Stage = GameObject.Find("Stage");
            float CellLength = Stage.GetComponent<Grid>().cellSize.x;
            Vector3 ImagePos = Player.transform.position;
            ImagePos.y += CellLength;
            NoteActionImage.transform.position = ImagePos;
        }

        NoteActionImage.SetActive(true);

        yield return new WaitForSeconds(DrawTime);

        NoteActionImage.SetActive(false);
    }
}
