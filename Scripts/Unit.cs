using UnityEngine;
using System.Collections;

public abstract class Unit : MonoBehaviour
{
    public float movementSpeed;
    public float healthPoint;
	public float attackPoint;
	public float attackSpeed;
    public GameObject necromancer;
	public GameObject target;
    public UnitStates state;
    
    public abstract void Attack();
    public abstract void Walk();
    public abstract void TargetAction();
    public abstract void Revive();
    public abstract void Die();
}

public enum UnitStates
{
    Idle,
    Targeting,
    Attacking,
    Dying,
    Dead
};
