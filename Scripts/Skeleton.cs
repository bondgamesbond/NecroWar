using UnityEngine;
using System.Collections;

public class Skeleton : Unit {

	public  override void Attack (){

	}

	public  override void Walk (){

		if (Vector2.Distance (transform.position, necromancer.transform.position) > 0.01) { 											//if the skeleton is far away 																														

			transform.position = Vector2.MoveTowards (transform.position, necromancer.transform.position, speed * Time.deltaTime);		//from its necromancer it moves to it
		} else {
			
			transform.position = Vector2.MoveTowards (transform.position, necromancer.transform.GetComponent<Necromancer>().way, necromancer.transform.GetComponent<Necromancer>().speed * Time.deltaTime);
		}

	}

	public  override void TargetAction (){

	}

	public  override void Revive (){

	}

	public  override void Die (){

	}
	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (GetComponent<BoxCollider2D>().IsTouching(other))
		{
			if (other.name == "AttackCollider")
			{
				other.transform.parent.GetComponent<Unit>().state = UnitStates.Attacking;
			}
			else if (other.name == "LineOfSight")
			{
				other.transform.parent.GetComponent<Unit>().state = UnitStates.Targeting;
			}
		}
	}

	
	// Update is called once per frame
	void FixedUpdate () {
		
		if (state == UnitStates.Idle) { //checks wheter the skeleton is in idle state

			Walk ();	
		} else if (state == UnitStates.Targeting) { //checks wheter the skeleton is in targetting state

			TargetAction ();
		} else if (state == UnitStates.Attacking) { //checks wheter the skeleton is in attacking state

			Attack ();
		} else if (state == UnitStates.Dying) { //checks wheter the skeleton is in dying state

			Die ();
		} else { //checks wheter the skeleton is in dead state

			Revive ();
		}

	}
}
