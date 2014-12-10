using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ManagerOrb : SingleBehaviour<ManagerOrb> {

	// Gère la pool d'orb
	public float numberOrbs;
	public int ammountPooledObject;
	private string _pooledParentObjectTagName = "PooledOrb";

	private List<GameObject> _listOrb = new List<GameObject>();
	private List<GameObject> _listOrbInGame = new List<GameObject>();

	// Mon tableau d'orb.
	private GameObject _orbContainer;
	private GameObject _orbsRessourcesContainer;

	private int _IDGroupOrb;

	public List<GameObject> listOrb
	{
		get {return _listOrb;} 
		set {if(value != null)
			_listOrb = value;
		}
	}
	
	public List<GameObject> listOrbInGame
	{
		get {return _listOrbInGame;} 
		set {if(value != null)
			_listOrbInGame = value;
		}
	}

	void OnEnable()
	{
		LoadLevelAdditif.Loaded += LevelIsLoaded;
	}

	void OnDisable()
	{
		LoadLevelAdditif.Loaded-= LevelIsLoaded;
	}

	void LevelIsLoaded()
	{
		GameObject[] g = GameObject.FindGameObjectsWithTag("OrbIce");
        GameObject[] gMalus = GameObject.FindGameObjectsWithTag("OrbIce");

        if (g != null)
        {
            foreach (GameObject orb in g)
            {
                listOrbInGame.Add(orb);
            }
        }

        if (gMalus != null)
        {
            foreach (GameObject orb in gMalus)
            {
                listOrbInGame.Add(orb);
            }
        }
	}

	void Start()
	{
		CreatePoolOrb();
	}

	// Create the pull object for the orbs.
	void CreatePoolOrb()
	{	
		_orbContainer = ManagerResources.instance.orbRessourceContainer;
		ManagerPool.instance.CreatePool(_orbContainer, _listOrb, ammountPooledObject, _pooledParentObjectTagName);
	}

	public void CreateSmallerOrb(GameObject currentOrb)
	{
		_IDGroupOrb = currentOrb.GetComponent<GiveUniqueID>().IDGroup;
		
		if(currentOrb.GetComponent<GiveUniqueID>() == null || _IDGroupOrb == 3)
			return;
		else
		{
			for(int i = 0; i < numberOrbs; i++)
			{	
				for(int j = 0; j < _listOrb.Count; j += ammountPooledObject)
				{
					if(_listOrb[j].GetComponent<GiveUniqueID>().IDGroup == _IDGroupOrb)
					{
						int nextIDGroupOrb = (_IDGroupOrb + 1 ) * ammountPooledObject;
						GameObject nextOrbGroup = _listOrb[nextIDGroupOrb];

						if(i == 0)
							RecursifCreateBall(nextOrbGroup, nextIDGroupOrb, currentOrb, false);

						if(i == 1)
							RecursifCreateBall(nextOrbGroup, nextIDGroupOrb, currentOrb, true);
					}
				}
			}
		}
	}
	
	void RecursifCreateBall(GameObject orbToDisplay, int indexOrb, GameObject whereToInstantiate, bool negativeGo)
	{
		if(orbToDisplay.activeInHierarchy)
		{	
			indexOrb++;
			orbToDisplay = _listOrb[indexOrb];
			RecursifCreateBall(orbToDisplay, indexOrb, whereToInstantiate, negativeGo);
		}
		else
		{	
			if(negativeGo)
				orbToDisplay.GetComponent<OrbMovement>().startBouciness = -orbToDisplay.GetComponent<OrbMovement>().startBouciness;

			orbToDisplay.transform.position = whereToInstantiate.transform.position;
			orbToDisplay.transform.rotation = Quaternion.identity;
			orbToDisplay.SetActive(true);
		}
	}
	
	public void AffectOrb(GameObject orbToAffect)
	{
		switch (ManagerElements.instance.currentElement)
		{
			case ManagerElements.Elements.Fire:
				orbToAffect.AddComponent<FireEffect>();
			break;
			case ManagerElements.Elements.Water:
				orbToAffect.AddComponent<WaterEffect>();
			break;
			case ManagerElements.Elements.Earth:
				orbToAffect.AddComponent<EarthEffect>();
			break;
			case ManagerElements.Elements.Wind:
				orbToAffect.AddComponent<WindEffect>();
			break;
		}
	}

}
