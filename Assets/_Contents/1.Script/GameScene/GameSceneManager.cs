using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField] PlayerManager playerManager;
    [SerializeField] ItemManager itemManager;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        playerManager.Initialize();
        itemManager.Initialize();
    }
}
