using UnityEngine;

public class GameManager : Singleton<GameManager>
{
	[SerializeField]
	private ModelViewController _modelViewController;
	[SerializeField]
	private GameHUD _gameHUD;

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
