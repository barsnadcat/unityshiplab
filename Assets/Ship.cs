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
	private GameObject[] modules;


	public void Init()
	{
		float fireRateMult = 1.0f;
		for (int i = 0; i < modules.Length; ++i) 
		{
			Module m = modules[i].GetComponent<Module>();
			shield += m.shield;
			health += m.health;
			shieldRegen *= m.shieldRegen;
			fireRateMult *= m.fireRate;
		}

		shieldMax = shield;
		for(int i = 0; i < weapons.Length; ++i)
		{
			weapons[i].GetComponent<Weapon>().rate *= fireRateMult;
		}
	}


	public float GetShield()
	{
		return shield;
	}

	public float GetHealth()
	{
		return health;
	}

	public void SetModule(int slot, string name)
	{
		Destroy (modules [slot]);
		GameObject module = Instantiate(Resources.Load(name), transform.position, transform.rotation) as GameObject;
		module.transform.parent = transform;
		modules [slot] = module;
	}

	public void SetWeapon(int slot, string name)
	{
		Destroy (weapons [slot]);
		Vector3 position = transform.position + transform.forward * 2 + transform.right * (0.5f - slot);
		GameObject wpn = Instantiate(Resources.Load(name), position, transform.rotation) as GameObject;
		wpn.transform.parent = transform;
		weapons [slot] = wpn;
	}

	void Start()
	{
		weapons = new GameObject[weaponSlots];
		modules = new GameObject[moduleSlots];
		gameObject.SetActive(false);
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
