public class Joystick
{
    public UnityEngine.Vector2 Direction { get => _joystickDirection; }
    public UnityEngine.Vector2 OriginPos { get => _originPos; }

    private UnityEngine.Vector2 _originPos;
    private UnityEngine.Vector2 _joystickDirection;

    public Joystick()
    {
       
    }

    ~Joystick()
    {
    }

    public void SetOrigin(UnityEngine.Vector2 originPos)
        => _originPos = originPos;

    public void SetDirection(UnityEngine.Vector2 direction)
        => _joystickDirection = (direction - _originPos).normalized;

    public void ResetDirection()
        => _joystickDirection = UnityEngine.Vector2.zero;
}
