using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInfo
{
    public int touchID;
    public bool targetTouch;
    public Vector2 startTouch;

    public TouchInfo(int setTouchID, bool usedForTargetting, Vector2 setStartPoint)
    {
        touchID = setTouchID;
        targetTouch = usedForTargetting;
        startTouch = setStartPoint;
    }
}
