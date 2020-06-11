using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleTex : MonoBehaviour
{
    public float move_width;
    public float move_height;
    public float scale;
    public int move_loop_frame;
    public int scale_loop_frame;
    private int move_count = 0;
    private bool move_flag = false;
    private int scale_count = 0;
    private bool scale_flag = false;
    private Vector3 old_pos;
    private Vector3 old_scale;

    private void Start()
    {
        old_pos = transform.position;
        old_scale = transform.localScale;
    }

    void Update()
    {
        if (move_count == 0)
        {
            move_flag = false;
        }
        else if(move_count == move_loop_frame)
        {
            move_flag = true;
        }
        if (move_flag)
        {
            move_count--;
        }
        else
        {
            move_count++;
        }


        if (scale_count == 0)
        {
            scale_flag = false;
        }
        else if (scale_count == scale_loop_frame)
        {
            scale_flag = true;
        }
        if (scale_flag)
        {
            scale_count--;
        }
        else
        {
            scale_count++;
        }
        int change_pos = move_count - (move_loop_frame / 2);
        int change_scale = scale_count;

        Vector3 new_pos = old_pos;
        Vector3 new_scale = old_scale;
        new_pos.x += move_width * change_pos;
        new_pos.y += move_height * change_pos;
        new_scale.x += scale * change_scale;
        new_scale.y += scale * change_scale;
        transform.position = new_pos;
        transform.localScale = new_scale;
    }
}
