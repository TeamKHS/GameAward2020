using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    private bool active = true;
    private int oldIndex = 0;

    public void Action(Player player)
    {
        Map map = GameObject.Find("StageManager").GetComponent<StageManager>().Map;
        int index = map.GetMapIndex(GameObject.Find("Player"));
        if (index != oldIndex)
        {
            active = true;
        }
        oldIndex = index;

        if (map.GetTilePosition(player) >= 0.8f)
        {
            if (active) Singleton<SoundPlayer>.Instance.Play("se");
            active = false;
        }
    }
}
