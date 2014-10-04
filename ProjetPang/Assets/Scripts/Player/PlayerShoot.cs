﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/************************************************************************************************
* On the player
**  A script that allows the player to shoot pooled arrows, and change his ammo.
************************************************************************************************/

public class PlayerShoot : MonoBehaviour {
	
	public float speed;
	public string[] shootType;
	
	//Current position of the ammo in the array.
	private int _currentPosArray = 0;
	
	private GameObject _shootedArrow;
	private ArrowMovement _shootSpeed;

	//Pool object

	private bool _canShoot = true;
	
	private Animator anim;
	
	private float timeShoot = 0f;
	private float fireRate = 1f;

	private int _numberArrowOnGame;

	private  List<GameObject> _arrows = new List<GameObject>();

	// Temporary value to know if the number of ammo exced 4 or not.
	private float tempAmmoTripleShoot;
	private float tempAmmoAttractShoot;

	void Awake()
	{	
		anim = GetComponent<Animator>();
		_numberArrowOnGame = 0;
	}

	void Start()
	{
		_arrows = ManagerArray.instance.listArrow;
	}

	// I create a new one each time that the player can shoot.
	void Update()
	{

		CanShoot();
	}

	void CanShoot()
	{
		// To know when the player can shoot.
		timeShoot += Time.deltaTime;
		
		if(ManagerArray.instance.countActiveInHiearchy(ManagerArray.instance.listArrow) <= _numberArrowOnGame)
		{
			if(ManagerInput.instance.isShooting()) // If i press the buttons to shoot
				Shoot();
		}
		else
			anim.SetBool("isShooting", false);
	}

	void Shoot()
	{	
		if(shootType[_currentPosArray] == "normal")
		{ 	anim.SetBool("isShooting", true);
			for(int i = 0; i < _arrows.Count; i++)
			{
				if(!_arrows[i].activeInHierarchy && _arrows[i].tag == "ArrowNormal")
				{
					_arrows[i].transform.position = transform.position;
					_arrows[i].GetComponent<ArrowMovement>()._angleZ = this.transform.rotation;
					_arrows[i].GetComponent<ArrowMovement>().setSpeed(speed);
					_arrows[i].SetActive(true);
					break;
				}
			}
		}
	}
}
