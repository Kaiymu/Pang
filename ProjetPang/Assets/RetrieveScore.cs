using UnityEngine;
using System.Collections;

public class RetrieveScore : MonoBehaviour {

	private UILabel _scoreLabel;

	void Start () {
		_scoreLabel = this.GetComponent<UILabel>();
	}

	void Update () {
		GiveScore ();
	}

	void GiveScore(){
		_scoreLabel.text = ManagerScore.instance.score.ToString();
	}
}
