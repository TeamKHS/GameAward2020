using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Player : MonoBehaviour
{

    Vector3 direction;
    public AudioClip sound;
    AudioSource audioSource;
    const int bpm = 60;
    int frame = 0;

    Map m_Map;
    GameObject respone;

    GameObject bgm;
    Sound soundScript;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        {
            GameObject obj = GameObject.Find("StageManager");
            StageManager stageManager = obj.GetComponent<StageManager>();
            m_Map = stageManager.Map;
        }


        respone = GameObject.Find("Respone");

        bgm = GameObject.Find("Sound");
        soundScript = bgm.GetComponent<Sound>();
    }


    async void Respone(int Index)
    {
        await Task.Delay(1000);
        int[] map = m_Map.GetMap;

        if (map[Index] == (int)Map.MapType.Hole)
        {
            this.transform.position = respone.transform.position;
        }
    }

    void Update()
    {
        // マップ情報
        int[] map = m_Map.GetMap;
        int mapX = m_Map.m_MapX;
        int mapY = m_Map.m_MapY;


        bool move = false;
        int dir = 0;

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            dir = 1;
            move = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            dir = -1;
            move = true;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            dir = -mapX;
            move = true;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            dir = mapX;
            move = true;
        }

        // オレの位置
        int index = m_Map.GetMapIndex((Vector2)this.transform.position);

        for (int i = 1; move; i++)
        {
            int nextIndex = index + i * dir;
            Vector3 nextPosition;

            if (map[nextIndex] == (int)Map.MapType.Floor || map[nextIndex] == (int)Map.MapType.Non)
            {
                continue;
            }

            switch (map[nextIndex])
            {
                case (int)Map.MapType.Wall:
                    nextIndex -= dir;

                    // 配列番号から位置を算出
                    nextPosition = m_Map.GetMapPosition(nextIndex);

                    // 位置更新
                    this.transform.position = nextPosition;

                    break;

                case (int)Map.MapType.Hole:
                    // 配列番号から位置を算出
                    nextPosition = m_Map.GetMapPosition(nextIndex);

                    // 位置更新
                    this.transform.position = nextPosition;

                    break;

                case (int)Map.MapType.Goal:
                    // 配列番号から位置を算出
                    nextPosition = m_Map.GetMapPosition(nextIndex);

                    // 位置更新
                    this.transform.position = nextPosition;

                    break;
            }
            break;
        }




        // ゴールだったら
        if (map[index] == (int)Map.MapType.Goal)
        {
            Debug.Log("それってゴールかい？");
        }

        Respone(index);
    }

}
