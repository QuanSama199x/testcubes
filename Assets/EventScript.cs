using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventScript : DataManager
{
    private static EventScript instance;
    public static EventScript Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<EventScript>();
            return instance;
        }
    }
    public UnityEvent Up;
    public UnityEvent Down;
    public UnityEvent Left;
    public UnityEvent Right;
}
