using UnityEngine;
using System.Collections;

public class ManagerDifficulty : SingleBehaviour<ManagerDifficulty> {

	public static ManagerDifficulty Instance {get; private set;}

	public enum Difficulty {easy, normal, hard};
	public Difficulty difficulty;

	// PowerUpLife, PowerUpTripleShoot, PowerUpAttract
	private int _ammoLife;
	private int _ammoTripleShoot;
	private int _ammoAttractShoot;

	// Chance spawn DestroySpikkingBalls
	private int _bonusChanceSpawn;
	private int _numberOrb;
	private int _damageNormalOrb, _damageMidOrb, _damageSmallOrb;
	
	void Awake()
	{
		if(Instance != null && Instance != this)
			Destroy(gameObject);

		Instance = this;
		DontDestroyOnLoad(gameObject);

		switch(difficulty)
		{
			case Difficulty.easy : 
				_ammoLife = 50;
				_ammoTripleShoot = 4;
				_ammoAttractShoot = 3;
				_bonusChanceSpawn = 50;
				_numberOrb = 2;
				_damageNormalOrb = -20;
				_damageMidOrb = -10;
				_damageSmallOrb = -5;

			break;

			case Difficulty.normal :
				_ammoLife = 30;
				_ammoTripleShoot = 3;
				_ammoAttractShoot = 2;
				_bonusChanceSpawn = 33;
				_numberOrb = 3;
				_damageNormalOrb = -25;
				_damageMidOrb = -15;
				_damageSmallOrb = -8;
			break;

			case Difficulty.hard : 

				_ammoLife = 20;
				_ammoTripleShoot = 2;
				_ammoAttractShoot = 1;
				_bonusChanceSpawn = 25;
				_numberOrb = 4;
				_damageNormalOrb = -35;
				_damageMidOrb = -20;
				_damageSmallOrb = -12;
			break;
		}
	}

	public int getAmmoLife()
	{
		return _ammoLife;
	}

	public int getAmmoTripleShoot()
	{
		return _ammoTripleShoot;
	}

	public int getAmmoAttractShoot()
	{
		return _ammoAttractShoot;
	}

	public int getBonusChanceSpawn()
	{
		return _bonusChanceSpawn;
	}

	public int getNumberOrb()
	{
		return _numberOrb;
	}

	public int getDamageNormalOrb()
	{
		return _damageNormalOrb;
	}

	public int getDamageMidOrb()
	{
		return _damageMidOrb;
	}

	public int getDamageSmallOrb()
	{
		return _damageSmallOrb;
	}
}
