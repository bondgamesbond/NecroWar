using UnityEngine;
using System.Collections;

public abstract class Unit : MonoBehaviour
{
    public float movementSpeed;
    public float healthPoint;
	public float attackPoint;
	public float attackSpeed;
    public float attackTimer;
    public GameObject necromancer;
	public GameObject target;
    public UnitStates state;
    
    public abstract void Attack();
    public abstract void Walk();
    public abstract void TargetAction();
    public abstract void Revive();
    public abstract void Die();
    public abstract void TakeDamage(float attackPoint);
}

public enum UnitStates
{
    Idle,
    Targeting,
    Attacking,
    Dying,
    Dead
};
