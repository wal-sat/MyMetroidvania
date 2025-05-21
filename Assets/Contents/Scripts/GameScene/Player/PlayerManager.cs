using UnityEngine;

public enum PlayerState{ normal, attack }

public class PlayerManager : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerJump playerJump;
    [SerializeField] PlayerAttack playerAttack;
    [SerializeField] PlayerDamaged playerDamaged;
    [SerializeField] PlayerView playerView;

    private PlayerState _playerState;

    private void Awake()
    {
        playerAttack.changePlayerState += ChangePlayerState;
    }
    private void FixedUpdate()
    {
        playerMovement.MovementUpdate();
        playerJump.JumpUpdate();
        playerAttack.AttackUpdate(playerMovement.isFacingRight);
        playerDamaged.DamageUpdate();
        playerView.ViewUpdate(playerMovement.isFacingRight);
    }

    private void ChangePlayerState(PlayerState playerState)
    {
        _playerState = playerState;

        switch (_playerState)
        {
            case PlayerState.normal:
                playerView.ChangeAttackSprite(false);
                break;
            case PlayerState.attack:
                playerView.ChangeAttackSprite(true);
                break;
        }
    }

    public void Initialize()
    {
        S_PlayerInformation.instance.Initialize();
        _playerState = PlayerState.normal; 
    }
}
