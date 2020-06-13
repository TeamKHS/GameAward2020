using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad
{
    private int m_Vertical = 0;
    private int m_Horizontal = 0;
    private int m_OldVertical = 0;
    private int m_OldHorizontal = 0;


    public void PadUpdate()
    {
        m_OldVertical = m_Vertical;
        m_OldHorizontal = m_Horizontal;

        m_Vertical = (int)Input.GetAxis("Vertical");
        m_Horizontal = (int)Input.GetAxis("Horizontal");

        Debug.Log("Vertical:" + Input.GetAxis("Vertical").ToString());
        Debug.Log("Horizontal:" + Input.GetAxis("Horizontal").ToString());
    }

    public bool IsClick_Right()
    {
        return m_Horizontal == 1 && m_OldHorizontal != 1;
    }
    public bool IsPress_Right()
    {
        return m_Horizontal == 1 && m_OldHorizontal == 1;
    }
    public bool IsRelease_Right()
    {
        return m_Horizontal != 1 && m_OldHorizontal == 1;
    }

    public bool IsClick_Left()
    {
        return m_Horizontal == -1 && m_OldHorizontal != -1;
    }
    public bool IsPress_Left()
    {
        return m_Horizontal == -1 && m_OldHorizontal == -1;
    }
    public bool IsRelease_Left()
    {
        return m_Horizontal != -1 && m_OldHorizontal == -1;
    }

    public bool IsClick_Up()
    {
        return m_Vertical == -1 && m_OldVertical != -1;
    }
    public bool IsPress_Up()
    {
        return m_Vertical == -1 && m_OldVertical == -1;
    }
    public bool IsRelease_Up()
    {
        return m_Vertical != -1 && m_OldVertical == -1;
    }

    public bool IsClick_Down()
    {
        return m_Vertical == 1 && m_OldVertical != 1;
    }
    public bool IsPress_Down()
    {
        return m_Vertical == 1 && m_OldVertical == 1;
    }
    public bool IsRelease_Down()
    {
        return m_Vertical != 1 && m_OldVertical == 1;
    }

    public bool IsClick_A()
    {
        return Input.GetKeyDown("joystick button 0");
    }
    public bool IsPress_A()
    {
        return Input.GetKey("joystick button 0");
    }
    public bool IsRelease_A()
    {
        return Input.GetKeyUp("joystick button 0");
    }

    public bool IsClick_B()
    {
        return Input.GetKeyDown("joystick button 1");
    }
    public bool IsPress_B()
    {
        return Input.GetKey("joystick button 1");
    }
    public bool IsRelease_B()
    {
        return Input.GetKeyUp("joystick button 1");
    }

    public bool IsClick_X()
    {
        return Input.GetKeyDown("joystick button 2");
    }
    public bool IsPress_X()
    {
        return Input.GetKey("joystick button 2");
    }
    public bool IsRelease_X()
    {
        return Input.GetKeyUp("joystick button 2");
    }

    public bool IsClick_Y()
    {
        return Input.GetKeyDown("joystick button 3");
    }
    public bool IsPress_Y()
    {
        return Input.GetKey("joystick button 3");
    }
    public bool IsRelease_Y()
    {
        return Input.GetKeyUp("joystick button 3");
    }


    public bool IsClick_AnyKey()
    {
        return
            IsClick_Right() || IsClick_Left() || IsClick_Up() || IsClick_Down() ||
            IsClick_A() || IsClick_B() || IsClick_X() || IsClick_Y();
    }
    public bool IsPress_AnyKey()
    {
        return
            IsPress_Right() || IsPress_Left() || IsPress_Up() || IsPress_Down() ||
            IsPress_A() || IsPress_B() || IsPress_X() || IsPress_Y();
    }
    public bool IsRelease_AnyKey()
    {
        return
            IsRelease_Right() || IsRelease_Left() || IsRelease_Up() || IsRelease_Down() ||
            IsRelease_A() || IsRelease_B() || IsRelease_X() || IsRelease_Y();
    }

    public bool IsClick_AB()
    {
        return IsClick_A() || IsClick_B();
    }
    public bool IsPress_AB()
    {
        return IsPress_A() || IsPress_B();
    }
    public bool IsRelease_AB()
    {
        return IsRelease_A() || IsRelease_B();
    }

    public bool IsClick_XY()
    {
        return IsClick_X() || IsClick_Y();
    }
    public bool IsPress_XY()
    {
        return IsPress_X() || IsPress_Y();
    }
    public bool IsRelease_XY()
    {
        return IsRelease_X() || IsRelease_Y();
    }

    public bool IsClick_ABXY()
    {
        return IsClick_A() || IsClick_B() || IsClick_X() || IsClick_Y();
    }
    public bool IsPress_ABXY()
    {
        return IsPress_A() || IsPress_B() || IsPress_X() || IsPress_Y();
    }
    public bool IsRelease_ABXY()
    {
        return IsRelease_A() || IsRelease_B() || IsRelease_X() || IsRelease_Y();
    }
}
