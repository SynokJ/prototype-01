using UnityEngine;

public class Movements : MonoBehaviour
{
    [SerializeField] private int _direction;
    [SerializeField] private float _speed;

    [SerializeField] private GameObject _joystick, _button;

    private bool _pressed = false;

    private bool _isFirstTouch = false;
    private float _currentTime = 0.0f;

    private System.Collections.Generic.Queue<Vector2> _cmds =
        new System.Collections.Generic.Queue<Vector2>();

    private void Update()
    {
        Inputs();
    }

    public void OnRepeatButtonCicked()
    {
        if (_cmds.Count == 0) return;
        Move(_cmds.Dequeue(), true);
    }

    private void Inputs()
    {
        // Первая секунду после нажатия
        if (Input.touchCount > 0)
        {
            SetVisibility(true);

            Touch touch = Input.GetTouch(0);
            Vector2 pos = Camera.main.ScreenToWorldPoint(touch.position);

            if (!_pressed)
            {
                _joystick.transform.position = pos;
                _pressed = true;

                //    if (_isFirstTouch && _currentTime < 1.0f)
                //    {
                //        Debug.Log("Double tap");
                //        _isFirstTouch = false;
                //        _currentTime = 0.0f;
                //    }
                //    else
                //        _isFirstTouch = true;
            }

            _button.transform.position = pos;
        }

        // В конце нажатия
        if (Input.touchCount == 0 && _pressed)
        {
            SetVisibility(false);
            Vector2 joystickPos = _joystick.transform.position;
            Vector2 buttonPos = _button.transform.position;

            if (Vector2.Distance(joystickPos, buttonPos) > 0.02f)
            {
                float verticalDist = Mathf.Abs(buttonPos.x - joystickPos.x);
                float horizontalDist = Mathf.Abs(buttonPos.y - joystickPos.y);
                if (verticalDist > horizontalDist)
                {
                    if ((int)(buttonPos.x / 2) * 10 > (int)(joystickPos.x / 2) * 10)
                        Move(Vector2.right, false);
                    if ((int)(buttonPos.x / 2) * 10 < (int)(joystickPos.x / 2) * 10)
                        Move(Vector2.left, false);
                }
                else
                {
                    if ((int)(buttonPos.y / 2) * 10 > (int)(joystickPos.y / 2) * 10)
                        Move(Vector2.up, false);
                    if ((int)(buttonPos.y / 2) * 10 < (int)(joystickPos.y / 2) * 10)
                        Move(Vector2.down, false);
                }
            }

            _button.transform.position = Vector3.zero;
            _joystick.transform.position = Vector3.zero;
            _pressed = false;

            if (_isFirstTouch)
                _currentTime = 0;
        }

        if (_isFirstTouch)
            _currentTime += Time.deltaTime;
    }

    private void SetVisibility(bool status)
    {
        _button.SetActive(status);
        _joystick.SetActive(status);
    }

    private void Move(Vector2 direction, bool isRepeat)
    {
        transform.position += (Vector3)direction;
        if (!isRepeat) _cmds.Enqueue(direction);
    }
}
