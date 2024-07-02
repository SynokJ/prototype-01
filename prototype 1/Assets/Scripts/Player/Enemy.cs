using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private ParticleSystem _particles;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Collider2D _collider;

    private void Start()
    {
        _particles = Instantiate(_particles, transform);
    }

    public void TakeDamage()
    {
        StartCoroutine(PlayDieEffect());
    }

    private System.Collections.IEnumerator PlayDieEffect()
    {
        _particles.Play();
        _renderer.enabled = false;
        _collider.enabled = false;
        yield return new WaitForSeconds(1.0f);

        _particles.Stop();
        _renderer.enabled = true;
        _collider.enabled = true;
    }
}
