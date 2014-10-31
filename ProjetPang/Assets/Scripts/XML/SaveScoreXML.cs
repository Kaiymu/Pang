using UnityEngine;
using System.Collections;

public class SaveScoreXML : SingleBehaviour<SaveScoreXML> {

	private XMLScore _memory;

	public XMLScore memory
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
		memory = XMLScore.Load(Application.dataPath + "/Save.xml");

		if(memory == null)
		{
			memory = new XMLScore();
		

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
