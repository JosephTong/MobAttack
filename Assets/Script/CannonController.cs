using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    private float m_WaitTime = 0;
    [SerializeField] private float m_TimePerShot = 0.35f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(m_WaitTime>m_TimePerShot){
            Shoot();
            m_WaitTime = 0;
        }else{
            m_WaitTime += Time.fixedDeltaTime;
        }
    }

    private void Shoot(){
        // shoot
        Debug.Log("shoot");
    }
}
