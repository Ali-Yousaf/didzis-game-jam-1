using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathFromTiles : MonoBehaviour
{
    [SerializeField] private float sceneTransitionTime;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(LevelLoader.Instance != null)
                LevelLoader.Instance.RestartLevel();
        }
    }   
}
