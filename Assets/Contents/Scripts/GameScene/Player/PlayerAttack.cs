using UnityEngine;
using System;
using Cysharp.Threading.Tasks;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject _attackPoint;
    [SerializeField] private float _attackDistance;
    [SerializeField] private float _attackTime;
    [SerializeField] private float _attackCoolTime;

    public Action<PlayerState> changePlayerState;
    private bool _isAttacking;

    private void Start()
    {
        _attackPoint.SetActive(false);
    }

    public void AttackUpdate(bool isFacingRight)
    {
        if (isFacingRight) _attackPoint.transform.localPosition = new Vector3(_attackDistance, 0, transform.localPosition.z);
        else _attackPoint.transform.localPosition = new Vector3(-_attackDistance, 0, transform.localPosition.z);

        if (S_InputSystemManager.Instance.isPushingAttack && !_isAttacking) Attack();
    }

    private async void Attack()
    {
        _isAttacking = true;
        _attackPoint.SetActive(true);
        changePlayerState(PlayerState.Attack);

        await UniTask.WaitForSeconds(_attackTime);

        _attackPoint.SetActive(false);
        changePlayerState(PlayerState.Normal);

        await UniTask.WaitForSeconds(_attackCoolTime);

        _isAttacking = false;
    }
}
