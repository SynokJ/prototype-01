public class UserInput
{

    public event System.Action<UnityEngine.Vector2> OnTouchBegin = default;
    public event System.Action<UnityEngine.Vector2> OnTouchMoving = default;
    public event System.Action OnTouchEnded = default;

    private bool _isCorrectTouch = true;

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
                    _isCorrectTouch = !IsTouchingUI(firstTouch);
                    if (_isCorrectTouch)
                        OnTouchBegin?.Invoke(firstTouch.position);
                    break;
                case UnityEngine.TouchPhase.Moved:
                    if (_isCorrectTouch)
                        OnTouchMoving?.Invoke(firstTouch.position);
                    break;
                case UnityEngine.TouchPhase.Ended:
                    OnTouchEnded?.Invoke();
                    break;
            }
        }
    }

    private bool IsTouchingUI(UnityEngine.Touch touch)
        => UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(touch.fingerId);
}
