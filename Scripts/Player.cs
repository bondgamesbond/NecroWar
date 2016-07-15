using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : Unit
{
	RaycastHit2D hit;
	Ray2D ray;
	Vector3 newPosition;
	private float playerSpeedOffset = 0.5f; 

	// Use this for initialization
	void Start ()
	{
		
	}



	// Update is called once per frame
	void FixedUpdate() {
		if (Input.GetMouseButton(0))
		{
			Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			mouse[2] = 0;

			hit = Physics2D.Raycast(mouse, Vector2.zero);

			if (!hit.collider.CompareTag("Floor"))
			{
				Debug.Log ("çıktı");
				//transform.Translate(origin * Time.fixedDeltaTime);
			}
			else{
				
				Vector3 difference = mouse - transform.position;
				transform.Translate(playerSpeedOffset *difference * Time.deltaTime);

			}
		}
	}
}




