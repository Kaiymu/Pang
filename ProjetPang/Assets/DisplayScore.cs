using UnityEngine;
using System.Collections;

public class DisplayScore : RetrieveInfosLegacy {

	private int _scoreLevelToDisplay;

	protected override void Start() {
		base.Start();
		_scoreLevelToDisplay = int.Parse(transform.parent.name) -1 ;
	}
	
	protected override void GiveInfos(){
		_infoLabel.text = SaveScoreXML.instance.memory.score[_scoreLevelToDisplay].ToString();
	}
}
