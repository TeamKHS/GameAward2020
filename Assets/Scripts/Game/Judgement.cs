using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judgement : MonoBehaviour
{
    private Map m_Map;

    // Start is called before the first frame update
    public void Initialize()
    {
        {
            GameObject obj = GameObject.Find("StageManager");
            StageManager stageManager = obj.GetComponent<StageManager>();
            m_Map = stageManager.Map;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Wall()
    {
    }

    public void Hole()
    {

    }

    public void Goal()
    {

    }
}
