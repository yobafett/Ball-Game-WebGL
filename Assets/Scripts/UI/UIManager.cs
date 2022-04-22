using GameLogic;
using Input;
using UI.Buttons;
using UI.ShowHide;
using UnityEngine;

namespace UI
{
	public class UIManager : MonoBehaviour
	{
		[SerializeField] private ShowHideUI StartButton;
		[SerializeField] private ShowHideUI ResultsButton;
		[SerializeField] private ShowHideUI ResultsPanel;
		[SerializeField] private ShowHideUI TimerPanel;

		private void OnEnable()
		{
			StartGame.Clicked += ShowGameUI;
			InputLogger.EscClicked += ShowMainMenu;
			ShowResults.Clicked += ShowResultsPanel;
			BackToMainMenu.Clicked += ShowMainMenu;
			Track.FallTriggered += ShowResultsPanel;
			Track.FinishTriggered += ShowResultsPanel;
		}

		private void OnDisable()
		{
			StartGame.Clicked -= ShowGameUI;
			InputLogger.EscClicked -= ShowMainMenu;
			ShowResults.Clicked -= ShowResultsPanel;
			BackToMainMenu.Clicked -= ShowMainMenu;
			Track.FallTriggered -= ShowResultsPanel;
			Track.FinishTriggered -= ShowResultsPanel;
		}

		private void ShowMainMenu()
		{
			TimerPanel.Hide();
			ResultsPanel.Hide();
		
			StartButton.Show();
			ResultsButton.Show();
		}

		private void HideMainMenu()
		{
			StartButton.Hide();
			ResultsButton.Hide();
		}

		private void ShowGameUI()
		{
			HideMainMenu();
		
			TimerPanel.Show();
		}

		private void ShowResultsPanel()
		{
			HideMainMenu();
			TimerPanel.Hide();
		
			ResultsPanel.Show();
		}
	}
}