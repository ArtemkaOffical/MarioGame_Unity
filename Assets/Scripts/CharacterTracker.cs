using UnityEngine;

public class CharacterTracker : MonoBehaviour
{

    [SerializeField] private Character _character;
    [SerializeField] private Camera _camera;

    private float _offset = 1;

    private void Start()
    {
        _character = GetComponent<Character>();
        _camera = Camera.main;
    }

    void Update()
    {
        var currentPostion = _camera.transform.position;
        currentPostion.x = _character.transform.position.x + _offset;
        _camera.transform.position = currentPostion;
    }
}
