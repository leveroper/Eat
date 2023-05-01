using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    [SerializeField] private EventSettings[] events; //евент лист свойств предметов
    public EventSettings[] Events => events;
    public static EventManager instance = null;

    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void InvokeEvent(int index) 
    {
        events[index].Event.Invoke();
    }
}

[System.Serializable]
public struct EventSettings //найстройки евента предмета
{
    public PropertyName Name;
    public int EventID; 
    public UnityEvent Event;
}


