using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public void Action(Player player)
    {
        Map map = GameObject.Find("StageManager").GetComponent<StageManager>().Map;

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
