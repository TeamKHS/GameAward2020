using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    private static int stageIndex = 0;
    public static int StageIndex
    {
        get { return stageIndex; }
        set { stageIndex = value; }
    }

    private Map map;
    // Start is called before the first frame update
    void Start()
    {
        // プレハブからGameObject型を取得
        {
            GameObject map = null;

            switch (stageIndex)
            {
                case 0:
                    map = (GameObject)Resources.Load("Stage01");
                    break;

                case 1:
                    break;
            }

            // インスタンスを生成
            Instantiate(map, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
        }

        // Mapの初期化
        {
            GameObject map = GameObject.Find("WallFactory");
            Map script = map.GetComponent<Map>();
            script.Initialize();
        }

        // Playerの初期化


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
