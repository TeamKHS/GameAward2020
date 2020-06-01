using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine;

public class BackToTitle : MonoBehaviour
{
    public void OnClick()
    {
        FadeManager.Instance.LoadScene("Title", 2.0f);
    }
}
