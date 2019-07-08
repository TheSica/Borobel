﻿using UnityEngine;

public class GameManager : Singleton<GameManager>
{
	[SerializeField] private PlayerController _player;
	[SerializeField] private ModelViewController _modelViewController;
	[SerializeField] private GameHUD _gameHUD;
	[SerializeField] private QuestManager _questManager;

	public Transform PlayerTransform => _player.transform;

	private void Start()
	{
		_gameHUD.OnEscapeButtonPressed += OnEscapeButtonPressed;
	}

	public void Show3DObject(GameObject objectToView, Vector3 eulerRotationOffset, string textToDisplay)
	{
		Time.timeScale = 0f;

		_modelViewController.Setup(objectToView, eulerRotationOffset);
		_gameHUD.Setup(textToDisplay);
	}

	public void FinishGame()
	{
		Debug.Log($"GameFinished");
	}

	private void OnEscapeButtonPressed()
	{
		Time.timeScale = 1f;
		HideHUD();
	}

	private void HideHUD()
	{
		_modelViewController.Clear();
		_gameHUD.Clear();
	}
}
