using UnityEngine;
using Cysharp.Threading.Tasks;

public class PlayerDamaged : MonoBehaviour
{
    [SerializeField] GameObject DamageParticle;
    [SerializeField] private int INITIAL_HP;
    [SerializeField] private float DAMAGE_COOL_TIME;

    private bool _isCoolTime;

    private int _hp;
    public int HP
    {
        get => _hp;
        set
        {
            _hp = value;
            if (_hp <= 0) Death();
        }
    }

    private void Start()
    {
        HP = INITIAL_HP;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        IAttackPlayer attackPlayer = collision.GetComponent<IAttackPlayer>();
        if (attackPlayer != null)
        {
            Damage(attackPlayer.attackPower);
        }
    }

    private async void Damage(int damage)
    {
        if (_isCoolTime) return;
        _isCoolTime = true;
        HP -= damage;

        GameObject particle = Instantiate(DamageParticle, transform.position, Quaternion.identity);

        await UniTask.WaitForSeconds(DAMAGE_COOL_TIME);
        
        _isCoolTime = false;
        Destroy(particle);
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
