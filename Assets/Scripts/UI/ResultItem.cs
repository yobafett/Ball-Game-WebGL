using System;
using TMPro;
using UnityEngine;

namespace UI
{
	public class ResultItem : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI PositionText;
		[SerializeField] private TextMeshProUGUI TimeText;

		public void SetPlace(int number) => 
			PositionText.text = $"{number}#";

		public void SetTime(float time) => 
			TimeText.text = TimeSpan.FromSeconds(time).ToString(@"mm\:ss\:ff");
	}
}