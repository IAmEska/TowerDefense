using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour
{
	public Projectile.ProjectileType _projectileType;
	public float _reloadTime;
	public Transform _projectileSpawnPosition;

	protected float _nextFire;
	private ProjectileCache _cache;
	protected Tower _tower;

	// Use this for initialization
	void Start ()
	{
		_cache = FindObjectOfType<ProjectileCache> ();
		_tower = GetComponentInParent<Tower> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		 
	}

	public virtual void Fire (Unit position)
	{
		if (_nextFire <= Time.timeSinceLevelLoad) {
			_nextFire = Time.timeSinceLevelLoad + _reloadTime;
			Projectile p = _cache.GetProjectile (_projectileType);
			p._owner = _tower._owner;
			p.transform.position = _projectileSpawnPosition.position;
			p.Launch (position);

		}
	}
}
