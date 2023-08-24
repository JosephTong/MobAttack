using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerUnit : UnitController
{
    private List<int> m_CollidedId = new List<int>();
    private void Start()
    {
        SetHp(GetHp());
    }

    public void AddCollidedId(int id){
        m_CollidedId.Add(id);
    }

    void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.layer == 12)
        {
            // Number Panel
            if (collision.gameObject.TryGetComponent<NumberPanel>(out NumberPanel hitedPanel))
            {
                if (!m_CollidedId.Contains(hitedPanel.Id))
                {
                    m_CollidedId.Add(hitedPanel.Id);
                    // act according to operation
                    switch (hitedPanel.Operation)
                    {
                        case NumberPanelOperation.Add:
                            SetHp(GetHp() + hitedPanel.Number);
                            break;
                        case NumberPanelOperation.Minus:
                            SetHp(GetHp() - hitedPanel.Number);
                            break;
                        case NumberPanelOperation.multiply:
                            for (int i = 1; i < hitedPanel.Number; i++)
                            {
                                var newUnit = Instantiate(m_Unit, m_Unit.transform.parent);
                                newUnit.transform.position = m_Unit.transform.position + Vector3.forward * UnityEngine.Random.Range(-0.1f, 0.1f);
                                var newUnitScript = newUnit.GetComponent<PlayerUnit>();
                                foreach (var item in m_CollidedId)
                                {
                                    newUnitScript.AddCollidedId(item);  
                                }
                                newUnitScript.Init(m_Hp,m_Speed,m_Team,newUnit);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 11)
        {
            // EnemyUnit
            if (collision.gameObject.TryGetComponent<UnitController>(out UnitController hitedUnit))
            {
                float damage = Mathf.Min(GetHp(), hitedUnit.GetHp());
                SetHp(GetHp() - damage);
                hitedUnit.SetHp(hitedUnit.GetHp() - damage);
            }
        }
    }
}
