using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    [SerializeField] private Transform m_Unit;
    [SerializeField] private float m_Hp = 1;
    [SerializeField] private float m_Speed = 1;
    [SerializeField] private Rigidbody m_Rigidbody;

    // Update is called once per frame
    private void FixedUpdate() {

        m_Rigidbody.velocity = new Vector3(
            0,
            0,
            m_Speed
        );

        //m_Rigidbody.AddForce(m_Unit.forward *m_Speed*Time.deltaTime);

    }
}
