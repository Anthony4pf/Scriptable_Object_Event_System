using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyData : ScriptableObject
{
    public string m_name;
    public int m_maxHealth;
    public int m_currentHealth;

    private void OnEnable()
    {
        m_currentHealth = m_maxHealth;    
    }
}
