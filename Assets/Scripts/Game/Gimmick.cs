using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick : MonoBehaviour
{
    private Map.MapType m_Active;
    private Map.MapType m_OldActive;

    void Start()
    {
        m_Active = m_OldActive = Map.MapType.Non;       
    }


    public void Action(Map.MapType type, Player player)
    {
        m_Active = type;

        // 切り替わった
        if (m_Active != m_OldActive)
        {
            Note note = this.GetComponent<Note>();

            if (!note.Success)
            {
                Judgement judgement = GameObject.Find("Judgement").GetComponent<Judgement>();
                judgement.Miss();

            }
        }


        switch (type)
        {
            case Map.MapType.Note:
                NoteAction(player);
                break;

            case Map.MapType.Arrow:
                ArrowAction(player);
                break;

            case Map.MapType.Barrage:
                BarrageAction();
                break;
        }

        m_OldActive = m_Active;
    }

    private void NoteAction(Player player)
    {
        Note note = this.GetComponent<Note>();
        note.Action(player);
    }

    private void ArrowAction(Player player)
    {
        Arrow arrow = this.GetComponent<Arrow>();
        arrow.Action(player);
    }

    private void BarrageAction()
    {
        this.GetComponent<Barrage>().Action();
    }
}
