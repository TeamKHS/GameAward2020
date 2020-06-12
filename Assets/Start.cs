using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine;
public class Start : MonoBehaviour
{
    public void OnClick()
    {
        StageManager.StageIndex = 0;
        FadeManager.Instance.LoadScene("Game", 2.0f);
    }
}
