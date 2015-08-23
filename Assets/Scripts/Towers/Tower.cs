using UnityEngine;
using System.Collections;

public class Tower : IPlayable
{

	public Unit _target;
	public float _range;
	public Transform _rotatingPart;
	public Cannon[] _cannons;
	public float _rotatingSpeed = 25f;
	public float _fireAngle = 25f;

	private bool _isRotating = false;

	private SphereCollider _collider;

	// Use this for initialization
	void Start ()
	{
		_collider = gameObject.AddComponent<SphereCollider> ();
		_collider.isTrigger = true;
		_collider.radius = _range;

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (_target != null && !_isRotating) {
			Vector3 dir = _target.transform.position - transform.position;
			Debug.DrawRay (transform.position, dir, Color.red);
			foreach (Cannon cannon in _cannons) {
				cannon.Fire (_target);
			}
		}
	}

	void FixedUpdate ()
	{
		FaceTarget ();

	}

	private void FaceTarget ()
	{
		if (_target != null) {
			Vector3 targetPosition = _target.transform.position;
			var dir = _target.transform.position - _rotatingPart.position;
			dir.y = 0;
			Quaternion rotation = Quaternion.LookRotation (dir);
			_rotatingPart.rotation = Quaternion.Slerp (_rotatingPart.rotation, rotation, Time.deltaTime * _rotatingSpeed);
			if (Vector3.Angle (_rotatingPart.forward, dir) < _fireAngle) {
				_isRotating = false;
			} else {
				_isRotating = true;
			}
		
		}
	}

	private void CheckNewTarget (Collider other)
	{
		if (_target == null) {
			_isRotating = true;
			Unit unit = other.GetComponent<Unit> ();
			if (unit != null && unit.IsEnemy (_owner)) {
				_target = unit;
			} 
		}
	}

	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere (transform.position, _range);
	}


	void OnTriggerEnter (Collider other)
	{
		CheckNewTarget (other);
	}

	void OnTriggerStay (Collider other)
	{
		CheckNewTarget (other);
	}

	void OnTriggerExit (Collider other)
	{
		if (_target != null) {
			Unit unit = _target.GetComponent<Unit> ();
			if (unit == _target)
				_target = null;
		}
	}
}
