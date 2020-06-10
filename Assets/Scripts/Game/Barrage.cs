using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Barrage : MonoBehaviour
{
    bool active = false;
    bool old = false;

    public int score = 0;       //残り連打数
    public Text score_Text;


    public void Action()
    {
        active = true;
    }

    void Start() {
        score_Text = GameObject.FindObjectOfType<Text>();
        //GameObject canvas = GameObject.Find("Canvas").transform.parent.gameObject;

        score_Text.enabled = false;     //非表示
    }

    void Update()
    {
        //連打マス突入
        if (active && !old)
        {
            Debug.Log("連打マス突入");
            score = 2;
            score_Text.enabled = true;  //表示
        }

        //連打したときの処理
        if (active && old)
        {
            score_Text.text = "あと" + score + "回！";
        }
        if (active && old && Input.GetKeyDown(KeyCode.Space) && score > 0)
        {
            score -= 1;
            score_Text.text = "あと" + score.ToString() + "回！";
        }
        else if (score <= 0)
        {
            score_Text.text = "クリア！！";
        }

        //連打の分岐処理
        if (!active && old && score <= 0)
        {
            score_Text.enabled = false; //非表示
            Debug.Log("連打マス脱出");
        }
        else if (!active && old && score > 0)
        {
            score_Text.enabled = false; //非表示
            Debug.Log("ダメです");


            //ゲームオーバー画面へ遷移


        }

        ////連打マスの上でタップ
        //if (active && old && Input.GetKeyDown(KeyCode.Space))
        //{
        //    score += 1;
        //}
        //Debug.Log("num = " + num);

        old = active;
        active = false;
    }
}
