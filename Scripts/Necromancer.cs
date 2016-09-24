using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Necromancer : Unit
{
	public Vector3 way;
	public int VectorMaxRange;
    public List<GameObject> army;

    public override void Attack()
    {
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
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, movementSpeed * Time.deltaTime);
        }
    }

	public override void Revive (){
		
	}

	public override void Die (){
		
	}

    public override void TakeDamage(float attackPoint)
    {
        healthPoint -= attackPoint;

        if (healthPoint <= 0)
        {
            state = UnitStates.Dead;
        }
    }

    void Start ()
    {
        healthPoint = 100;
        attackPoint = 5;
        attackSpeed = 1;

        way = new Vector3(Random.Range(-VectorMaxRange, VectorMaxRange), Random.Range(-VectorMaxRange, VectorMaxRange), 0.0f);
    }

    void Update () {
        //Debug.Log(name + " " + state);
		if (state == UnitStates.Idle)
        {
            Walk();
        }
        else if (state == UnitStates.Targeting)
        {
            TargetAction();
        }
        else if (state == UnitStates.Attacking)
        {
            Attack();
        }
        else if (state == UnitStates.Dying)
        {

        }
        else if (state == UnitStates.Dead)
        {
            gameObject.SetActive(false);
        }
	}
}
