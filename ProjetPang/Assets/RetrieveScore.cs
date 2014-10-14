using UnityEngine;
using System.Collections;

public class RetrieveScore : MonoBehaviour {

	private UILabel _scoreLabel;
	// Use this for initialization
	void Start () {
		_scoreLabel = this.GetComponent<UILabel>();
	}
	
	// Update is called once per frame
	void Update () {
		GiveScore ();
	}

	void GiveScore(){
		_scoreLabel.text = ManagerScore.instance.score.ToString();
	}
}
