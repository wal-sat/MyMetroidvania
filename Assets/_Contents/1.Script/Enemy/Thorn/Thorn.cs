using Unity.VisualScripting;
using UnityEngine;

public class Thorn : MonoBehaviour, IAttackPlayer
{
    [SerializeField] private int ATTACK_POWER;
    
    public int attackPower{ get => ATTACK_POWER; }
}
