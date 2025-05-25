using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float MOVE_SPEED = 5f;
    
    [HideInInspector] public bool isFacingRight = true;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void MovementUpdate()
    {
        Move(S_InputSystemManager.Instance.playerMove);
    }

    private void Move(Vector2 direction)
    {
        _rigidbody.linearVelocity = new Vector2(direction.x * MOVE_SPEED * Time.fixedDeltaTime, _rigidbody.linearVelocityY);

        if (direction.x > 0f) isFacingRight = true;
        else if (direction.x < 0f) isFacingRight = false;
    }
}
