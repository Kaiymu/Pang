using UnityEngine;
using System.Collections;

public class RetrieveCombo : MonoBehaviour {
	
	private UILabel _comboLabel;
	
	void Start () {
		_comboLabel = this.GetComponent<UILabel>();
	}
	
	void Update () {
		GiveCombo ();
	}
	
	void GiveCombo(){
		_comboLabel.text = ManagerScore.instance.combo.ToString();
	}
}
