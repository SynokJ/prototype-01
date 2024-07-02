public class UserInput
{

    public event System.Action<UnityEngine.Vector2> OnTouchBegin = default;
    public event System.Action<UnityEngine.Vector2> OnTouchMoving = default;
    public event System.Action OnTouchEnded = default;

    public UserInput()
    {
    }

    ~UserInput()
    {
    }

    public void DetectMovementInput()
    {
        if (UnityEngine.Input.touchCount > 0)
        {
            UnityEngine.Touch firstTouch = UnityEngine.Input.GetTouch(0);

            switch (firstTouch.phase)
            {
                case UnityEngine.TouchPhase.Began:
                    OnTouchBegin?.Invoke(firstTouch.position); break;
                case UnityEngine.TouchPhase.Moved:
                    OnTouchMoving?.Invoke(firstTouch.position); break;
                case UnityEngine.TouchPhase.Ended:
                    OnTouchEnded?.Invoke(); break;
            }
        }
    }
}
