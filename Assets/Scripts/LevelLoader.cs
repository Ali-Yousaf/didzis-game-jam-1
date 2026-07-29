using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader Instance;
    [SerializeField] private Animator transition;

    [SerializeField] private TextMeshProUGUI transitionText;
    [SerializeField] private float transitionTime = 1f;

    void Awake()
    {
        Instance = this;
    }
    
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void RestartLevel()
    {
        StartCoroutine(Restart());
    }

    private IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        transitionText.text = "Level " + (levelIndex + 1);

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    private IEnumerator Restart()
    {
        transition.SetTrigger("Start");
        transitionText.text = "Restarting...";

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
