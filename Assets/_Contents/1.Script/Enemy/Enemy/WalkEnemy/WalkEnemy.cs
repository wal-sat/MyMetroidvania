using UnityEngine;

public class WalkEnemy : EnemyBase
{
    enum WalkState { idle, walk, chase }

    [SerializeField] private Transform _player;
    [SerializeField] private EnemyView _enemyView;
    [SerializeField] private float MOVE_SPEED;
    [SerializeField] private float CHASE_SPEED;
    [SerializeField] private float STATE_CHANGE_TIME;
    [SerializeField] private float CHASE_DISTANCE;
    private WalkState _walkState;

    private int _isFacingRight = 1;
    private float _timer;

    public override void Start()
    {
        base.Start();
        _walkState = WalkState.walk;
    }

    private void FixedUpdate()
    {
        if (_player == null) _walkState = WalkState.idle;

        Move();
        ChangeStage();
    }
    private void Move()
    {
        switch (_walkState)
        {
            case WalkState.idle:
                break;
            case WalkState.walk:
                transform.position += new Vector3( _isFacingRight * MOVE_SPEED, 0f, 0f) * Time.fixedDeltaTime;
                break;
            case WalkState.chase:
                if (_isFacingRight == 1 && _player.position.x < transform.position.x) _isFacingRight = -1;
                else if (_isFacingRight == -1 && _player.position.x > transform.position.x) _isFacingRight = 1;
                _enemyView.ChangeScaleX(_isFacingRight);

                transform.position += new Vector3(_isFacingRight * CHASE_SPEED, 0f, 0f) * Time.fixedDeltaTime;
                break;
        }
    }
    private void ChangeStage()
    {
        switch (_walkState)
        {
            case WalkState.idle:
                _timer += Time.deltaTime;
                if (_timer >= STATE_CHANGE_TIME)
                {
                    _walkState = WalkState.walk;
                    _timer = 0f;
                    _isFacingRight = -_isFacingRight;
                    _enemyView.ChangeScaleX(_isFacingRight);
                }
                break;
            case WalkState.walk:
                _timer += Time.deltaTime;
                if (_timer >= STATE_CHANGE_TIME)
                {
                    _walkState = WalkState.idle;
                    _timer = 0f;
                }
                break;
            case WalkState.chase:
                if (Vector2.SqrMagnitude(transform.position - _player.position) > CHASE_DISTANCE * CHASE_DISTANCE)
                {
                    _walkState = WalkState.idle;
                    _timer = 0f;
                }
                break;
        }
    }

    public override void Attacked(int damage)
    {
        base.Attacked(damage);
        _walkState = WalkState.chase;
    }
}
