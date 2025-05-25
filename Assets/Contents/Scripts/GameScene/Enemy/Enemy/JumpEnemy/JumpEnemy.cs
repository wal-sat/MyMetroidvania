using UnityEngine;

public class JumpEnemy : EnemyBase
{
    private enum WalkState { Walk, Jump }

    [SerializeField] private EnemyView _enemyView;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _stageChangeTime;
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
        _walkState = WalkState.Walk;
    }

    private void FixedUpdate()
    {
        switch (_walkState)
        {
            case WalkState.Walk:
                _timer += Time.deltaTime;
                transform.position += new Vector3( _isFacingRight * _moveSpeed, 0f, 0f) * Time.fixedDeltaTime;
                if (_timer >= _stageChangeTime)
                {
                    _isJumping = true;
                    _walkState = WalkState.Jump;
                    _timer = 0f;
                    _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                }
                break;
            case WalkState.Jump:
                _timer += Time.deltaTime;
                if (_timer >= _stageChangeTime)
                {
                    _walkState = WalkState.Walk;
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
        _walkState = WalkState.Jump;
        _timer = 0f;
        _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
}
