using UnityEditor.SearchService;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] SceneKind sceneKind;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            S_LoadSceneManager.Instance.LoadScene(sceneKind);
        }
    }
}
