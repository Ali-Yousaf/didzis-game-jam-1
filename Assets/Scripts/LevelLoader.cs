using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader Instance;
    [SerializeField] private Animator transition;
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

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    private IEnumerator Restart()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
