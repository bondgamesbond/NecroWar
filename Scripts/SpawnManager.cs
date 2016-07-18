using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour {
	public List<GameObject> objects;
	public List<float> spawnRates;
	public List<List<GameObject>> createdObject;
	public int count;


	// Use this for initialization
	void Start () {
		for(int i=0; i < objects.Count; i++){
			createdObject.Add (new List<GameObject>());
			for(int j=0; j < count; j++){
				createdObject[i].Add (Instantiate (objects[i], Vector3.zero,Quaternion.identity) as GameObject);
			}
		}	
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}
}
