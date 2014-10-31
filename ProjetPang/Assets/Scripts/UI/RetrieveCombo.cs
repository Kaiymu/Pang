using UnityEngine;
using System.Collections;

public class RetrieveCombo : RetrieveInfosLegacy {

	protected override void GiveInfos(){
		_infoLabel.text = ManagerScore.instance.combo.ToString();
	}
}
