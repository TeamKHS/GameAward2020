using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public void Action(Player player)
    {
        Debug.Log("NoteAction");
        Map map = GameObject.Find("StageManager").GetComponent<StageManager>().Map;

        Debug.Log(map.GetTilePosition(player));

        if (map.GetTilePosition(player) <= 0.8f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("NoteAction:Success");
                player.PlayerStop();
            }
        }
    }
}
