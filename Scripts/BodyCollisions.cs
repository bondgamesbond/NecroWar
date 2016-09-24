using UnityEngine;
using System.Collections;

public class BodyCollisions : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name != "BackGround")
        {
            if (other.GetComponentInParent<Unit>().necromancer != GetComponentInParent<Unit>().necromancer)
            {
                if (other.name == "AttackCollider")
                {
                    other.transform.parent.GetComponent<Unit>().state = UnitStates.Attacking;
                }
                else if (other.name == "LineOfSight")
                {
                    other.transform.parent.GetComponent<Unit>().state = UnitStates.Targeting;
                    other.transform.parent.GetComponent<Unit>().target = transform.parent.gameObject;
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name != "BackGround")
        {
            if (other.GetComponentInParent<Unit>().necromancer != GetComponentInParent<Unit>().necromancer)
            {
                if (other.name == "AttackCollider")
                {
                    other.transform.parent.GetComponent<Unit>().state = UnitStates.Targeting;
                }
                else if (other.name == "LineOfSight")
                {
                    other.transform.parent.GetComponent<Unit>().state = UnitStates.Idle;
                    other.GetComponentInParent<Unit>().target = null;
                }
            }
        }
    }
}
