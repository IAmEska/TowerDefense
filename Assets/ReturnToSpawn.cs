using UnityEngine;
using System.Collections;

public class ReturnToSpawn : MonoBehaviour
{

	public Transform _spawn;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnTriggerEnter (Collider other)
	{
		Unit u = other.GetComponent<Unit> ();
		if (u != null) {
			u.transform.position = _spawn.transform.position;
		}
	}
}
