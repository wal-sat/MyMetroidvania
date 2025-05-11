using UnityEngine;

public class PlayerDamaged : MonoBehaviour
{
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IAttackPlayer attackPlayer = collision.GetComponent<IAttackPlayer>();
        if (attackPlayer != null)
        {
            Damage(attackPlayer.attackPower);
        }
    }

    private void Damage(int damage)
    {
        HP -= damage;
        Debug.Log($"Player Damaged: {damage}");
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
