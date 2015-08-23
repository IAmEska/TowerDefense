using UnityEngine;
using System.Collections;

public class ProjectileCache : MonoBehaviour
{
	public Projectile _default;
	public ProjectileArtillery _defaultArtillery;
	public ProjectileHomingMissile _defaultHomingMissile;

	private Cache<Projectile> _projectiles;
	private Cache<ProjectileArtillery> _pArtillery;
	private Cache<ProjectileHomingMissile> _pMissile;

	// Use this for initialization
	void Start ()
	{
		_projectiles = new Cache<Projectile> ();
		_pArtillery = new Cache<ProjectileArtillery> ();
		_pMissile = new Cache<ProjectileHomingMissile> ();
	}
	
	public Projectile GetProjectile (Projectile.ProjectileType projectile)
	{
		Projectile p;
		switch (projectile) {
		default:
			p = _projectiles.GetItem ();
			if (p == null) {
				p = Instantiate (_default);
			}
			break;

		case Projectile.ProjectileType.Artillery:
			p = _pArtillery.GetItem ();
			if (p == null) {
				p = Instantiate (_defaultArtillery);
			}
			break;

		case Projectile.ProjectileType.HomingMissile:
			p = _pMissile.GetItem ();
			if (p == null) {
				p = Instantiate (_defaultHomingMissile);
			}
			break;
		}

		p.transform.parent = transform.parent;
		p.gameObject.SetActive (true);
		return p;
	}

	public void ReturnProjectile (Projectile projectile)
	{
		bool isCached = false;

		if (projectile is ProjectileArtillery) {
			isCached = _pArtillery.AddItem (projectile as ProjectileArtillery);
		} else if (projectile is ProjectileHomingMissile) {
			isCached = _pMissile.AddItem (projectile as ProjectileHomingMissile);
		} else {
			isCached = _projectiles.AddItem (projectile);
		}

		if (!isCached) {
			Destroy (projectile.gameObject);
		} else {
			projectile.gameObject.SetActive (false);
		}
	}
}
