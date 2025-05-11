using UnityEngine;

public enum PlayerState{ normal, attack }

public class PlayerManager : MonoBehaviour
{
    [SerializeField] PlayerMovement _playerMovement;
    [SerializeField] PlayerJump _playerJump;
    [SerializeField] PlayerAttack _playerAttack;
    [SerializeField] PlayerView _playerView;

    private PlayerState _playerState;

    private void Awake()
    {
        _playerAttack.changePlayerState += ChangePlayerState;
    }
    private void FixedUpdate()
    {
        _playerMovement.MovementUpdate();
        _playerJump.JumpUpdate();
        _playerAttack.AttackUpdate(_playerMovement.isFacingRight);
        _playerView.ViewUpdate(_playerMovement.isFacingRight);
    }

    private void ChangePlayerState(PlayerState playerState)
    {
        _playerState = playerState;

        switch (_playerState)
        {
            case PlayerState.normal:
                _playerView.ChangeAttackSprite(false);
                break;
            case PlayerState.attack:
                _playerView.ChangeAttackSprite(true);
                break;
        }
    }
}
