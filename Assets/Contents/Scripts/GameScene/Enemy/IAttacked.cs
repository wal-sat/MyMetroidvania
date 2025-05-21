using UnityEngine;

public interface IAttacked
{
    int HP { get; set; }
    void Attacked(int damage);
}
