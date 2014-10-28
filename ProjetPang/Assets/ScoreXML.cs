using UnityEngine;
using System.Collections;

public class ScoreXML : MonoBehaviour {

	private SaveScoreXML memory;

	void Start()
	{
		memory = SaveScoreXML.Load(Application.dataPath + "/Save.xml");
	

		if(memory == null)
		{
			memory = new SaveScoreXML();
			memory.score[0] = 200;
			memory.score[1] = 400;
			memory.score[2] = 700;

			memory.levels[0] = 1;
			memory.levels[1] = 2;
			memory.levels[2] = 3;

			memory.Save(Application.dataPath + "/Save.xml");
		}
	}
}
