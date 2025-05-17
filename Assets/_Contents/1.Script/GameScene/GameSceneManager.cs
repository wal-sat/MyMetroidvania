using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField] PlayerManager playerManager;
    [SerializeField] ItemManager itemManager;

    private void Start()
    {
        S_InputSystem.instance.SwitchActionMap(ActionMapKind.Player);
        
        Initialize();
    }

    private void Initialize()
    {
        playerManager.Initialize();
        itemManager.Initialize();
    }
}
