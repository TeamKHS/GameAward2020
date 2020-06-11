using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public void Action(Player player)
    {
        Debug.Log("ArrowAction");
        Map map = GameObject.Find("StageManager").GetComponent<StageManager>().Map;

        Debug.Log(map.GetTilePosition(player));

        if (0.9f <= map.GetTilePosition(player))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("NoteAction:Success");
                player.PlayerStop();
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
                player.PlayerMove(Player.DirectionType.Right);
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                player.PlayerMove(Player.DirectionType.Left);
            if (Input.GetKeyDown(KeyCode.UpArrow))
                player.PlayerMove(Player.DirectionType.Up);
            if (Input.GetKeyDown(KeyCode.DownArrow))
                player.PlayerMove(Player.DirectionType.Down);
        }
    }
}
