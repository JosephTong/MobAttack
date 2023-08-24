using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainGameManager : MonoBehaviour
{
    private static MainGameManager Instance = null;
    // increase by one everytime a new number panel spawn
    private int m_NumberPanelIndex = 0;
    private List<GameObject> m_AllLevel = new List<GameObject>();
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
            var newLevelBtn = Instantiate(m_LevelBtnPrefab, m_LevelGridParent);
            newLevelBtn.GetComponent<LevelBtn>().m_Text.text = i.ToSafeString();

        }
        OnClickBackFromLevelSelect();
        m_ExitBtn.onClick.AddListener(OnClickExitGame);
        m_StartGameBtn.onClick.AddListener(OnClickStartGame);
        m_ExitFromLevelSelectBtn.onClick.AddListener(OnClickBackFromLevelSelect);
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
