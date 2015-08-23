using UnityEngine;
using System.Collections;

public class Unit : IPlayable
{
	public bool _moveForward = false;
	public float _moveSpeed = 1f;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void FixedUpdate ()
	{
		if (_moveForward) {
			transform.position += transform.forward * Time.deltaTime * _moveSpeed;
		}
	}

}
