using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    private static int m_StageIndex = 0;
    public static int StageIndex
    {
        get { return m_StageIndex; }
        set { m_StageIndex = value; }
    }

    private Map m_Map;
    public Map Map
    {
        get { return m_Map; }
    }

    // Start is called before the first frame update
    void Start()
    {
        // プレハブからGameObject型を取得    
        GameObject map = null;

        switch (m_StageIndex)
        {
            case 0:
                Stage00(ref map);
                break;

            case 1:
                break;
        }

        // インスタンスを生成
        {
            map = Instantiate(map, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
            map.name = "Stage";

            m_Map = map.GetComponent<Map>();
            m_Map.Initialize();

            GameObject player = (GameObject)Resources.Load("Player");
            player = Instantiate(player, m_Map.StartPosition, Quaternion.identity);
            player.name = "Player";
        }

        {
            GameObject obj = GameObject.Find("Judgement");
            Judgement judgement = obj.GetComponent<Judgement>();
            judgement.Initialize();
        }

        MainCamera camera = GameObject.Find("Main Camera").GetComponent<MainCamera>();
        camera.Initialize();
    }

    private void Stage00(ref GameObject map)
    {
        map = (GameObject)Resources.Load("Stage04");

        Singleton<SoundPlayer>.Instance.AddResource("music", "taiko");
        //Singleton<SoundPlayer>.Instance.AddResource("music", "00015_heaven-and-hell");
        Singleton<SoundPlayer>.Instance.AddResource("se", "cursor1");

        Singleton<SoundPlayer>.Instance.SetBGM("music");
        Singleton<SoundPlayer>.Instance.PlayBGM();
    }
}
