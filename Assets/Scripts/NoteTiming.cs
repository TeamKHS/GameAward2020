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
        //if (section >= 24)
        //{
        //    if ((beats - 4) < 0)
        //    {
        //        beats += 4;
        //        section -= 1;
        //    }else
        //    {
        //        beats -= 4;
        //    }
        //}

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
        m_Timing.Add(offset + 6.8f + Timing(4, 4, hatibu, 40, 0));
        m_Timing.Add(offset + 6.8f + Timing(4, 4, hatibu, 40, 4));
        m_Timing.Add(offset + 6.8f + Timing(4, 4, hatibu, 41, 0));
        m_Timing.Add(offset + 6.8f + Timing(4, 4, hatibu, 43, 4));
        m_Timing.Add(-1.0f);
    }


    private float Timing(int section, int beat)
    {
        float timing = 0.0f;
        float BPM = 0.0f;
        float value = 0.0f;

        // 60.0f / BPM : 四分音符

        //if (section <= 16)
        //{
            BPM = 160.0f;
           // BPM = 172.0f;
            value = BPM / 60.0f / 16;

            timing += value * 8 * section;
            timing += value * beat;
        //}
        //else
        //{
        //    BPM = 160.0f;
        //    value = 60.0f / BPM / 2.0f;
        //    timing += value * 8 * 16;
        //    section -= 16;

        //    BPM = 172.0f;
        //    value = 60.0f / BPM / 2.0f;

        //    timing += value * 8 * section;
        //    timing += value * beat;
        //}

        return timing;
    }
    private void Stage02()
    {
        float offset = 0.0f;

        //        m_Timing.Add(offset + Timing(9, 4));
        m_Timing.Add(offset + Timing(18, 0));
        m_Timing.Add(offset + Timing(100, 0));
    }
}


