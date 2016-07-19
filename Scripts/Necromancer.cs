using UnityEngine;
using System.Collections;

public class Necromancer : Unit
{
	private Vector3 way;
	public int VectorMaxRange;

    public override void Attack()
    {

    }

    public override void Walk()
    {
        if (way != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, way, movementSpeed * Time.deltaTime);

            if (transform.position == way)
            {
                way = new Vector3(Random.Range(-VectorMaxRange, VectorMaxRange), Random.Range(-VectorMaxRange, VectorMaxRange), 0.0f);
            }
        }
    }

    public override void TargetAction()
    {
        if (target != null)
        {
            Debug.Log("asd");
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, movementSpeed * Time.deltaTime);
        }
    }

	public override void Revive (){
		
	}

	public override void Die (){
		
	}

	void Update () {
        Debug.Log(name + " " + state);
		if (state == UnitStates.Idle)
        {
            Walk();
        }
        else if (state == UnitStates.Targeting)
        {
            TargetAction();
        }
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
                other.transform.parent.GetComponent<Unit>().target = this.gameObject;
            }
        }
    }
}
