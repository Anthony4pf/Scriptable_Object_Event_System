using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContoller : MonoBehaviour
{
    [SerializeField]private GameObject m_enemyPanel;
    [SerializeField]private float m_speed = 6.0f;
    [SerializeField]private float minY = 0f;
    [SerializeField]private float maxY = 100f;

    private bool moveUp = false;

    private void Update()
    {
        float targetY = moveUp ? maxY : minY;
        Vector3 targetPos = new Vector3(m_enemyPanel.transform.localPosition.x, targetY, m_enemyPanel.transform.localPosition.z);
        
        if(Vector3.Distance(m_enemyPanel.transform.localPosition, targetPos) < 0.1f)
        {
            moveUp = !moveUp;
        }
        else
        {
            m_enemyPanel.transform.localPosition = Vector3.Lerp(m_enemyPanel.transform.localPosition, targetPos, m_speed * Time.deltaTime);
        }
    }
}