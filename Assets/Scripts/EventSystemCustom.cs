using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class MyIntEvent : UnityEvent<int> {}
[System.Serializable]
public class MyTextEvent : UnityEvent<string> {}


public class EventSystemCustom : MonoBehaviour
{
    public static EventSystemCustom current;
    public MyTextEvent onEndGame;
    void Awake()
    {
        current = this;
        onEndGame = new MyTextEvent();
    }
}