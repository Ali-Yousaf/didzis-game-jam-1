using UnityEngine;

public class StarsManager : MonoBehaviour
{
    public static StarsManager Instance;

    public int collectedStars;
    public int totalStars = 3;

    private void Awake()
    {
        Instance = this;
    }

    public void CollectStar()
    {
        collectedStars++;

        Debug.Log($"{collectedStars}/{totalStars}");
    }
}