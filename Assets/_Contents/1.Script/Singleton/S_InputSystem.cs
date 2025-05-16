using UnityEngine;
using UnityEngine.InputSystem;

public enum ActionMapKind { Player, UI }

public class S_InputSystem : Singleton<S_InputSystem>
{
    [SerializeField] InputActionAsset _inputActionAsset;

    [HideInInspector] public Vector2 playerMove;
    [HideInInspector] public float dashDirection;
    [HideInInspector] public bool isPushingJump;
    [HideInInspector] public bool isPushingAttack;
    [HideInInspector] public bool isPushingPause;

    [HideInInspector] public Vector2 UIMove;
    [HideInInspector] public bool isPushingSelect;
    [HideInInspector] public bool isPushingCancel;

    public void SwitchActionMap(ActionMapKind actionMap)
    {
        foreach (var map in _inputActionAsset.actionMaps) map.Disable();

        switch (actionMap)
        {
            case ActionMapKind.Player:
                _inputActionAsset.FindActionMap("Player").Enable();
                break;
            case ActionMapKind.UI:
                _inputActionAsset.FindActionMap("UI").Enable();
                break;
        }
    }

    // ---------------- Player Map ----------------

    public void Move(InputAction.CallbackContext context)
    {
        if (context.performed) playerMove = context.ReadValue<Vector2>();
        else if (context.canceled) playerMove = Vector2.zero;
    }
    public void Dash(InputAction.CallbackContext context)
    {
        if (context.performed) dashDirection = context.ReadValue<float>();
        else if (context.canceled) dashDirection = 0;
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed) isPushingJump = true;
        else if (context.canceled) isPushingJump = false;
    }
    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed) isPushingAttack = true;
        else if (context.canceled) isPushingAttack = false;
    }
    public void Pause(InputAction.CallbackContext context)
    {
        if (context.performed) isPushingPause = true;
        else if (context.canceled) isPushingPause = false;
    }

    // ---------------- UI Map ----------------

    public void Navigate(InputAction.CallbackContext context)
    {
        if (context.performed) UIMove = context.ReadValue<Vector2>();
        else if (context.canceled) UIMove = Vector2.zero;
    }
    public void Submit(InputAction.CallbackContext context)
    {
        if (context.performed) isPushingSelect = true;
        else if (context.canceled) isPushingSelect = false;
    }
    public void Cancel(InputAction.CallbackContext context)
    {
        if (context.performed) isPushingCancel = true;
        else if (context.canceled) isPushingCancel = false;
    }
}
