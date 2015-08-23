using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Projectile : IPlayable
{

	public enum ProjectileType
	{
		Default,
		Artillery,
		Laser,
		HomingMissile
	}

	public ProjectileCache _projectileCache;
	public float _lifeTime;
	public float _speed;

	protected float _diesAt;
	protected Rigidbody _rigidBody;
	protected IPlayable _target;


	// Use this for initialization
	void Start ()
	{
		_rigidBody = GetComponent<Rigidbody> ();
	}



	public virtual void Launch (IPlayable target)
	{
		_diesAt = Time.timeSinceLevelLoad + _lifeTime;
		_target = target;
	}

	
	// Update is called once per frame
	void  Update ()
	{
		if (_diesAt <= Time.timeSinceLevelLoad) {
			_target = null;
			_projectileCache.ReturnProjectile (this);
		} 
	}

	void FixedUpdate ()
	{
		if (_target != null) {
			transform.LookAt (_target.transform.position, Vector3.up);
			transform.position += transform.forward * Time.deltaTime * _speed;
		}
	}

	void OnTriggerEnter (Collider other)
	{
		IPlayable comp = other.GetComponent<IPlayable> ();
		if (comp != null) {
			if (comp.IsEnemy (_owner)) {
				_diesAt = Time.timeSinceLevelLoad;
			}
		}
	}
}
