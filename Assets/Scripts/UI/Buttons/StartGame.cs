namespace UI.Buttons
{
	public class StartGame : ButtonWithEvent
	{
		public static event ButtonEventHandler Clicked;

		protected override void ClickHandler() => 
			Clicked?.Invoke();
	}
}
