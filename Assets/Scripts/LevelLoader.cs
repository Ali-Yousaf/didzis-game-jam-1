using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader Instance;

    [Header("Transition")]
    [SerializeField] private Animator transition;
    [SerializeField] private TextMeshProUGUI transitionText;
    [SerializeField] private float transitionTime = 1f;

    [Header("Stars")]
    [SerializeField] private Image[] stars;
    [SerializeField] private Sprite starCollected;
    [SerializeField] private Sprite starNotCollected;

    private void Awake()
    {
        Instance = this;

        // Hide stars initially
        foreach (Image star in stars)
        {
            star.gameObject.SetActive(false);
        }
    }

    public void LoadNextLevel()
    {
        UpdateStars();
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void RestartLevel()
    {
        HideStars();
        StartCoroutine(Restart());
    }

    private void UpdateStars()
    {
        if(SceneManager.GetActiveScene().name == "Menu")
            return;

        int collected = StarsManager.Instance.collectedStars;

        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].gameObject.SetActive(true);

            stars[i].sprite = i < collected
                ? starCollected
                : starNotCollected;
        }
    }

    private void HideStars()
    {
        foreach (Image star in stars)
        {
            star.gameObject.SetActive(false);
        }
    }

    private IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        transitionText.text = "Level " + levelIndex;

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