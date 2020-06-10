using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    AudioSource m_Music;

    // Start is called before the first frame update
    void Start()
    {
        m_Music = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(m_Music.time);
    }
}
