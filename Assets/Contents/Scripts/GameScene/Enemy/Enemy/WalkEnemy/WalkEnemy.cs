using UnityEngine;

public class WalkEnemy : EnemyBase
{
    enum WalkState { Idle, Walk, Chase }

    [SerializeField] private Transform _player;
    [SerializeField] private EnemyView _enemyView;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _chaseSpeed;
    [SerializeField] private float _stateChangeTime;
    [SerializeField] private float _chaseDistance;
    private WalkState _walkState;

    private int _isFacingRight = 1;
    private float _timer;

    public override void Start()
    {
        base.Start();
        _walkState = WalkState.Walk;
    }

    private void FixedUpdate()
    {
        if (_player == null) _walkState = WalkState.Idle;

        Move();
        ChangeStage();
    }
    private void Move()
    {
        switch (_walkState)
        {
            case WalkState.Idle:
                break;
            case WalkState.Walk:
                transform.position += new Vector3( _isFacingRight * _moveSpeed, 0f, 0f) * Time.fixedDeltaTime;
                break;
            case WalkState.Chase:
                if (_isFacingRight == 1 && _player.position.x < transform.position.x) _isFacingRight = -1;
                else if (_isFacingRight == -1 && _player.position.x > transform.position.x) _isFacingRight = 1;
                _enemyView.ChangeScaleX(_isFacingRight);

                transform.position += new Vector3(_isFacingRight * _chaseSpeed, 0f, 0f) * Time.fixedDeltaTime;
                break;
        }
    }
    private void ChangeStage()
    {
        switch (_walkState)
        {
            case WalkState.Idle:
                _timer += Time.deltaTime;
                if (_timer >= _stateChangeTime)
                {
                    _walkState = WalkState.Walk;
                    _timer = 0f;
                    _isFacingRight = -_isFacingRight;
                    _enemyView.ChangeScaleX(_isFacingRight);
                }
                break;
            case WalkState.Walk:
                _timer += Time.deltaTime;
                if (_timer >= _stateChangeTime)
                {
                    _walkState = WalkState.Idle;
                    _timer = 0f;
                }
                break;
            case WalkState.Chase:
                if (Vector2.SqrMagnitude(transform.position - _player.position) > _chaseDistance * _chaseDistance)
                {
                    _walkState = WalkState.Idle;
                    _timer = 0f;
                }
                break;
        }
    }

    public override void Attacked(int damage)
    {
        base.Attacked(damage);
        _walkState = WalkState.Chase;
    }
}
