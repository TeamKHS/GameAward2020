using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick : MonoBehaviour
{
    public void Action(Map.MapType type, Player player)
    {
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
