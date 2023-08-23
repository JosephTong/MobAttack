using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : UnitController
{
    private void Start() {
        SetHp(GetHp());
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 11)
        {// EnemyUnit
            if (collision.gameObject.TryGetComponent<UnitController>(out UnitController hitedUnit))
            {
                float damage = Mathf.Min( GetHp(), hitedUnit.GetHp() );
                SetHp( GetHp() - damage );
                hitedUnit.SetHp( hitedUnit.GetHp() - damage);
            }
        }
    }
}
