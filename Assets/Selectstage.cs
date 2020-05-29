using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine;

public class Selectstage : MonoBehaviour
{
    public void OnClick()
    {
        FadeManager.Instance.LoadScene("Stageselect", 2.0f);
    }
}
