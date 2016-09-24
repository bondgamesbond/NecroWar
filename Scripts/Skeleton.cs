using UnityEngine;
using System.Collections;

public class Skeleton : Unit {

	public  override void Attack (){
        if (target != null)
        {
            attackTimer += Time.deltaTime;

            if (attackTimer >= 1.0f / attackSpeed)
            {
                if (target.GetComponent<Unit>().state != UnitStates.Dying &&
                    target.GetComponent<Unit>().state != UnitStates.Dead)
                {
                    target.GetComponent<Unit>().TakeDamage(attackPoint);
                    attackTimer = 0;
                    Debug.Log(target.name + " " + target.GetComponent<Unit>().healthPoint);
                }
                else
                {
                    state = UnitStates.Idle;
                    target = null;
                }
            }
        }
    }

	public  override void Walk (){

		if (Vector2.Distance (transform.position, necromancer.transform.position) > 1) { 											//if the skeleton is far away 																														

			transform.position = Vector3.MoveTowards (transform.position, necromancer.transform.position, movementSpeed * Time.deltaTime);		//from its necromancer it moves to it
		} else {
			
			transform.position = Vector3.MoveTowards (transform.position, necromancer.transform.GetComponent<Necromancer>().way, necromancer.transform.GetComponent<Necromancer>().movementSpeed * Time.deltaTime);
		}

	}

	public  override void TargetAction (){
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, movementSpeed * Time.deltaTime);
        }
    }

	public  override void Revive (){

	}

	public  override void Die (){

	}

    public override void TakeDamage(float attackPoint)
    {
        healthPoint -= attackPoint;

        if (healthPoint <= 0)
        {
            state = UnitStates.Dead;
        }
    }

    // Use this for initialization
    void Start () {
	
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
