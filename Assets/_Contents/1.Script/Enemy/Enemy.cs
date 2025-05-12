using UnityEngine;
using Cysharp.Threading.Tasks;

public class Enemy : MonoBehaviour, IAttacked, IAttackPlayer
{
    [SerializeField] private int INITIAL_HP;
    [SerializeField] private float DAMAGE_COOL_TIME;
    [SerializeField] private int ATTACK_POWER;

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

    public int attackPower { get => ATTACK_POWER; }

    private void Start()
    {
        HP = INITIAL_HP;
    }

    public async void Attacked(int damage)
    {
        if (_isCoolTime) return;
        _isCoolTime = true;
        HP -= damage;

        await UniTask.WaitForSeconds(DAMAGE_COOL_TIME);
        
        _isCoolTime = false;
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
