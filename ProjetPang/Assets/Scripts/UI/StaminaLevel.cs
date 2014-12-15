using UnityEngine;
using System.Collections;

public class StaminaLevel : MonoBehaviour {

	private UISlider _numberSlider;

	void Start () {
		_numberSlider = GetComponent<UISlider>();
	}
	
	// Update is called once per frame
	void Update () {
		_numberSlider.value = ManagerMenu.instance.stamina;
	}
}
