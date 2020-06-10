using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer
{
    GameObject m_SoundPlayer;
    AudioSource m_AudioSource;
    Dictionary<string, AudioClipInfo> m_AudioClips = new Dictionary<string, AudioClipInfo>();

    class AudioClipInfo
    {
        public string resourceName;
        public string name;
        public AudioClip clip;

        public AudioClipInfo(string resourceName, string name)
        {
            this.resourceName = resourceName;
            this.name = name;
        }
    }

    public bool Play(string name)
    {
        if (m_AudioClips.ContainsKey(name) == false)
        {
            return false;
        }

        m_AudioSource.PlayOneShot(m_AudioClips[name].clip);

        return true;
    }

    public void AddResource(string key, string name)
    {
        m_AudioClips.Add(key, new AudioClipInfo(name, key));

        if (!Load(key))
        {
            Debug.Log("ロード失敗");
        }
    }

    private bool Load(string key)
    {
        AudioClipInfo info = m_AudioClips[key];

        if (info.clip == null)
        {
            info.clip = (AudioClip)Resources.Load(info.resourceName);
        }

        if (m_SoundPlayer == null)
        {
            m_SoundPlayer = new GameObject("SoundPlayer");
            m_AudioSource = m_SoundPlayer.AddComponent<AudioSource>();
        }

        return true;
    }

    public void Release()
    {
        m_AudioClips.Clear();
    }
}
