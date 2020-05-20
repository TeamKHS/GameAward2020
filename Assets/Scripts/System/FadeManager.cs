using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;


//フェードイン・アウトを制御するクラ
public class FadeManager : MonoBehaviour
{

    private static FadeManager instance;

    public static FadeManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (FadeManager)FindObjectOfType(typeof(FadeManager));
            }

            return instance;
        }
    }


    //透明度
    private float fadeAlpha = 0;
	//フェード中判定
	private bool isFading = false;
	//色
	public Color fadeColor = Color.black;


	public void Awake()
	{
		if (this != Instance)
		{
			Destroy(this.gameObject);
			return;
		}

		DontDestroyOnLoad(this.gameObject);
	}

	public void OnGUI()
	{

		// フェード
		if (this.isFading)
		{
			//色と透明度を更新
			this.fadeColor.a = this.fadeAlpha;
			GUI.color = this.fadeColor;
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Texture2D.whiteTexture);
		}
	}

	// 画面遷移
	public void LoadScene(string scene, float interval)
	{
		StartCoroutine(TransScene(scene, interval));
	}

	// シーン遷移用コルーチン
	private IEnumerator TransScene(string scene, float interval)
	{
		//だんだん暗く
		this.isFading = true;
		float time = 0;
		while (time <= interval)
		{
			this.fadeAlpha = Mathf.Lerp(0f, 1f, time / interval);
			time += Time.deltaTime;
			yield return 0;
		}

		//シーン切替
		SceneManager.LoadScene(scene);

		//だんだん明るく
		time = 0;
		while (time <= interval)
		{
			this.fadeAlpha = Mathf.Lerp(1f, 0f, time / interval);
			time += Time.deltaTime;
			yield return 0;
		}

		this.isFading = false;
	}
}

