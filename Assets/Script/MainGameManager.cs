using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainGameManager : MonoBehaviour
{
    private static MainGameManager Instance = null;

    // In Game
    [SerializeField] private List<LevelScriptable> m_AllLevel = new List<LevelScriptable>();
    [SerializeField] private Transform m_ObstacleParent;
    [SerializeField] private Transform m_EnemyUnitParent;
    [SerializeField] private Transform m_PlayerUnitParent;
    [SerializeField] private Transform m_EnemyBaseParent;
    [SerializeField] private GameObject m_EnemyBasePrefab;
    [SerializeField] private Transform m_NumberPanelParent;
    [SerializeField] private GameObject m_NumberPanelPrefab;
    [SerializeField] private List<Vector3> m_AllEnemyBasePos = new List<Vector3>();

    
    // UI
    [SerializeField] private GameObject m_LevelBtnPrefab;
    [SerializeField] private Transform m_LevelGridParent;
    [SerializeField] private GameObject m_LevelSelect;
    [SerializeField] private GameObject m_MainMenu;
    [SerializeField] private GameObject m_LosePanel;
    [SerializeField] private GameObject m_WinPanel;
    [SerializeField] private Button m_ExitBtn;
    [SerializeField] private Button m_StartGameBtn;
    [SerializeField] private Button m_ExitFromLevelSelectBtn;

    private bool m_IsStart = false;

    public static MainGameManager GetInstance()
    {
        return Instance;
    }


    void Awake()
    {
        if (MainGameManager.GetInstance() != null && MainGameManager.GetInstance() != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start() {
        // spawn level
        for (int i = 0; i < m_AllLevel.Count; i++)
        {
            int index = i;
            var newLevelBtn = Instantiate(m_LevelBtnPrefab, m_LevelGridParent);
            newLevelBtn.GetComponent<LevelBtn>().m_Text.text = (index+1).ToSafeString();
            newLevelBtn.GetComponent<Button>().onClick.AddListener(()=>SpawnLevel(index));


        }
        OnClickBackFromLevelSelect();
        m_ExitBtn.onClick.AddListener(OnClickExitGame);
        m_StartGameBtn.onClick.AddListener(OnClickStartGame);
        m_ExitFromLevelSelectBtn.onClick.AddListener(OnClickBackFromLevelSelect);
    }

    private void SpawnLevel(int index){
        var targetLevel = m_AllLevel[index];

        // desotry all obstacle
        for (int i = 0; i < m_ObstacleParent.childCount; i++)
        {
            Destroy(m_ObstacleParent.GetChild(i).gameObject);
        }

        // spawn obstacle 
        Instantiate(targetLevel.AllObstacle, m_ObstacleParent);

        // desotry all number panel
        for (int i = 0; i < m_NumberPanelParent.childCount; i++)
        {
            Destroy(m_NumberPanelParent.GetChild(i).gameObject);
        }

        // spawn all number panel
        for (int i = 0; i < targetLevel.NumberPanels.Count; i++)
        {
            var numberPanelId = i;
            var targetData = targetLevel.NumberPanels[numberPanelId];
            GameObject newNumberPanel = Instantiate(m_NumberPanelPrefab, m_ObstacleParent);
            var numberPanelScript = newNumberPanel.GetComponent<NumberPanelParent>().NumberPanel;

            numberPanelScript.Id = numberPanelId;
            numberPanelScript.Number = targetData.Number;
            numberPanelScript.Operation = targetData.Operation;
            newNumberPanel.transform.position = targetData.Pos;
            newNumberPanel.transform.localScale = targetData.Scale;
        }

        // destory all enemy unit
        for (int i = 0; i < m_EnemyUnitParent.childCount; i++)
        {
            Destroy(m_EnemyUnitParent.GetChild(i).gameObject);
        }

        // destory all player unit
        for (int i = 0; i < m_PlayerUnitParent.childCount; i++)
        {
            Destroy(m_PlayerUnitParent.GetChild(i).gameObject);
        }

        // destory all base 
        for (int i = 0; i < m_EnemyBaseParent.childCount; i++)
        {
            Destroy(m_EnemyBaseParent.GetChild(i).gameObject);
        }
        m_AllEnemyBasePos.Clear();

        // spawn all enemy base
        for (int i = 0; i < targetLevel.EnemyBases.Count; i++)
        {
            var targetData = targetLevel.EnemyBases[i];
            GameObject newEnemyBase = Instantiate(m_EnemyBasePrefab, m_EnemyBaseParent);
            newEnemyBase.transform.position = targetData.MainPos;
            var cannon = newEnemyBase.GetComponent<EnemyBaseParent>().Cannon;
            cannon.Init(targetData.TimePerShot,targetData.SpawnCountPerShot);
            var unit = newEnemyBase.GetComponent<EnemyBaseParent>().Unit;
            unit.Init(targetData.Hp,0,UnitTeam.Enemy,unit.gameObject);
            m_AllEnemyBasePos.Add(targetData.MainPos);
        }


        // turn off ui
        TurnOffAllPanel();

        m_IsStart = true;
    }

    
    private void TurnOffAllPanel(){
        m_MainMenu.SetActive(false);
        m_LevelSelect.SetActive(false);
        m_LosePanel.SetActive(false);
        m_WinPanel.SetActive(false);
    }

    
    private void OnClickBackFromLevelSelect()
    {
        TurnOffAllPanel();
        m_MainMenu.SetActive(true);
    }

    private void OnClickStartGame()
    {
        TurnOffAllPanel();
        m_IsStart = false;
        m_LevelSelect.SetActive(true);
    }

    public bool IsGameStart(){
        return m_IsStart;
    }

    private void OnClickExitGame()
    {
        Application.Quit();
    }


}
