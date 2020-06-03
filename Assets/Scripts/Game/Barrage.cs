using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrage : MonoBehaviour
{
    bool active = false;
    bool old = false;

    private int num = 0;

    public void Action()
    {
        active = true;
    }

    void Update()
    {
        if (active && !old)
        {
            Debug.Log("連打マス突入");
            num = 0;
        }

        if (active && old && Input.GetKeyDown(KeyCode.Space))
        {
            num += 1;
        }
        Debug.Log("num = " + num);

        if (!active && old)
        {
            Debug.Log("連打マス脱出");
        }

        old = active;
        active = false;
    }
}
