using UnityEngine;
using System.Collections;

public abstract class Unit : MonoBehaviour
{
	
	public float HealthPoint;
	public float AttackPoint;
	public float AttackSpeed;
	public GameObject Target;
	public float speed;
	public GameObject necro;


	public abstract void Attack ();

	public abstract void Walk ();

	public abstract void TargetAction ();

	public abstract void Revive ();

	public abstract void Die ();


}
public enum unitStates {idle, targetting, attacking, dying, dead};
