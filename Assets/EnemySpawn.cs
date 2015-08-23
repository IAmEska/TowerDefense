using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{

	public float _spawnTime;
	public Unit _enemyUnit;
	public int _maxUnits;

	public Transform _spawn;
	public Transform _destroy;

	private float _nextSpawnTime;
	private int _spawned;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (_nextSpawnTime <= Time.timeSinceLevelLoad && _spawned < _maxUnits) {
			Unit go = Instantiate (_enemyUnit);
			go.transform.position = _spawn.position;
			go.transform.LookAt (new Vector3 (_destroy.position.x, go.transform.position.y, _destroy.position.z));
			go._moveForward = true;
			_spawned++;
			_nextSpawnTime = Time.timeSinceLevelLoad + _spawnTime;
		}
	}
}
