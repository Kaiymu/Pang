using UnityEngine;
using System.Collections;
using System.IO;
using System.Xml;

public class SaveScoreXML : SingleBehaviour<SaveScoreXML> {

	private XMLScore _memory;
	private  WWW www;
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
		memory = XMLScore.Load(LoadXMLFile());

		Debug.Log (memory);
		if(memory == null)
		{
			memory = new XMLScore();
			memory.levels[0] = 1;
			memory.Save(Application.dataPath + "/Save.xml");
		}
	}

	string LoadXMLFile()
	{
		string dbPath = "";
		string realPath = "";
		
		if (Application.platform == RuntimePlatform.Android)
		{
			// Android
			string oriPath = System.IO.Path.Combine(Application.streamingAssetsPath, "Save.xml");
			
			// Android only use WWW to read file
			WWW reader = new WWW(oriPath);
			while ( ! reader.isDone) {}
			
			realPath = Application.persistentDataPath + "/db";
			System.IO.File.WriteAllBytes(realPath, reader.bytes);
			
			dbPath = realPath;
		}
		else
		{
			// iOS
			dbPath = System.IO.Path.Combine(Application.streamingAssetsPath, "Save.xml");
		}

		return dbPath;
	}

	void SaveScore()
	{
		int arrayXMLUpdateScoreLevels = ManagerLevels.instance.level - 3;

		if(memory.score[arrayXMLUpdateScoreLevels] < ManagerScore.instance.score)
			memory.score[arrayXMLUpdateScoreLevels] = ManagerScore.instance.score;

		memory.levels[arrayXMLUpdateScoreLevels] = arrayXMLUpdateScoreLevels + 1;

		memory.Save(Application.dataPath + "/Save.xml");
	}



}
