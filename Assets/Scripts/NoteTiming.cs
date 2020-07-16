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

            case 1:
                Stage02();
                break;

            case 2:
                Stage01();
                break;

            case 3:
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

    private float Timing(int offsetSection, int offsetBeats, float value, int section, int beats)
    {
        float timing = 0.0f;

        if (beats - offsetBeats < 0)
        {
            beats += offsetBeats;
            section -= 1;
        }
        else
        {
            beats -= offsetBeats;
        }
        section = section - offsetSection;

        timing += (section * 8.0f) * value;
        timing += beats * value;

        return timing;
    }

    private void Stage01()
    {
        float BPM = 159.6f;
        float hatibu = 60.0f / BPM / 2.0f;
        //float offset = 4.5f;
        float offset = -1.5f;
        //float offset = 0.0f;

        m_Timing.Add(offset + 6.8f);
        m_Timing.Add(offset + 6.8f + Timing(4, 0, hatibu, 9, 4));
        m_Timing.Add(offset + 6.8f + Timing(4, 0, hatibu, 12, 0));
        m_Timing.Add(offset + 6.8f + Timing(4, 0, hatibu, 13, 4));
        m_Timing.Add(offset + 6.8f + Timing(4, 0, hatibu, 15, 0));

        m_Timing.Add(offset + 6.8f + Timing(4, 0, hatibu, 16, 0));
        m_Timing.Add(offset + 6.8f + Timing(4, 0, hatibu, 16, 4));
        m_Timing.Add(offset + 6.8f + Timing(4, 0, hatibu, 20, 0));
        m_Timing.Add(offset + 6.8f + Timing(4, 4, hatibu, 24, 4));
        m_Timing.Add(offset + 6.8f + Timing(4, 4, hatibu, 25, 4));

        m_Timing.Add(offset + 6.8f + Timing(4, 4, hatibu, 29, 0));
        m_Timing.Add(offset + 6.8f + Timing(4, 4, hatibu, 30, 0));
        m_Timing.Add(offset + 6.8f + Timing(4, 4, hatibu, 32, 0));
        m_Timing.Add(offset + 6.8f + Timing(4, 4, hatibu, 32, 4));
        m_Timing.Add(offset + 6.8f + Timing(4, 4, hatibu, 33, 4));

        m_Timing.Add(offset + 6.8f + Timing(4, 4, hatibu, 35, 2));
        m_Timing.Add(offset + 6.8f + Timing(4, 4, hatibu, 36, 0));
        m_Timing.Add(offset + 6.8f + Timing(4, 4, hatibu, 36, 4));
        m_Timing.Add(offset + 6.8f + Timing(4, 4, hatibu, 37, 0));
        m_Timing.Add(offset + 6.8f + Timing(4, 4, hatibu, 38, 4));

        m_Timing.Add(offset + 6.8f + Timing(4, 4, hatibu, 40, 4));
        m_Timing.Add(offset + 6.8f + Timing(4, 4, hatibu, 41, 0));
        m_Timing.Add(offset + 6.8f + Timing(4, 4, hatibu, 43, 4));
        m_Timing.Add(-1.0f);
    }

    private void Stage02()
    {
        float BPM = 120.0f;
        float hatibu = 60.0f / BPM / 2.0f;
        float offset = -4.1f;
        //float offset = 0.0f;

        m_Timing.Add(offset + 6.8f);
        m_Timing.Add(offset + 6.8f + Timing(0, 0, hatibu, 0, 4));
        m_Timing.Add(offset + 6.8f + Timing(0, 0, hatibu, 5, 4));
        m_Timing.Add(offset + 6.8f + Timing(0, 0, hatibu, 6, 4));
        m_Timing.Add(offset + 6.8f + Timing(0, 0, hatibu, 10, 4));

        m_Timing.Add(offset + 6.8f + Timing(0, 0, hatibu, 11, 0));
        m_Timing.Add(offset + 6.8f + Timing(0, 0, hatibu, 11, 2));
        m_Timing.Add(offset + 6.8f + Timing(0, 0, hatibu, 12, 0));
        m_Timing.Add(offset + 6.8f + Timing(0, 0, hatibu, 12, 2));
        m_Timing.Add(offset + 6.8f + Timing(0, 0, hatibu, 13, 0));

        m_Timing.Add(offset + 6.8f + Timing(0, 0, hatibu, 13, 2));
        m_Timing.Add(offset + 6.8f + Timing(0, 0, hatibu, 14, 4));
        m_Timing.Add(offset + 6.8f + Timing(0, 8, hatibu, 17, 0));
        m_Timing.Add(offset + 6.8f + Timing(0, 8, hatibu, 19, 4));
        m_Timing.Add(offset + 6.8f + Timing(0, 8, hatibu, 20, 0));
                                               
        m_Timing.Add(offset + 6.8f + Timing(0, 8, hatibu, 22, 2));
        m_Timing.Add(offset + 6.8f + Timing(0, 8, hatibu, 24, 0));
        m_Timing.Add(offset + 6.8f + Timing(0, 8, hatibu, 24, 6));
        m_Timing.Add(-1.0f);
    }
}


