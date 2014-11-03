using UnityEngine;
using System.Collections;

public class ManagerEndGame : SingleBehaviour<ManagerEndGame> {

	private bool _isLevelLoaded;
	private ManagerOrb _managerOrb;
	private ManagerPool _managerPool;
	public delegate void EndGame();
	public static event EndGame OnEndGame;

	void OnEnable()
	{
		LoadLevelAdditif.Loaded += Loaded;
	}

	void Loaded()
	{
		_isLevelLoaded = true;
		_managerOrb = ManagerOrb.instance;
		_managerPool = ManagerPool.instance;
	}

	void Update()
	{
		if(_isLevelLoaded)
		{
			if(_managerPool.countActiveInHiearchy(_managerOrb.listOrb) == 0 && _managerPool.countActiveInHiearchy(_managerOrb.listOrbInGame) == 0)
				OnEndGame();
		}
	}
}
