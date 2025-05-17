using UnityEngine;
using UnityEngine.InputSystem;

public enum ActionMapKind { Player, UI }

public class S_InputSystem : Singleton<S_InputSystem>
{
    [HideInInspector] public Vector2 playerMove;
    [HideInInspector] public float dashDirection;
    [HideInInspector] public bool isPushingJump;
    [HideInInspector] public bool isPushingAttack;
    [HideInInspector] public bool isPushingPause;

    [HideInInspector] public Vector2 UIMove;
    [HideInInspector] public bool isPushingSubmit;
    [HideInInspector] public bool isPushingCancel;

    [HideInInspector] public bool canInput;

    private PlayerInput playerInput;

    public override void Awake()
    {
        base.Awake();

        playerInput = GetComponent<PlayerInput>();
    }
    
    public void SwitchActionMap(ActionMapKind actionMap)
    {
        if (playerInput.currentActionMap.name == actionMap.ToString()) return;

        playerInput.SwitchCurrentActionMap(actionMap.ToString());
    }

    // ---------------- Player Map ----------------

    public void Move(InputAction.CallbackContext context)
    {
        if (context.performed) playerMove = context.ReadValue<Vector2>();
        else if (context.canceled) playerMove = Vector2.zero;

        if (!canInput) playerMove = Vector2.zero;
    }
    public void Dash(InputAction.CallbackContext context)
    {
        if (context.performed) dashDirection = context.ReadValue<float>();
        else if (context.canceled) dashDirection = 0;

        if (!canInput) dashDirection = 0;
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed) isPushingJump = true;
        else if (context.canceled) isPushingJump = false;

        if (!canInput) isPushingJump = false;
    }
    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed) isPushingAttack = true;
        else if (context.canceled) isPushingAttack = false;

        if (!canInput) isPushingAttack = false;
    }
    public void Pause(InputAction.CallbackContext context)
    {
        if (context.performed) isPushingPause = true;
        else if (context.canceled) isPushingPause = false;

        if (!canInput) isPushingPause = false;
    }

    // ---------------- UI Map ----------------

    public void Navigate(InputAction.CallbackContext context)
    {
        if (context.performed) UIMove = VectorNormalization(context.ReadValue<Vector2>());
        else if (context.canceled) UIMove = Vector2.zero;

        if (!canInput) UIMove = Vector2.zero;
    }
    public void Submit(InputAction.CallbackContext context)
    {
        if (context.performed) isPushingSubmit = true;
        else if (context.canceled) isPushingSubmit = false;

        if (!canInput) isPushingSubmit = false;
    }
    public void Cancel(InputAction.CallbackContext context)
    {
        if (context.performed) isPushingCancel = true;
        else if (context.canceled) isPushingCancel = false;

        if (!canInput) isPushingCancel = false;
    }

    // ----------------------------------------

    private Vector2 VectorNormalization(Vector2 vector2)
    {
        if (vector2.x > 0.5f) return Vector2.right;
        if (vector2.x < -0.5f) return Vector2.left;
        if (vector2.y > 0.5f) return Vector2.up;
        if (vector2.y < -0.5f) return Vector2.down;
        return Vector2.zero;
    }
}
