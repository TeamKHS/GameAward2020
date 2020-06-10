using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float DrawTime = 1.0f;
    public bool DrawPos = true;

    public void Action(Player player)
    {
        Debug.Log("NoteAction");
        Map map = GameObject.Find("StageManager").GetComponent<StageManager>().Map;

        Debug.Log(map.GetTilePosition(player));

        if (map.GetTilePosition(player) <= 0.8f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("NoteAction:Success");
                StartCoroutine(NoteActionDrawStart());
                player.PlayerStop();
            }
        }
    }

    IEnumerator NoteActionDrawStart()
    {
        GameObject NoteActionImage = GameObject.Find("Canvas").transform.Find("NoteActionImage").gameObject;
        if (DrawPos)
        {
            GameObject Player = GameObject.Find("Player");
            GameObject Stage = GameObject.Find("Stage");
            float CellLength = Stage.GetComponent<Grid>().cellSize.x;
            Vector3 ImagePos = Player.transform.position;
            ImagePos.y += CellLength;
            NoteActionImage.transform.position = ImagePos;
        }

        NoteActionImage.SetActive(true);

        yield return new WaitForSeconds(DrawTime);

        NoteActionImage.SetActive(false);

    }

}
