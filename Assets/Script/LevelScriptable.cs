using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Scriptable/Level", order = 1)]
public class LevelScriptable : ScriptableObject
{

    public GameObject AllObstacle;
    public List<NumberPanelData> NumberPanels = new List<NumberPanelData>();
    public List<EnemyBaseData> EnemyBases = new List<EnemyBaseData>();

}

[Serializable]
public class NumberPanelData {
    public Vector3 Pos;
    public Vector3 Scale;
    public NumberPanelOperation Operation;
    public float Number = 0;
}

[Serializable]
public class EnemyBaseData {
    public Vector3 MainPos;
    public float Hp = 1;
    public float TimePerShot = 0.35f;
    public int SpawnCountPerShot = 1;
}
