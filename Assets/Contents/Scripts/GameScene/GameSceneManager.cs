using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField] private PlayerManager _playerManager;
    [SerializeField] private ItemManager _itemManager;

    private void Start()
    {
        S_InputSystemManager.Instance.SwitchActionMap(ActionMapKind.Player);
        S_BGMManager.Instance.Play("game", 2f);
        
        Initialize();
    }

    private void Initialize()
    {
        _playerManager.Initialize();
        _itemManager.Initialize();
    }
}
