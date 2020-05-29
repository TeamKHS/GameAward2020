using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public bool RPGCamera;
    private GameObject Player = null;
    private GameObject Stage = null;
    private Map map = null;
    private float CellLength = 0;
    void Update()
    {
        if (Player == null)
        {
            this.Player = GameObject.Find("Player(Clone)");
        }

        if (map == null)
        {
            this.map = GameObject.Find("Stage03(Clone)").GetComponent<Map>();
        }

        if (Stage == null)
        {
            this.Stage = GameObject.Find("Stage03(Clone)");
            CellLength = Stage.GetComponent<Grid>().cellSize.x;
        }

        Vector3 CameraPos = Player.transform.position;

        CameraPos.z = -10.0f;

        if (RPGCamera)
        {
            Vector2 min = Camera.main.ViewportToWorldPoint(Vector2.zero);
            Vector2 max = Camera.main.ViewportToWorldPoint(Vector2.one);

            CameraPos.x = Mathf.Clamp(CameraPos.x, (max.x - min.x)/2, map.m_MapX * CellLength -(max.x - min.x)/2);
            CameraPos.y = Mathf.Clamp(CameraPos.y, -map.m_MapY * CellLength + (max.y - min.y) / 2, -(max.y - min.y) / 2);
        }

        transform.position = CameraPos;
    }
}
