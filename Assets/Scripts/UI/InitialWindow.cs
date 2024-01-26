using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using CookingPrototype.Controllers;

namespace CookingPrototype.UI {
	public class InitialWindow : MonoBehaviour {

		[SerializeField] private TMP_Text _taskText;
		[SerializeField] private Button _playButton;

		private void Start() {
			GameplayController.Instance.TotalOrdersServedChanged += ShowInitialWindow;
			gameObject.SetActive(false);
		}

		public void ShowInitialWindow() {
			string wordsTask = "Приготовь и передай $ блюд.";
			string resultWords = wordsTask.Replace("$", GameplayController.Instance.OrdersTarget.ToString());
			_taskText.text = resultWords;
			_playButton.onClick.AddListener(StartGame);
			gameObject.SetActive(true);
			Time.timeScale = 0f;
		}

		private void StartGame() {
			gameObject.SetActive(false);
			Time.timeScale = 1f;
			_playButton.onClick.RemoveListener(StartGame);
			GameplayController.Instance.TotalOrdersServedChanged -= ShowInitialWindow;
		}
	}
}
