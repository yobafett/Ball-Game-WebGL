using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UI;
using UnityEngine;

namespace GameLogic
{
	public class Results : MonoBehaviour
	{
		[SerializeField] private ResultItem[] ListItems;

		private const string RESULTS_KEY = "Results";
		private const float TIME_PLACE_HOLDER = 0f;
		
		private readonly List<float> _results = new List<float>();
		
		private void Start()
		{
			LoadFromPrefs();
			UpdateResultsList();
		}

		private void OnEnable()
		{
			Track.FinishTriggered += SaveTime;
		}

		private void OnDisable()
		{
			Track.FinishTriggered -= SaveTime;
		}

		private void OnDestroy()
		{
			SaveToPrefs();
		}

		private void SaveTime()
		{
			_results.Add(Timer.GetTime());
			UpdateResultsList();
		}
		
		private void UpdateResultsList()
		{
			_results.Sort();
			for (int i = 0; i < ListItems.Length; i++)
			{
				ListItems[i].SetPlace(i + 1);
				ListItems[i].SetTime(i >= _results.Count ? TIME_PLACE_HOLDER : _results[i]);
			}
		}

		private void SaveToPrefs()
		{
			PlayerPrefs.SetString(RESULTS_KEY,JsonConvert.SerializeObject(_results));
			PlayerPrefs.Save();
		}

		private void LoadFromPrefs()
		{
			string results = PlayerPrefs.GetString(RESULTS_KEY);
			if (results != null)
			{
				_results.Clear();
				List<float> savedResults = JsonConvert.DeserializeObject<List<float>>(results);
				if(savedResults != null && savedResults.Count > 0)
					_results.AddRange(savedResults);
			}
		}
	}
}