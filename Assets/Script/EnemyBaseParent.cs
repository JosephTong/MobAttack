using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseParent : MonoBehaviour
{
    public UnitController Unit;
    public CannonController Cannon;

    private void Start() {
        Unit.AddOnDestoryAction((delay)=>{
            Destroy(this.gameObject,delay);
        });
    }
}
