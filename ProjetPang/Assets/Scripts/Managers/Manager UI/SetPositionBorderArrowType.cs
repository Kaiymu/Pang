using UnityEngine;
using System.Collections;

public class SetPositionBorderArrowType : MonoBehaviour {
	
	private GameObject[] _UIBorder;

	private PlayerShoot _arrowType;
	private int _posArrayArrow;

	private GiveAllObjectsToManagers _giveAllObjectsToManagers;

	private bool _isInMenu;

	public void OnGlobalEnable()
	{
		//PlayerShoot.isChangingUIBorder += ChangingArrow;
		_giveAllObjectsToManagers = GameObject.FindGameObjectWithTag("GiveAllObjectsToManagers").GetComponent<GiveAllObjectsToManagers>();
		_arrowType = _giveAllObjectsToManagers.player.GetComponent<PlayerShoot>();
		_UIBorder  = this.GetComponent<SortGameObjectsChildrenByName>().sortArrayFromName(_giveAllObjectsToManagers.showCurrentAmmo);

		for(int i = 0; i < _UIBorder.Length; i++)
		{
			_UIBorder[i].gameObject.SetActive(false);
			_UIBorder[0].gameObject.SetActive(true);
		}
	}

	void OnDisable()
	{
		//PlayerShoot.isChangingUIBorder -= ChangingArrow;
	}

	void ChangingArrow () {
		/*
		for(int i = 0; i < _UIBorder.Length; i++)
		{
			_UIBorder[i].gameObject.SetActive(false);
			_UIBorder[_arrowType.getArrowType()].gameObject.SetActive(true);
		}
		*/
	}
}
