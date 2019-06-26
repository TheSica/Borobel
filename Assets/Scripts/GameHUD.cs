using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameHUD : MonoBehaviour
{
	public event Action OnEscapeButtonPressed = delegate { };

	[SerializeField] private TextMeshProUGUI _text;
	[SerializeField] private RawImage _rawImage;

	private void Start()
	{
		Clear();
	}

	public void Setup(string textToShow)
	{
		_text.gameObject.SetActive(true);
		_rawImage.gameObject.SetActive(true);

		_text.text = textToShow;
	}

	public void Clear()
	{
		_text.text = "";
		_text.gameObject.SetActive(false);
		_rawImage.gameObject.SetActive(false);
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			OnEscapeButtonPressed();
		}
	}
}
