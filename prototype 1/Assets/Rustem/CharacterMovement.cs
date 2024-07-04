using Unity.VisualScripting;

public class CharacterMovement
{
    private UnityEngine.Rigidbody2D _rb;
    private float _speed;

    private UnityEngine.Vector2 _up = UnityEngine.Vector2.up;
    private UnityEngine.Vector2 _down = UnityEngine.Vector2.down;
    private UnityEngine.Vector2 _left = UnityEngine.Vector2.left;
    private UnityEngine.Vector2 _right = UnityEngine.Vector2.right;

    public CharacterMovement(UnityEngine.Rigidbody2D rb, float speed)
    {
        _rb = rb;
        _speed = speed;
    }

    public void Inputs()
    {
        if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.UpArrow))
            _rb.AddForce(_up * _speed * UnityEngine.Time.deltaTime);
        if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.DownArrow))
            _rb.AddForce(_down * _speed * UnityEngine.Time.deltaTime);
        if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.LeftArrow))
            _rb.AddForce(_left * _speed * UnityEngine.Time.deltaTime);
        if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.RightArrow))
            _rb.AddForce(_right * _speed * UnityEngine.Time.deltaTime);
    }
}
