using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathFromTiles : MonoBehaviour
{
    [SerializeField] private float sceneTransitionTime;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            print("Death");
            
            if(LevelLoader.Instance != null)
                LevelLoader.Instance.RestartLevel();
        }
    }
}
