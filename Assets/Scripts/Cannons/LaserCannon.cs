using UnityEngine;
using System.Collections;

public class LaserCannon : Cannon
{
	public float _fireTime;

	protected LineRenderer _lineRenderer;
	protected float _stopFireTime;
	protected Unit _target;

	void Start ()
	{
		_lineRenderer = GetComponent<LineRenderer> ();

		_lineRenderer.enabled = false;
	}

	public override void Fire (Unit position)
	{
		if (_nextFire <= Time.timeSinceLevelLoad) {
			_nextFire = Time.timeSinceLevelLoad + _reloadTime;
			_stopFireTime = Time.timeSinceLevelLoad + _fireTime;
			_lineRenderer.SetPosition (0, _projectileSpawnPosition.position);
			_lineRenderer.SetPosition (1, position.transform.position);
			_lineRenderer.enabled = true;

			_target = position;
		}
	}

	void Update ()
	{
		if (_stopFireTime <= Time.timeSinceLevelLoad) {
			_lineRenderer.enabled = false;
		} else if (_target != null) {
			_lineRenderer.SetPosition (0, _projectileSpawnPosition.position);
			_lineRenderer.SetPosition (1, _target.transform.position);
		}
	}
}
