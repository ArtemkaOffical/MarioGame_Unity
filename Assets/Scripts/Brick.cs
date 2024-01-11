using System.Collections;
using UnityEngine;

public class Brick : MonoBehaviour
{

    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private BoxCollider2D _collider;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.GetComponent<Character>() && collision.contacts[0].normal.y > 0.5f)
            StartCoroutine(Break());
    }

    private IEnumerator Break()
    {
        _particleSystem = Instantiate(_particleSystem, gameObject.transform, false);
        _particleSystem.Play();
        _spriteRenderer.enabled = false;
        _collider.enabled = false;
        yield return new WaitForSeconds(_particleSystem.main.startLifetime.constant);
        Destroy(gameObject);
    }
}
