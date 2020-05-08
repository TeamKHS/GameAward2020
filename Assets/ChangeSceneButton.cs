using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine;

public class ChangeSceneButton : MonoBehaviour
{

    public void OnClick()
    {
		FadeManager.Instance.LoadScene("SampleScene", 2.0f);
    }

}
