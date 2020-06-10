using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteTiming : MonoBehaviour
{
    private List<float> m_Timing;
    private int m_Called;   

    public void Initialize(int stageIndex)
    {
        m_Timing = new List<float>();
        m_Called = 0;

        switch (stageIndex)
        {
            case 0:
                Stage01();
                break;
        }
    }

    public float GetTiming()
    {
        if (m_Timing.Count <= m_Called)
        {
            return -1.0f;
        }
        float timing = m_Timing[m_Called];
        m_Called++;

        return timing;
    }

    private void Stage01()
    {
        // ここにタイミングを書き込む
        //m_Timing.Add(10.0f);
        //m_Timing.Add(20.0f);
        //m_Timing.Add(30.0f);
        //m_Timing.Add(40.0f);
        //m_Timing.Add(50.0f);

        for(int i = 1;i<30;i++)
        {
            m_Timing.Add(3.0f * i);
        }
    }
}
