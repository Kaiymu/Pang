using UnityEngine;
using System.Collections;

public class ScoreXML : SingleBehaviour<ScoreXML> {

	private SaveScoreXML _memory;

	public SaveScoreXML memory
	{
		get{return _memory;}
		set{_memory = value;}
	}

	void OnEnable()
	{
		ManagerEndGame.OnEndGame += SaveScore;
	}

	void Awake()
	{
		DontDestroyOnLoad (transform.gameObject);
		memory = SaveScoreXML.Load(Application.dataPath + "/Save.xml");

		if(memory == null)
		{
			memory = new SaveScoreXML();

			memory.score[0] = 0;
			memory.levels[0] = 1;

			memory.Save(Application.dataPath + "/Save.xml");
		}
	}

	void SaveScore()
	{
		int arrayXMLUpdateScoreLevels = ManagerLevels.instance.level - 2;
	
		if(memory.score[arrayXMLUpdateScoreLevels] < ManagerScore.instance.score)
			memory.score[arrayXMLUpdateScoreLevels] = ManagerScore.instance.score;

		memory.levels[arrayXMLUpdateScoreLevels] = arrayXMLUpdateScoreLevels + 1;

		memory.Save(Application.dataPath + "/Save.xml");
	}


}
