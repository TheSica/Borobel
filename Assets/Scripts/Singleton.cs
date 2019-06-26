using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Component
{
	protected static T _instance;

	public static bool HasInstance
	{
		get { return _instance != null; }
	}

	public static T Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = FindObjectOfType<T>();

				if (_instance == null)
				{
					var container = new GameObject(typeof(T).Name + "_Singleton");
					_instance = container.AddComponent<T>();
				}
			}

			return _instance;
		}
	}

	protected void Awake()
	{
		if (_instance == null)
		{
			_instance = this as T;

		}
		else
		{
			DestroyImmediate(this);
		}
	}
}
