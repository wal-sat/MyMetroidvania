using UnityEngine;

public class AttackPoint : MonoBehaviour
{
    [SerializeField] private float _attackRadius;
    [SerializeField] private int _attackDamage;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attackRadius);
    }

    private void FixedUpdate()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, _attackRadius, LayerMask.GetMask("Enemy"));

        foreach (var enemy in hitEnemies)
        {
            IAttacked attacked = enemy.GetComponent<IAttacked>();
            if (attacked != null) attacked.Attacked(_attackDamage);
        }
    }
}
