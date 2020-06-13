using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ChoiceKey : MonoBehaviour
{
    Button button;
    

    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Title")
        {
            button = GameObject.Find("Canvas/Buttons/Start").GetComponent<Button>();
            button.Select();
        }

        if (SceneManager.GetActiveScene().name == "Stageselect")
        {
            button = GameObject.Find("Canvas/Buttons/Stage1").GetComponent<Button>();
            button.Select();
        }

        if (SceneManager.GetActiveScene().name == "Stageclear")
        {
            button = GameObject.Find("Canvas/Buttons/NextStage").GetComponent<Button>();
            button.Select();
        }

        if (SceneManager.GetActiveScene().name == "Gameover")
        {
            button = GameObject.Find("Canvas/Buttons/Retry").GetComponent<Button>();
            button.Select();
        }
    }
}
