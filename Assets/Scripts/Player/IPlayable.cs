using UnityEngine;
using System.Collections;

public class IPlayable : MonoBehaviour
{
	public Player _owner;
	public int _maxHealth;

	private int _health;

	public bool IsEnemy (Player player)
	{
		return _owner.PlayerId != player.PlayerId;
	}

	public void DealDamage (int damage)
	{
		_health = Mathf.Max (_health - damage, 0);
	}

}
