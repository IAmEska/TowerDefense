using UnityEngine;
using System.Collections;

public class ProjectileArtillery : Projectile
{

	public float _explodeRadius = 10f;
	protected Vector3 _explodePosition;

	public override void Launch (IPlayable target)
	{
		transform.LookAt (target.transform.position, Vector3.up);

		_explodePosition = target.transform.position;

		Vector3 toTarget = target.transform.position - this.transform.position;
		Vector3 toTargetXZ = toTarget;
		toTargetXZ.y = 0;

		float y = toTarget.y;
		float xz = toTargetXZ.magnitude;
		float t = _lifeTime;

		//_lifeTime == time
		float v0y = y / t + 0.5f * Physics.gravity.magnitude * t;
		float v0xz = xz / t;


		Vector3 result = toTargetXZ.normalized;
		result *= v0xz;
		result.y = v0y;

		_diesAt = Time.timeSinceLevelLoad + _lifeTime;
		_target = target;

		_rigidBody = GetComponent<Rigidbody> ();
		_rigidBody.velocity = Vector3.zero;
		_rigidBody.AddForce (result, ForceMode.VelocityChange);
	}

	public void FixedUpdate ()
	{

	}

	void OnDrawGizmosSelected ()
	{
		if (_target != null) {
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere (_explodePosition, _explodeRadius);
		}
	}

}
