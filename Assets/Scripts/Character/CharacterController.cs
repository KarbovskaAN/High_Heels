using System;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

[RequireComponent(typeof(Rigidbody),typeof(BoxCollider))]
public class CharacterController : MonoBehaviour
{
   [SerializeField] private Rigidbody _rigidbody;
   [SerializeField] private FixedJoystick _joystick;

   private float _rightAndLeftMoveSpeed = 10;
   private float _forwardMoveSpeed = 4f;

   private void Start()
   {
      _rigidbody = GetComponent<Rigidbody>();
   }

   private void FixedUpdate()
   {
      _rigidbody.velocity = new Vector3(_forwardMoveSpeed, 0, _joystick.Horizontal * -_rightAndLeftMoveSpeed);
   }

}
