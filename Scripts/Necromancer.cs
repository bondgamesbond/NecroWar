using UnityEngine;
using System.Collections;

public class Necromancer : Unit
{

	public Vector2 way;
	public int VectorMaxRange;


	public  override void Attack (){
		
	}

	public  override void Walk (){
		transform.position = Vector2.MoveTowards(transform.position, way, speed * Time.deltaTime);
		if ((transform.position.x == way.x && transform.position.y == way.y))
		{
			way = new Vector2(Random.Range(-VectorMaxRange, VectorMaxRange), Random.Range(-VectorMaxRange, VectorMaxRange));
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
		way = new Vector2(Random.Range(-VectorMaxRange, VectorMaxRange) ,Random.Range(-VectorMaxRange, VectorMaxRange));
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