using UnityEngine;
using Cysharp.Threading.Tasks;

public class PlayerDamaged : MonoBehaviour
{
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private GameObject _damageParticle;
    [SerializeField] private float _damageCoolTime;

    private bool _isCoolTime;

    public void DamageUpdate()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(transform.position, new Vector2(1, 1), 0, LayerMask.GetMask("Enemy"));

        foreach (var enemy in hitEnemies)
        {
            IAttackPlayer attackPlayer = enemy.GetComponent<IAttackPlayer>();
            if (attackPlayer != null) Damage(attackPlayer.attackPower);
        }
    }

    private async void Damage(int damage)
    {
        if (_isCoolTime) return;
        _isCoolTime = true;
        int currentHP = S_PlayerInformation.Instance.DamageHp(damage);
        if (currentHP <= 0) Death();

        _uiManager.DisplayDamageText(damage, transform.position, Color.red);
        Instantiate(_damageParticle, transform.position + Vector3.back, Quaternion.identity);

        await UniTask.WaitForSeconds(_damageCoolTime);
        
        _isCoolTime = false;
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
