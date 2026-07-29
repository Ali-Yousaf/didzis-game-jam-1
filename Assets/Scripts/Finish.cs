using UnityEngine;

public class Finish : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {   
            if(LevelLoader.Instance != null)
                LevelLoader.Instance.LoadNextLevel();            
        }
    }
}
