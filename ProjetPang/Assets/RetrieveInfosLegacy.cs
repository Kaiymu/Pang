using UnityEngine;
using System.Collections;

public abstract class RetrieveInfosLegacy : MonoBehaviour {
	
	protected UILabel _infoLabel;
	
	void Start () {
		_infoLabel = this.GetComponent<UILabel>();
	}
	
	void Update () {
		GiveInfos ();
	}
	
	protected abstract void GiveInfos();
}
