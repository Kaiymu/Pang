using UnityEngine;
using System.Collections;

public class ScoreXML : SingleBehaviour<ScoreXML> {

	private SaveScoreXML _memory;

	public SaveScoreXML memory
	{
		get{return _memory;}
		set{_memory = value;}
	}

	void Awake()
	{
		DontDestroyOnLoad (transform.gameObject);
	}

	void Start()
	{
		memory = SaveScoreXML.Load(Application.dataPath + "/Save.xml");

		if(memory == null)
		{
			memory = new SaveScoreXML();

			memory.score[0] = 200;
			memory.levels[0] = 1;

			memory.Save(Application.dataPath + "/Save.xml");
		}
	}
}
