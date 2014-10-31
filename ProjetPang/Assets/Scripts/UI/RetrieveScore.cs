using UnityEngine;
using System.Collections;

public class RetrieveScore : RetrieveInfosLegacy {

	protected override void GiveInfos(){
		_infoLabel.text = ManagerScore.instance.score.ToString();
	}
}
