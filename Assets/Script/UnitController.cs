using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitTeam
{
    Player = 0,
    Enemy
}

[System.Serializable]
public class UnitController : MonoBehaviour
{
    [SerializeField] protected GameObject m_Unit;
    [SerializeField] protected float m_Hp = 1;
    [SerializeField] protected float m_Speed = 1;
    [SerializeField] protected Rigidbody m_Rigidbody;
    [SerializeField] protected UnitTeam m_Team;
    [SerializeField] protected bool m_IsBase = false;
    
    

    public void Init(float hp, float speed, UnitTeam team,GameObject gameObject){
        m_Hp = hp;
        m_Speed = speed; 
        m_Team = team;
        m_Unit = gameObject;
        //m_Unit.transform.localScale = Vector3.one * (Mathf.Max(1,m_Hp));
    }

    // Update is called once per frame
    private void FixedUpdate() {

        if(m_Hp<=0|| m_IsBase || !MainGameManager.GetInstance().IsGameStart())
            return;

        m_Rigidbody.velocity = new Vector3(
            0,
            0,
            m_Speed
        );

        //m_Rigidbody.AddForce(m_Unit.forward *m_Speed*Time.deltaTime);

    }

    public void SetHp(float hp){
        if(m_Hp<=0){
            return;
        }

        m_Hp = hp;

        if(!m_IsBase)
            m_Unit.transform.localScale = Vector3.one * ( Mathf.Min( Mathf.Max(1, 1 + m_Hp*0.1f) ,3));

        if(hp<=0){
            Destroy(m_Unit,0.5f);
        }
    }

    public float GetHp(){
        return m_Hp;
    }

    public virtual void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.layer == 13)
        {
            // Killer
            SetHp(0);
        }
    }
}
