using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject gameRulesPanel;

    void Start()
    {
        gameRulesPanel.SetActive(false);
    }

    public void StartGame()
    {
        LevelLoader.Instance.LoadNextLevel();
    }

    public void OpenRulesPanel()
    {
        gameRulesPanel.SetActive(true);
    }

    public void CloseRulesPanel()
    {
        gameRulesPanel.SetActive(false);
    }
}
