using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class SwipeDetectionTestNew : MonoBehaviour
{
    public List<SwipeEvent> EventList = new List<SwipeEvent>();

    public enum Direction
    {
        Left = 0,
        Right = 1,
        Up = 2,
        Down = 3
    };

    [Serializable]
    public class SwipeEvent
    {
        public UnityEvent Event = new UnityEvent();
        public Direction direction = new Direction();
    }

    //Position of where the player is touching
    private Ray ray;
    private RaycastHit hit;

    //Position of where the player is swiping to
    private Vector2 startPos, endPos, pos;
    private bool clicked;

    private GameObject gameObjectHit;

    private void Update()
    {
        //WHEN CLICK
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Puzzle")
                {
                    startPos = Input.GetTouch(0).position;
                    clicked = true;
                    GameEventManager.isTouchObject = true;
                }
            }
        }
        Direction direction;
        //WHEN LIFT FINGER
        if (clicked == true && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended && Physics.Raycast(ray, out hit))
        {
            endPos = Input.touches[0].position;
            pos = startPos - endPos;

            if (Mathf.Abs(pos.x) > Mathf.Abs(pos.y)) //For Left and Right detection
            {
                if (pos.x > 0)
                {
                    direction = Direction.Left;
                    DoEvent(direction);
                }
                    
                else if (pos.x < 0)
                {
                    direction = Direction.Right;
                    DoEvent(direction);
                }
            }
            else if (Mathf.Abs(pos.x) < Mathf.Abs(pos.y)) //For Up and Down
            {
                if (pos.y < 0)
                { 
                    direction = Direction.Up;
                    DoEvent(direction);
                }
                    
                else if (pos.y > 0)
                {
                    direction = Direction.Down;
                    DoEvent(direction);
                }
            }
            clicked = false;
            GameEventManager.isTouchObject = false;
        }
    }

    private void DoEvent(Direction way)
    {
        foreach(SwipeEvent dir in EventList)
        {
            if (dir.direction == way)
                dir.Event.Invoke();
        }
    }

    public void ColourChange()
    {
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                Color newColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);
                hit.collider.GetComponent<MeshRenderer>().material.color = newColor;
            }
        }
    }

}
