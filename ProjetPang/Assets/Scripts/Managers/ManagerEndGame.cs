using UnityEngine;
using System.Collections;

public class ManagerEndGame : SingleBehaviour<ManagerEndGame> {

	private bool _isLevelLoaded;
	private ManagerArray _managerArray;
	public delegate void EndGame();
	public static event EndGame OnEndGame;

	void OnEnable()
	{
		LoadLevelAdditif.Loaded += Loaded;
	}

	void Loaded()
	{
		_isLevelLoaded = true;
		_managerArray = ManagerArray.instance;
	}

	void Update()
	{
		if(_isLevelLoaded)
		{
			if(_managerArray.countActiveInHiearchy(_managerArray.listOrb) == 0 && _managerArray.countActiveInHiearchy(_managerArray.listOrbInGame) == 0)
				OnEndGame();
		}
	}
}
