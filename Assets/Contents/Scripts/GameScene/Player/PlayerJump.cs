using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private Transform _landingChecker;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpCancelForce;

    private Rigidbody2D _rigidbody;
    private bool _isJumping;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    public void JumpUpdate()
    {
        if (S_InputSystemManager.Instance.isPushingJump && !_isJumping && IsLanding()) Jump();
        else if (!S_InputSystemManager.Instance.isPushingJump && _isJumping) JumpCancel();
    }

    private void Jump()
    {
        _isJumping = true;
        _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocityX, _jumpForce);
    }
    private void JumpCancel()
    {
        _isJumping = false;
        if (_rigidbody.linearVelocityY > 0f) _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocityX, _rigidbody.linearVelocityY / _jumpCancelForce);
    }

    private bool IsLanding()
    {
        if (Physics2D.OverlapCircle(_landingChecker.position, 0.01f, _groundLayer)) return true;
        return false;
    }
}
