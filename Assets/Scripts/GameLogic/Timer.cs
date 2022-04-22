using System;
using System.Collections;
using Input;
using TMPro;
using UI.Buttons;
using UnityEngine;

namespace GameLogic
{
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class Timer : MonoBehaviour
	{
		private TextMeshProUGUI _timerText;
		private Coroutine _timerCoroutine;
		private static float _secondsCount;
	
		public static string GetTimeString() =>
			TimeSpan.FromSeconds(GetTime()).ToString(@"mm\:ss\:ff");
		
		public static float GetTime() =>
			_secondsCount;
		
		private void Awake()
		{
			_timerText = GetComponent<TextMeshProUGUI>();
		}

		private void OnEnable()
		{
			StartGame.Clicked += StartTimer;
			InputLogger.EscClicked += StopTimer;
			Track.FallTriggered += StopTimer;
			Track.FinishTriggered += StopTimer;
		}

		private void OnDisable()
		{
			StartGame.Clicked -= StartTimer;
			InputLogger.EscClicked -= StopTimer;
			Track.FallTriggered -= StopTimer;
			Track.FinishTriggered -= StopTimer;
		}

		private void StartTimer()
		{
			ResetTimer();
			_timerCoroutine = StartCoroutine(UpdateTimer());
		}

		private void StopTimer()
		{
			if(_timerCoroutine != null)
				StopCoroutine(_timerCoroutine);

			_timerCoroutine = null;
		}

		private void ResetTimer() => 
			_secondsCount = 0;

		private IEnumerator UpdateTimer()
		{
			while (true)
			{
				_timerText.text = GetTimeString();
				_secondsCount += 0.01f;
				
				yield return new WaitForSeconds(0.01f);
			}
		}
	}
}
