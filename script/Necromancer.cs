using UnityEngine;
using System.Collections;

public class Necromancer : Unit {

	private Vector2 way;
	public int VectorMaxRange;

	// Use this for initialization
	void Start () {
		way = new Vector2(Random.Range(-VectorMaxRange, VectorMaxRange) ,Random.Range(-VectorMaxRange, VectorMaxRange));
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector2.MoveTowards(transform.position, way, 2 * Time.deltaTime);
		if ((transform.position.x == way.x && transform.position.y == way.y))
		{
			way = new Vector2(Random.Range(-VectorMaxRange, VectorMaxRange), Random.Range(-VectorMaxRange, VectorMaxRange));
		}
	
	}
}
