using GameLogic;
using TMPro;
using UI.Buttons;
using UnityEngine;

namespace UI
{
	public class ResultHeader : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI HeaderText;
		[SerializeField] private string WinText;
		[SerializeField] private string LooseText;
		[SerializeField] private string NeutralText;

		private void OnEnable()
		{
			Track.FallTriggered += SetLooseText;
			Track.FinishTriggered += SetWinText;
			ShowResults.Clicked += SetNeutralText;
		}

		private void OnDisable()
		{
			Track.FallTriggered -= SetLooseText;
			Track.FinishTriggered -= SetWinText;
			ShowResults.Clicked -= SetNeutralText;		
		}

		private void SetWinText() => 
			HeaderText.text = $"{WinText} {Timer.GetTimeString()}";

		private void SetLooseText() => 
			HeaderText.text = LooseText;

		private void SetNeutralText() =>
			HeaderText.text = NeutralText;
	}
}
