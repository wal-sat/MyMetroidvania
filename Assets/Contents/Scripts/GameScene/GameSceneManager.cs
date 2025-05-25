using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField] PlayerManager playerManager;
    [SerializeField] ItemManager itemManager;

    private void Start()
    {
        S_InputSystemManager.Instance.SwitchActionMap(ActionMapKind.Player);
        S_BGMManager.Instance.Play("game", 2f);
        
        Initialize();
    }

    private void Initialize()
    {
        playerManager.Initialize();
        itemManager.Initialize();
    }
}
