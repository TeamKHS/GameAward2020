using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField]
    GameObject  m_Image;

    [SerializeField]
    GameObject m_Canvas;

    // Start is called before the first frame update
    void Start()
    {
        GameObject prefab = (GameObject)Instantiate(m_Image);
        prefab.transform.SetParent(m_Canvas.transform, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
