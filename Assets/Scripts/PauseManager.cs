using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    // ポーズ対象のスクリプト
    static List<PauseManager> targets = new List<PauseManager>();

    // ポーズ対象のコンポーネント
    Behaviour[] pauseBehavs = null;

    // Start is called before the first frame update
    void Start()
    {
        targets.Add(this);
    }

    // 破棄されるとき
    void OnDestroy()
    {
        if(pauseBehavs != null){
            return;
        }
    }

    // ポーズされたとき
    void OnPause()
    {
        if (pauseBehavs != null){
            return;
        }

        // 有効なBehaviourを取得
        pauseBehavs = Array.FindAll(GetComponentsInChildren<Behaviour>(), (obj) => { return obj.enabled; });

        foreach(var com in pauseBehavs){
            if(com.tag != "MainCamera")
            com.enabled = false;
        }
     }

    // ポーズ解除されたとき
    void OnResume()
    {
        if(pauseBehavs == null){
            return;
        }

        // ポーズ前の状態にBehaviourの有効状態を復元
        foreach (var com in pauseBehavs)
        {
            com.enabled = true;
        }

        pauseBehavs = null;
    }

    // ポーズ
    public static void Pause()
    {
        foreach(var obj in targets)
        {
            obj.OnPause();
        }
    }

    // ポーズ解除
    public static void Resume()
    {
        foreach (var obj in targets)
        {
            obj.OnResume();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
