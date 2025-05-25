using UnityEngine;
using Cysharp.Threading.Tasks;

public class PlayerDamaged : MonoBehaviour
{
    [SerializeField] UIManager uiManager;
    [SerializeField] GameObject DamageParticle;
    [SerializeField] private float DAMAGE_COOL_TIME;

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

        uiManager.DisplayDamageText(damage, transform.position, Color.red);
        Instantiate(DamageParticle, transform.position + Vector3.back, Quaternion.identity);

        await UniTask.WaitForSeconds(DAMAGE_COOL_TIME);
        
        _isCoolTime = false;
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
