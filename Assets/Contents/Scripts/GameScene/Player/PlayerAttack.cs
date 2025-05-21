using UnityEngine;
using System;
using Cysharp.Threading.Tasks;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject _attackPoint;
    [SerializeField] float ATTACK_DISTANCE;
    [SerializeField] float ATTACK_TIME;
    [SerializeField] float ATTACK_COOL_TIME;

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

        if (S_InputSystemManager.instance.isPushingAttack && !_isAttacking) Attack();
    }

    private async void Attack()
    {
        _isAttacking = true;
        _attackPoint.SetActive(true);
        changePlayerState(PlayerState.attack);

        await UniTask.WaitForSeconds(ATTACK_TIME);

        _attackPoint.SetActive(false);
        changePlayerState(PlayerState.normal);

        await UniTask.WaitForSeconds(ATTACK_COOL_TIME);

        _isAttacking = false;
    }
}
