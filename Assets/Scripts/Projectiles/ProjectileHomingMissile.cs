using UnityEngine;
using System.Collections;

public class ProjectileHomingMissile : Projectile
{

	public float _damping;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (_target != null) {
			transform.Translate (Vector3.forward * Time.deltaTime * _speed);
			var rotation = Quaternion.LookRotation (_target.transform.position - transform.position);
			transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * _damping);
			transform.position += transform.forward * Time.deltaTime * _speed;
		}
	}
}
