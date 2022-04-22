namespace UI.Buttons
{
    public class BackToMainMenu : ButtonWithEvent
    {
        public static event ButtonEventHandler Clicked;

        protected override void ClickHandler() => 
            Clicked?.Invoke();
    }
}
