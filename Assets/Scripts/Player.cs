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

    GameObject map;
    Map script;
    GameObject respone;

    GameObject bgm;
    Sound soundScript;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        map = GameObject.Find("WallFactory");
        script = map.GetComponent<Map>();

        respone = GameObject.Find("Respone");

        bgm = GameObject.Find("Sound");
        soundScript = bgm.GetComponent<Sound>();
    }


    async void Respone(int Index)
    {
        await Task.Delay(1000);
        int[] map = script.GetMap;

        if (map[Index] == (int)Map.MapType.Hole)
        {
            this.transform.position = respone.transform.position;
        }
    }

    void Update()
    {
         // マップ情報
         int[] map = script.GetMap;
         int mapX = script.m_MapX;
         int mapY = script.m_MapY;
        
         // オレの位置
         int index = script.GetMapIndex((Vector2)this.transform.position);

        if (soundScript.IsActive())
        {
            MeshRenderer mr = GetComponent<MeshRenderer>();
            Color col;
            col.r = 1.0f;
            col.g = col.b = 0.0f;
            col.a = 1.0f;
            mr.material.color = col;

            // 右トリガー入力 
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                Debug.Log("よう！それって右かい？");
                // 壁にぶつかった
                bool hit = false;
                int nextIndex = 0;

                for (int i = 0; !hit; i++)
                {
                    nextIndex = index + i;


                    // 穴だったら
                    if (map[nextIndex] == (int)Map.MapType.Hole)
                    {
                        hit = true;
                        Debug.Log("それって穴かい？");

                        // 配列番号から位置を算出
                        Vector3 nextPos;
                        nextPos.x = (float)(nextIndex % mapX) + 0.5f;
                        nextPos.y = ((float)(nextIndex / mapX) + 0.5f) * -1.0f;
                        nextPos.z = 0.0f;

                        // 位置更新
                        this.transform.position = nextPos;
                    }

                    // 進む先が壁だったら
                    if (map[nextIndex] == (int)Map.MapType.Wall)
                    {
                        hit = true;
                        nextIndex--;

                        // 配列番号から位置を算出
                        Vector3 nextPos;
                        nextPos.x = (float)(nextIndex % mapX) + 0.5f;
                        nextPos.y = ((float)(nextIndex / mapX) + 0.5f) * -1.0f;
                        nextPos.z = 0.0f;

                        // 位置更新
                        this.transform.position = nextPos;
                    }
                }

            }

            // 左トリガー入力
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                Debug.Log("よう！それって左かい？");
                // 壁にぶつかった
                bool hit = false;
                int nextIndex = 0;

                for (int i = 0; !hit; i++)
                {
                    nextIndex = index - i;

                    // 穴だったら
                    if (map[nextIndex] == (int)Map.MapType.Hole)
                    {
                        hit = true;
                        Debug.Log("それって穴かい？");

                        // 配列番号から位置を算出
                        Vector3 nextPos;
                        nextPos.x = (float)(nextIndex % mapX) + 0.5f;
                        nextPos.y = ((float)(nextIndex / mapX) + 0.5f) * -1.0f;
                        nextPos.z = 0.0f;

                        // 位置更新
                        this.transform.position = nextPos;
                    }

                    // 進む先が壁だったら
                    if (map[nextIndex] == (int)Map.MapType.Wall)
                    {
                        hit = true;
                        nextIndex++;

                        // 配列番号から位置を算出
                        Vector3 nextPos;
                        nextPos.x = (float)(nextIndex % mapX) + 0.5f;
                        nextPos.y = ((float)(nextIndex / mapX) + 0.5f) * -1.0f;
                        nextPos.z = 0.0f;

                        // 位置更新
                        this.transform.position = nextPos;

                    }
                }

            }

            // 上トリガー入力
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                Debug.Log("よう！それって上かい？");
                // 壁にぶつかった
                bool hit = false;
                int nextIndex = 0;

                for (int i = 0; !hit; i++)
                {
                    nextIndex = index - i * mapX;


                    // 穴だったら
                    if (map[nextIndex] == (int)Map.MapType.Hole)
                    {
                        hit = true;
                        Debug.Log("それって穴かい？");

                        // 配列番号から位置を算出
                        Vector3 nextPos;
                        nextPos.x = (float)(nextIndex % mapX) + 0.5f;
                        nextPos.y = ((float)(nextIndex / mapX) + 0.5f) * -1.0f;
                        nextPos.z = 0.0f;

                        // 位置更新
                        this.transform.position = nextPos;
                    }

                    // 進む先が壁だったら
                    if (map[nextIndex] == (int)Map.MapType.Wall)
                    {
                        hit = true;
                        nextIndex += mapX;

                        // 配列番号から位置を算出
                        Vector3 nextPos;
                        nextPos.x = (float)(nextIndex % mapX) + 0.5f;
                        nextPos.y = ((float)(nextIndex / mapX) + 0.5f) * -1.0f;
                        nextPos.z = 0.0f;

                        // 位置更新
                        this.transform.position = nextPos;
                    }
                }

            }

            // 下トリガー入力
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                Debug.Log("よう！それって下かい？");
                // 壁にぶつかった
                bool hit = false;
                int nextIndex = 0;

                for (int i = 0; !hit; i++)
                {
                    nextIndex = index + i * mapX;


                    // 穴だったら
                    if (map[nextIndex] == (int)Map.MapType.Hole)
                    {
                        hit = true;
                        Debug.Log("それって穴かい？");

                        // 配列番号から位置を算出
                        Vector3 nextPos;
                        nextPos.x = (float)(nextIndex % mapX) + 0.5f;
                        nextPos.y = ((float)(nextIndex / mapX) + 0.5f) * -1.0f;
                        nextPos.z = 0.0f;

                        // 位置更新
                        this.transform.position = nextPos;
                    }

                    // 進む先が壁だったら
                    if (map[nextIndex] == (int)Map.MapType.Wall)
                    {
                        hit = true;
                        nextIndex -= mapX;

                        // 配列番号から位置を算出
                        Vector3 nextPos;
                        nextPos.x = (float)(nextIndex % mapX) + 0.5f;
                        nextPos.y = ((float)(nextIndex / mapX) + 0.5f) * -1.0f;
                        nextPos.z = 0.0f;

                        // 位置更新
                        this.transform.position = nextPos;
                    }
                }

            }
        }
        else
        {
            MeshRenderer mr = GetComponent<MeshRenderer>();
            Color col;
            col.r = col.g = col.b = col.a = 1.0f;
            mr.material.color = col;
        }

        // ゴールだったら
        if (map[index] == (int)Map.MapType.Goal)
        {
            Debug.Log("それってゴールかい？");
        }

        Respone(index);
    }

}
