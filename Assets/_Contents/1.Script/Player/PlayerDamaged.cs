using UnityEngine;
using Cysharp.Threading.Tasks;

public class PlayerDamaged : MonoBehaviour
{
    [SerializeField] UIManager uiManager;
    [SerializeField] GameObject DamageParticle;
    [SerializeField] private float DAMAGE_COOL_TIME;

    private bool _isCoolTime;

    private void Start()
    {
        S_PlayerInformation.instance.Initialize();
    }

    private void Update()
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
        int currentHP = S_PlayerInformation.instance.DamageHp(damage);
        uiManager.HPTextUpdate(currentHP, S_PlayerInformation.instance.MAX_HP_AMOUNT);
        if (currentHP <= 0) Death();

        uiManager.DisplayDamageText(damage, transform.position);
        GameObject particle = Instantiate(DamageParticle, transform.position + Vector3.back, Quaternion.identity);

        await UniTask.WaitForSeconds(DAMAGE_COOL_TIME);
        
        _isCoolTime = false;
        Destroy(particle);
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
