using UnityEngine;
using System.Collections;

public abstract class Unit : MonoBehaviour
{
	
	public float healthPoint;
	public float attackPoint;
	public float attackSpeed;
	public GameObject target;
	public float speed;
	public GameObject necromancer;
	public UnitStates state;


	public abstract void Attack ();

	public abstract void Walk ();

	public abstract void TargetAction ();

	public abstract void Revive ();

	public abstract void Die ();


}
public enum UnitStates {Idle, Targeting, Attacking, Dying, Dead};
