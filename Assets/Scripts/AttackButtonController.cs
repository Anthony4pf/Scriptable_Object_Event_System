using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AttackButtonController : MonoBehaviour
{
    [SerializeField] private WeaponData[] m_weapons;
    private int m_currentWeaponIndex = 0;
    [SerializeField] private EnemyData m_enemyData;
    [SerializeField] private GamerEvent OnEnemyKilled;
    [SerializeField] private Slider m_enemyHealthBar;
    [SerializeField] private TextMeshProUGUI m_selectedWeaponText; 

    private void Start()
    {
        m_enemyHealthBar.maxValue = m_enemyData.m_maxHealth;
        m_enemyHealthBar.value = m_enemyHealthBar.maxValue;    
    }
    private void Update()
    {
        m_selectedWeaponText.text = m_weapons[m_currentWeaponIndex].m_name.ToString();
        m_enemyHealthBar.value = m_enemyData.m_currentHealth;    
    } 

    public void AttackEnemy()
    {
        int damagePoints = m_weapons[m_currentWeaponIndex].m_damagePoints;
        m_enemyData.m_currentHealth -= damagePoints;

        if (m_enemyData.m_currentHealth <= 0)
        {
            OnEnemyKilled.Raise();
        }
    }

    public void SelectWeapon(int weaponIndex)
    {
        m_currentWeaponIndex = weaponIndex;
    }
}