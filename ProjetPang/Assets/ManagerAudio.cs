using UnityEngine;
using System.Collections;

public class ManagerAudio : MonoBehaviour {

	private static ManagerAudio instance;
	private AudioSource[] _audioSources;
	private bool _playMainSound = true;
	private bool _playBattleSound = false;

	private bool _blockMainSound = false;
	private bool _blockBattleTheme = true;

	void Awake(){
		if(instance)
			Destroy (gameObject);
		else
		{
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	void Start()
	{
		_audioSources = GetComponents<AudioSource>();
	}

	void Update()
	{
		WichSoundToPlay();
	}	

	void OnLevelWasLoaded(int levelLoaded) {
		if(levelLoaded == 2) {
			_playBattleSound = true;
			_playMainSound = false;
		}
		else {
			_playBattleSound = false;
			_playMainSound = true;
		}
	}

	void WichSoundToPlay()
	{
		if(_playMainSound && !_blockMainSound)
		{
			_audioSources[1].Stop();
			_audioSources[0].Play();

			_blockMainSound = true;
			_blockBattleTheme = false;
		}

		if(_playBattleSound && !_blockBattleTheme)
		{
			_audioSources[1].Play();
			_audioSources[0].Stop();

			_blockMainSound = false;
			_blockBattleTheme = true;
		}
	}
}
