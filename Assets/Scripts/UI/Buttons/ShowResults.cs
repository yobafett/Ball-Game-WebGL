namespace UI.Buttons
{
    public class ShowResults : ButtonWithEvent
    {
        public static event ButtonEventHandler Clicked;

        protected override void ClickHandler() => 
            Clicked?.Invoke();
    }
}
