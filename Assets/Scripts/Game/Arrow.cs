using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public void Action(Player player)
    {
        Map map = GameObject.Find("StageManager").GetComponent<StageManager>().Map;

        if (0.9f <= map.GetTilePosition(player))
        {
            if (player.IsMove)
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
                player.PlayerMove(Player.DirectionType.Right);
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                player.PlayerMove(Player.DirectionType.Left);
            if (Input.GetKeyDown(KeyCode.UpArrow))
                player.PlayerMove(Player.DirectionType.Up);
            if (Input.GetKeyDown(KeyCode.DownArrow))
                player.PlayerMove(Player.DirectionType.Down);

            // 縦
            if (Input.GetAxis("Vertical") < -0.1f)
                player.PlayerMove(Player.DirectionType.Up);
            if (Input.GetAxis("Vertical") > 0.1f)
                player.PlayerMove(Player.DirectionType.Down);

            // 横
            if (Input.GetAxis("Horizontal") > 0.1f)
                player.PlayerMove(Player.DirectionType.Right);
            if (Input.GetAxis("Horizontal") < -0.1f)
                player.PlayerMove(Player.DirectionType.Left);

        }
    }
}
