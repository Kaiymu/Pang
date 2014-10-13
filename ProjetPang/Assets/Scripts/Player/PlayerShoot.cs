using UnityEngine;
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
	private Animator anim;
	private float timeShoot = 0f;
	private int _numberArrowOnGame;
	private  List<GameObject> _arrows = new List<GameObject>();


	void Awake()
	{	
		anim = GetComponent<Animator>();
		_numberArrowOnGame = 0;
	}

	public int numberArrowOnGame
	{
		get{ return _numberArrowOnGame;}
		set{if(value != null)
			_numberArrowOnGame = value;}
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
		{ 	
			anim.SetBool("isShooting", true);
			for(int i = 0; i < _arrows.Count; i++)
			{
				if(!_arrows[i].activeInHierarchy && _arrows[i].tag == "ArrowNormal")
				{
					_arrows[i].transform.position = transform.position;
					_arrows[i].GetComponent<ArrowMovement>().speed = speed;
					_arrows[i].SetActive(true);
					break;
				}
			}
		}
	}
}
