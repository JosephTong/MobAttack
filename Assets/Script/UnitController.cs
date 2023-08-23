using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitTeam
{
    Player = 0,
    Enemy
}

public class UnitController : MonoBehaviour
{
    private GameObject m_Unit;
    private float m_Hp = 1;
    private float m_Speed = 1;
    private Rigidbody m_Rigidbody;
    private UnitTeam m_Team;
    
    

    public void Init(float hp, float speed, UnitTeam team,GameObject gameObject){
        m_Hp = hp;
        m_Speed = speed; 
        m_Team = team;
        m_Unit = gameObject;
        m_Unit.transform.localScale = Vector3.one * (Mathf.Max(1,m_Hp));
    }

    // Update is called once per frame
    private void FixedUpdate() {

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

        m_Unit.transform.localScale = Vector3.one * (Mathf.Max(1,m_Hp));

        if(hp<=0){
            Destroy(m_Unit,1);
        }
    }

    public float GetHp(){
        return m_Hp;
    }


}
