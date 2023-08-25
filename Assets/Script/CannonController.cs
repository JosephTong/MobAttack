using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CannonController : MonoBehaviour
{
    [SerializeField] protected float m_TimePerShot = 0.35f;
    [SerializeField] protected GameObject m_UnitPrefab;
    [SerializeField] protected Transform m_SpawnPoint;
    [SerializeField] protected Transform m_UnitParent;
    [SerializeField] protected bool m_IsEnemy = false;
    [SerializeField] protected int m_SpawnCountPerShot = 1;
    private float m_WaitTime = 0;
    // Start is called before the first frame update

    public void Init(float timePerShot, int spawnPerShot){
        m_TimePerShot = timePerShot;
        m_SpawnCountPerShot = spawnPerShot;
        if(m_IsEnemy){
            m_UnitParent = MainGameManager.GetInstance().GetEnemyUnitParent();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!MainGameManager.GetInstance().IsGameStart()){
            return;
        }


        if (m_WaitTime > m_TimePerShot)
        {
            StartCoroutine(Shoot());
            m_WaitTime = 0;
        }
        else
        {
            m_WaitTime += Time.fixedDeltaTime;
        }
    }

    private IEnumerator Shoot()
    {
        // shoot
        for (int i = 0; i < m_SpawnCountPerShot; i++)
        {
            var newUnit = Instantiate(m_UnitPrefab,m_UnitParent);
            newUnit.transform.position = m_SpawnPoint.position + Vector3.left * UnityEngine.Random.Range(-0.1f,0.1f) ; 
            yield return null;
        }
    }
}
