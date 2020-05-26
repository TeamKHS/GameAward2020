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
                map = (GameObject)Resources.Load("Stage02");
                break;

            case 1:
                break;
        }

        // インスタンスを生成
        Instantiate(map, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);

        m_Map = map.GetComponent<Map>();
        m_Map.Initialize();

        GameObject player = (GameObject)Resources.Load("Player");
        Instantiate(player, m_Map.StartPosition, Quaternion.identity);

        {
            GameObject obj = GameObject.Find("Judgement");
            Judgement judgement = obj.GetComponent<Judgement>();
            judgement.Initialize();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
