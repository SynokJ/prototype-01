public class JoystickDraw
{
    private UnityEngine.GameObject _innerCircle;
    private UnityEngine.GameObject _outerCircle;

    private Joystick _joystick;

    public JoystickDraw(UnityEngine.GameObject inner, UnityEngine.GameObject outer, Joystick joystick)
    {
        _innerCircle = inner;
        _outerCircle = outer;
        _joystick = joystick;

        HideJoystick();
    }

    ~JoystickDraw()
    {
    }

    public void Draw(UnityEngine.Vector2 currentTouchPosition)
    {
        float distance = UnityEngine.Vector2.Distance(currentTouchPosition, _joystick.OriginPos);

        if (distance < 100)
            _innerCircle.transform.position = currentTouchPosition;
        else
        {
            UnityEngine.Vector2 direction = (currentTouchPosition - _joystick.OriginPos).normalized;
            _innerCircle.transform.position = _joystick.OriginPos + 100 * direction;
        }
    }

    public void ShowJoystick(UnityEngine.Vector2 touchPos)
    {
        _innerCircle.transform.position = touchPos;
        _outerCircle.transform.position = touchPos;

        _innerCircle.SetActive(true);
        _outerCircle.SetActive(true);
    }

    public void HideJoystick()
    {
        _innerCircle.SetActive(false);
        _outerCircle.SetActive(false);
    }
}
