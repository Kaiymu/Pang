using UnityEngine;

public class SingleBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T instance_;
	public static T instance
	{
		get
		{
			if (instance_ == null)
				instance_ = GameObject.FindObjectOfType(typeof(T)) as T;
			if (instance_ == null)
			{
				GameObject o = new GameObject("_SingleBehaviour_<" + typeof(T).ToString() + ">");
				instance_ = o.AddComponent<T>();
			}
			return instance_;
		}
	}
} 