using UnityEngine;

public class AttackPoint : MonoBehaviour
{
    [SerializeField] private float ATTACK_RADIUS;
    [SerializeField] private int ATTACK_DAMAGE;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ATTACK_RADIUS);
    }

    private void FixedUpdate()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, ATTACK_RADIUS, LayerMask.GetMask("Enemy"));

        foreach (var enemy in hitEnemies)
        {
            IAttacked attacked = enemy.GetComponent<IAttacked>();
            if (attacked != null) attacked.Attacked(ATTACK_DAMAGE);
        }
    }
}
