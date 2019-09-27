using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UserInput : MonoBehaviour
{
    private List<TouchInfo> touches = new List<TouchInfo>(); //make list to store touchIDs and what kind of touch they are (UI, target, move)
    private Vector2 directionalInput;

    public float deadZone;

    private void Update()
    {
        directionalInput = Vector2.zero;                                                            //set output to zero

        for (int i = 0; i < Input.touchCount; i++)                                                  //loop through all touches
        {
            Touch t = Input.GetTouch(i);                                                            //get each touch
            if (t.phase == TouchPhase.Began)                                                        //and if it just began
            {
                //TODO: figure out what type of touch it is                                         //see what type of touch it is
                //if it's a touch that's not on a UI object, add it
                //if it's not on a UI object but is on an enemy, add it as a target
                touches.Add(new TouchInfo(t.fingerId, true, t.position));                           //and then add it to the list
            }
            else if (t.phase == TouchPhase.Ended || t.phase == TouchPhase.Canceled)                 //when one of the touches is done
            {
                TouchInfo thisTouch = touches.Find(TouchInfo => TouchInfo.touchID == t.fingerId);   //find the list index of its touch ID
                touches.RemoveAt(touches.IndexOf(thisTouch));                                       //and delete it from the list
            }

            if (touches.Find(TouchInfo => TouchInfo.touchID == t.fingerId) != null)                 //if the current touch is active and a swipe or target
            {
                TouchInfo thisTouch = touches.Find(TouchInfo => TouchInfo.touchID == t.fingerId);   //get the touch
                Vector2 deltaPos = t.position - thisTouch.startTouch;                               //and find its delta position
                if (thisTouch.targetTouch && deltaPos.magnitude > deadZone)                         //if it was a target touch but turns out
                {                                                                                   //to be a movement touch
                    RecallLastTarget();                                                             //undo what it did to target
                    thisTouch.targetTouch = false;                                                  //and turn it into a movement touch
                }
                if (deltaPos.magnitude > deadZone)                                                  //if the swipe is past the deadzone
                {
                    SetDirectionalInput(deltaPos);                                                  //make the total output the deltaPos
                }
            }
        }
    }

    private void RecallLastTarget()
    {

    }

    private void SetNewTarget()
    {

    }

    private void SetDirectionalInput(Vector2 newInput)
    {
        directionalInput = newInput;
    }

    public Vector2 GetDirectionalInput()
    {
        return directionalInput;
    }
}