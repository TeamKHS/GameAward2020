using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judgement : MonoBehaviour
{
    private Map m_Map;

    // Start is called before the first frame update
    public void Initialize()
    {
        GameObject obj = GameObject.Find("StageManager");
        StageManager stageManager = obj.GetComponent<StageManager>();
        m_Map = stageManager.Map;

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void PlayerJudgement(Vector3 position, int index)
    {
        int value = 0;

        switch (index)
        {
            case 0:
                // →
                value = 1;

                break;

            case 1:
                // ←
                value = -1;
                break;

            case 2:
                // ↑
                value = -m_Map.m_MapX;
                break;

            case 3:
                // ↓
                value = m_Map.m_MapX;
                break;
        }

        int[] map = m_Map.GetMap;
        int playerIndex = m_Map.GetMapIndex(position);
        bool hit = false;

        for (int i = 0; !hit; i++)
        {
            int nextIndex = playerIndex + i * value;

            if (map[nextIndex] == (int)Map.MapType.Floor)
            {
                continue;
            }
            
            switch (map[nextIndex])
            {
                case (int)Map.MapType.Wall:

                    break;

                case (int)Map.MapType.Hole:

                    break;

                case (int)Map.MapType.Goal:

                    break;
            }
            break;
        }
    }
}
