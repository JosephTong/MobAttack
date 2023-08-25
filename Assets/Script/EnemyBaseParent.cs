using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyBaseParent : MonoBehaviour
{
    public UnitController Unit;
    public CannonController Cannon;
    [SerializeField] private TMP_Text m_HpText;
    public int Index = 0;

    private void Start() {
        Unit.AddAction((delay)=>{
            MainGameManager.GetInstance().RemoveEnemyBase(Index);
            Destroy(this.gameObject,delay);
        },SetHpText);
    }
    private void SetHpText(float hp){
        m_HpText.text = hp.ToString("0.#");
    }

}
