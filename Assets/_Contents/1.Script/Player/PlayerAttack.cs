using UnityEngine;
using System;
using Cysharp.Threading.Tasks;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject _attackPoint;
    [SerializeField] float ATTACK_DISTANCE;

    public Action<PlayerState> changePlayerState;
    private bool _isAttacking;

    private void Start()
    {
        _attackPoint.SetActive(false);
    }

    public void AttackUpdate(bool isFacingRight)
    {
        if (isFacingRight) _attackPoint.transform.localPosition = new Vector3(ATTACK_DISTANCE, 0, transform.localPosition.z);
        else _attackPoint.transform.localPosition = new Vector3(-ATTACK_DISTANCE, 0, transform.localPosition.z);

        if (S_InputSystem.instance.isPushingAttack && !_isAttacking) Attack();
    }

    private async void Attack()
    {
        _isAttacking = true;
        _attackPoint.SetActive(true);
        changePlayerState(PlayerState.attack);

        await UniTask.WaitForSeconds(0.5f);

        _attackPoint.SetActive(false);
        changePlayerState(PlayerState.normal);

        await UniTask.WaitForSeconds(0.25f);

        _isAttacking = false;
    }
}
