using UnityEngine;

public class JumpEnemy : EnemyBase
{
    enum WalkState { walk, jump }

    [SerializeField] private EnemyView _enemyView;
    [SerializeField] private float MOVE_SPEED;
    [SerializeField] private float JUMP_FORCE;
    [SerializeField] private float STATE_CHANGE_TIME;
    private Rigidbody2D _rigidbody2D;
    private WalkState _walkState;

    private int _isFacingRight = 1;
    private float _timer;
    private bool _isJumping;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();   
    }
    public override void Start()
    {
        base.Start();
        _walkState = WalkState.walk;
    }

    private void FixedUpdate()
    {
        switch (_walkState)
        {
            case WalkState.walk:
                _timer += Time.deltaTime;
                transform.position += new Vector3( _isFacingRight * MOVE_SPEED, 0f, 0f) * Time.fixedDeltaTime;
                if (_timer >= STATE_CHANGE_TIME)
                {
                    _isJumping = true;
                    _walkState = WalkState.jump;
                    _timer = 0f;
                    _rigidbody2D.AddForce(Vector2.up * JUMP_FORCE, ForceMode2D.Impulse);
                }
                break;
            case WalkState.jump:
                _timer += Time.deltaTime;
                if (_timer >= STATE_CHANGE_TIME)
                {
                    _walkState = WalkState.walk;
                    _timer = 0f;
                    _isFacingRight = -_isFacingRight;
                    _enemyView.ChangeScaleX(_isFacingRight);

                    _isJumping = false;
                }
                break;
        }
    }

    public override void Attacked(int damage)
    {
        base.Attacked(damage);

        if (_isJumping) return;
        _isJumping = true;
        _walkState = WalkState.jump;
        _timer = 0f;
        _rigidbody2D.AddForce(Vector2.up * JUMP_FORCE, ForceMode2D.Impulse);
    }
}
