using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCannon : CannonController
{
    [SerializeField] private float m_StartXPos = 1.7f;
    [SerializeField] private float m_MoveDistance = 1.75f;
    [SerializeField] private Transform m_Cannon;
    void Update()
    {
        
        if(!MainGameManager.GetInstance().IsGameStart()){
            return;
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            var tapPosToScreenRatio = Mathf.InverseLerp(0,Screen.width ,mousePos.x );
            
            m_Cannon.position = new Vector3(
                Mathf.Lerp(m_StartXPos-m_MoveDistance,m_StartXPos+m_MoveDistance ,tapPosToScreenRatio ),
                m_Cannon.position.y,
                m_Cannon.position.z);

            
        }
    }
}
