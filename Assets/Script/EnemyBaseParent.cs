using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseParent : MonoBehaviour
{
    public UnitController Unit;
    public CannonController Cannon;
    public int Index = 0;

    private void Start() {
        Unit.AddOnDestoryAction((delay)=>{
            MainGameManager.GetInstance().RemoveEnemyBase(Index);
            Destroy(this.gameObject,delay);
        });
    }
}
