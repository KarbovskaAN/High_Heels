using UnityEngine;
using Vector3 = UnityEngine.Vector3;

[RequireComponent(typeof(Rigidbody),typeof(BoxCollider))]
public class CharacterController : MonoBehaviour
{
   [SerializeField] private Rigidbody _rigidbody;
   [SerializeField] private FixedJoystick _joystick;

   [SerializeField] private float _moveSpeed;

   private void Start()
   {
      _rigidbody = GetComponent<Rigidbody>();
   }

   private void FixedUpdate()
   {
      _rigidbody.AddForce(Vector3.right * 100f);
      _rigidbody.velocity = new Vector3(0,0,_joystick.Horizontal * -_moveSpeed);
   }

  
}
