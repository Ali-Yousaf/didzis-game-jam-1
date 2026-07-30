using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    void Awake()
    {
        if(Instance == null)
            Instance = this;

        else
            Destroy(gameObject);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            LevelLoader.Instance.RestartLevel();
        }
    }
}
