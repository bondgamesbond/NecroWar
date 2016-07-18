using UnityEngine;
using System.Collections;

public class PlayerInputs : MonoBehaviour
{
    RaycastHit2D hit;

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouse[2] = 0;

            hit = Physics2D.Raycast(mouse, Vector2.zero);

            if (hit.collider.CompareTag("Floor"))
            {
                Vector3 difference = mouse - transform.position;
                transform.Translate(GetComponent<Player>().movementSpeed * difference * Time.deltaTime);
            }
        }
    }
}
