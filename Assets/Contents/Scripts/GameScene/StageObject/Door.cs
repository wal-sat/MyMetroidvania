using UnityEditor.SearchService;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private SceneKind _sceneKind;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            S_LoadSceneManager.Instance.LoadScene(_sceneKind);
        }
    }
}
