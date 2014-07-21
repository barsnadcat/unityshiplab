using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour 
{
	public float health;
	public float shield;
	public float shieldRegen;
	public int weaponSlots;
	public int moduleSlots;
	
	private float nextRegen;
	private float shieldMax;
	private GameObject[] weapons;

	void Awake()
	{
		shieldMax = shield;
		weapons = new GameObject[weaponSlots];
	}

	void Start()
	{
		gameObject.SetActive(false);
	}

	public float GetShield()
	{
		return shield;
	}

	public float GetHealth()
	{
		return health;
	}

	public void SetWeapon(int slot, string name)
	{
		Destroy (weapons [slot]);
		Vector3 position = transform.position + transform.forward * 2 + transform.right * (0.5f - slot);
		GameObject wpn = Instantiate(Resources.Load(name), position, transform.rotation) as GameObject;
		wpn.transform.parent = transform;
		weapons [slot] = wpn;
	}

	void Update()
	{
		if (Time.time > nextRegen)
		{
			nextRegen = Time.time + 1;
			shield += shieldRegen;
			if (shield > shieldMax)
			{
				shield = shieldMax;
			}
		}
	}

	void OnTriggerEnter(Collider other) 
	{
		Projectile proj = other.GetComponent<Projectile> ();
		if (proj != null)
		{
			shield -= proj.damage;
			float healthDamage = 0;
			if(shield < 0)
			{
				healthDamage = -shield;
				shield = 0;
			}
		
			health -= healthDamage;
			if(health < 0)
			{
				Destroy(gameObject);
			}
			Destroy(other.gameObject);
		}
	}
}
