using UnityEngine;

namespace UI.ShowHide
{
	public abstract class ShowHideUI : MonoBehaviour
	{
		[SerializeField] protected bool HideOnStart;
		
		protected bool OnDisplay;

		protected virtual void Awake()
		{
			if (!HideOnStart)
				OnDisplay = true;
		}

		public abstract void Show();
		public abstract void Hide();
	}
}