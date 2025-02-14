using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class InputScript : MonoBehaviour
{
    private static InputScript instance;
    public static InputScript Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<InputScript>();
            return instance;
        }
    }
    public bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private bool isDraging = false;
    public Vector2 startTouch, swipeDelta;
    public AudioManager audioManager;
    public static Action<string> Move;
    public void swipe()
    {
        tap = swipeDown = swipeUp = swipeLeft = swipeRight = false;
    }
    private void Update()
    {

        InputController();
    }
    public void InputController()
    {
        swipe();

        if (Time.timeScale == 1)
        {
            #region Standalone Inputs
            if (Input.GetMouseButtonDown(0))
            {
                tap = true;
                isDraging = true;
                startTouch = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                isDraging = false;
                Reset();
            }
            #endregion

            #region Mobile Input
            if (Input.touches.Length > 0)
            {
                if (Input.touches[0].phase == TouchPhase.Began)
                {
                    tap = true;
                    isDraging = true;
                    startTouch = Input.touches[0].position; 
                }
                else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
                {
                    isDraging = false;
                    Reset();
                }
            }
            #endregion

            swipeDelta = Vector2.zero;
            if (isDraging)
            {
                if (Input.touches.Length < 0)
                    swipeDelta = Input.touches[0].position - startTouch;
                else if (Input.GetMouseButton(0))
                    swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }

            if (swipeDelta.magnitude > 100)
            {
                Swipe();
            }
        }
    }
    public void Swipe()
    {
        GameController.Instance._CountWin = 0;
        float x = swipeDelta.x;
        float y = swipeDelta.y;
        if (Mathf.Abs(x) > Mathf.Abs(y))
        {
            if (x < 0)
            {
                swipeLeft = true;
                Move.Invoke("Left");
            }
            else
            {
                Move.Invoke("Right");
                swipeRight = true;
            }
        }
        else
        {
            if (y < 0)
            {
                Move.Invoke("Down");
                swipeDown = true;
            }
            if (y > 0)
            {
                Move.Invoke("Up");
                swipeUp = true;
            }
        }
        SoundController.Instance.Sound.GetPooledObject().SetClip(0);
        Reset();
    }

    public void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }
}

