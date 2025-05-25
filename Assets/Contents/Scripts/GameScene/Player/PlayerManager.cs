using UnityEngine;

public enum PlayerState{ Normal, Attack }

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerJump _playerJump;
    [SerializeField] private PlayerAttack _playerAttack;
    [SerializeField] private PlayerDamaged _playerDamaged;
    [SerializeField] private PlayerView _playerView;

    private PlayerState _playerState;

    private void Awake()
    {
        _playerAttack.changePlayerState += ChangePlayerState;
    }
    private void FixedUpdate()
    {
        _playerMovement.MovementUpdate();
        _playerJump.JumpUpdate();
        _playerAttack.AttackUpdate(_playerMovement.IsFacingRight);
        _playerDamaged.DamageUpdate();
        _playerView.ViewUpdate(_playerMovement.IsFacingRight);
    }

    private void ChangePlayerState(PlayerState playerState)
    {
        _playerState = playerState;

        switch (_playerState)
        {
            case PlayerState.Normal:
                _playerView.ChangeAttackSprite(false);
                break;
            case PlayerState.Attack:
                _playerView.ChangeAttackSprite(true);
                break;
        }
    }

    public void Initialize()
    {
        S_PlayerInformation.Instance.Initialize();
        _playerState = PlayerState.Normal; 
    }
}
