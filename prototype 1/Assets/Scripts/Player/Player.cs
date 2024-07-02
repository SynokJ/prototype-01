using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Joystick Components:")]
    [SerializeField] private GameObject _innerCircle;
    [SerializeField] private GameObject _outerCircle;

    [Header("Movement Components:")]
    [SerializeField] private Rigidbody2D _playerRB;

    [Header("Animation Components:")]
    [SerializeField] private Animator _animator;

    private UserInput _inputs;
    private Joystick _joystick;
    private JoystickDraw _joystickDraw;

    private PlayerMovement _movement;
    private PlayerAnimation _animation;

    private void Start()
    {
        _inputs = new UserInput();
        _joystick = new Joystick();
        _joystickDraw = new JoystickDraw(_innerCircle, _outerCircle, _joystick);

        _inputs.OnTouchBegin += _joystick.SetOrigin;
        _inputs.OnTouchMoving += _joystick.SetDirection;
        _inputs.OnTouchEnded += _joystick.ResetDirection;

        _inputs.OnTouchBegin += _joystickDraw.ShowJoystick;
        _inputs.OnTouchMoving += _joystickDraw.Draw;
        _inputs.OnTouchEnded += _joystickDraw.HideJoystick;

        _movement = new PlayerMovement(_playerRB);
        _animation = new PlayerAnimation(_animator);
    }

    private void OnDestroy()
    {
        _inputs.OnTouchBegin -= _joystick.SetOrigin;
        _inputs.OnTouchMoving -= _joystick.SetDirection;
        _inputs.OnTouchEnded -= _joystick.ResetDirection;

        _inputs.OnTouchBegin -= _joystickDraw.ShowJoystick;
        _inputs.OnTouchMoving -= _joystickDraw.Draw;
        _inputs.OnTouchEnded -= _joystickDraw.HideJoystick;
    }

    private void Update()
    {
        _inputs.DetectMovementInput();
        _movement.MoveByDirection(_joystick.Direction);
        _animation.SetAnimationByDirection(_joystick.Direction);
    }
}
