using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GamerEvent : ScriptableObject
{
    private List<GamerEventListener> m_listeners = new List<GamerEventListener>();

    public void Raise()
    {
        for (int i = m_listeners.Count - 1; i >= 0; i--)
            m_listeners[i].OnEventRaised();
    }
    public void RegisterListener(GamerEventListener listener)
    {
        m_listeners.Add(listener);
    }
    public void UnregisterListener(GamerEventListener listener)
    {
        m_listeners.Remove(listener);
    }
}
