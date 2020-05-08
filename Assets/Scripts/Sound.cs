using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioClip audioClip;         // 再生する音楽

    // AudioSource
    private AudioSource audioSource;
    [HeaderAttribute("AudioSourceの設定")]
    public bool PlayOnAwake = false;    // 有効になったときに再生
    public ushort Priority = 0;         // 再生優先度

    [Range(0.0f, 1.0f)]
    public float volime = 1.0f;         // 音量
    public bool loop = true;            // ループ

    // ゲーム的な設定
    [HeaderAttribute("その他ゲーム的なの設定")]
    public ushort bpm = 0;              // BPM    
    public ushort timingOffset = 0;     // タイミングをガバガバにするやつ 
    public float startOffset = 0.0f;    // 再生開始位置


    // 処理に使う変数たち
    private bool active = false;
    private uint activeCount = 0;
    private uint activeTimeCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        // 動的にコンポーネントを追加
        gameObject.AddComponent<AudioSource>();
        // コンポーネントを結び付け
        audioSource = GetComponent<AudioSource>();

        // 設定の適用
        audioSource.playOnAwake = PlayOnAwake;
        audioSource.priority = Priority;
        audioSource.volume = volime;
        audioSource.clip = audioClip;
        audioSource.loop = loop;
        audioSource.time = 0.0f;

        bpm = (ushort)(60 * 60 / bpm);
        activeCount = 0;
        Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying && loop)
        {
            activeCount = 0;
            Play();
        }

        if ((uint)((audioSource.time + startOffset) * 60) > bpm * (activeCount + 1) - timingOffset)
        {
            active = true;
            activeCount++;
            activeTimeCount = 0;

            //Debug.Log("audioSouce.time :" + audioSource.time);
            //Debug.Log(activeCount + "True");
        }

        // 有効時
        if (active)
        {
            if (activeTimeCount > timingOffset * 2)
            {
                active = false;
            }
            activeTimeCount++;
        }


        //Debug.Log("再生秒数");
        //Debug.Log(audioSource.time);
        //Debug.Log((int)(audioSource.time * 60));
    }

    public bool IsActive()
    {
        return active;
    }

    // 再生
    public void Play()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    // 指定位置からの再生
    public void Play(float offset)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.time = offset;
            audioSource.Play();
        }
    }

    public void Stop()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    public void Pause()
    {
        audioSource.Pause();
    }

    public void UnPause()
    {
        audioSource.UnPause();
    }
}
