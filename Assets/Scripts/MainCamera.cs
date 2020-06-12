﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public bool RPGCamera;
    private GameObject Player = null;
    private GameObject Stage = null;
    private Map map = null;
    private float CellLength = 0;

    private bool m_Active = false;
    public bool Active
    {
        set { m_Active = value; }
    }

    public void Initialize()
    {
        this.Player = GameObject.Find("Player");
        this.map = GameObject.Find("Stage").GetComponent<Map>();
        this.Stage = GameObject.Find("Stage");
        CellLength = Stage.GetComponent<Grid>().cellSize.x;

        m_Active = true;
    }

    void Update()
    {
        if (!m_Active)
        {
            return;
        }

        if (Player == null)
        {
            this.Player = GameObject.Find("Player");
        }

        if (map == null)
        {
            this.map = GameObject.Find("Stage").GetComponent<Map>();
        }

        if (Stage == null)
        {
            this.Stage = GameObject.Find("Stage");
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
