using System.Linq;
using UnityEngine;

[RequireComponent (typeof(CharacterTracker))]
public class CharacterObserver : Character
{

    private MonoBehaviour _baseLogic;
    private KeyCode _keyJump;

    private void Start()
    {
        _baseLogic = GetComponents<MonoBehaviour>().Count() == 3 ? GetComponents<MonoBehaviour>().Last() : null;
        if (_baseLogic == null) return;

        _keyJump = (KeyCode)_baseLogic.GetType()
            .GetField("KeyJump", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
            .GetValue(_baseLogic);
    }

    public override void MoveHandler()
    {
        if (_baseLogic == null) return;
        _baseLogic.GetType().GetMethod("Update").Invoke(_baseLogic,null);

        Vector2 currentVelocity = Rigidbody2D.velocity;
        currentVelocity.x = Mathf.Clamp(Rigidbody2D.velocity.x, -Speed, Speed);
        Rigidbody2D.velocity = currentVelocity;

    }

    public override void FlipHandler(float moveAxis)
    {
        base.FlipHandler(Rigidbody2D.velocity.x);
    }

    public override void Jump(KeyCode keyCode)
    {
        base.Jump(_keyJump);
    }
}
