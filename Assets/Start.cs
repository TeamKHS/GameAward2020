using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine;
public class Start : MonoBehaviour
{
    public void OnClick()
    {
        FadeManager.Instance.LoadScene("Main", 2.0f);
    }
}
