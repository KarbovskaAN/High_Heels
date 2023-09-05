using System;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

[RequireComponent(typeof(Rigidbody),typeof(BoxCollider),typeof(Animator))]
public class CharacterController : MonoBehaviour
{
   [SerializeField] private Rigidbody _rigidbody;
   [SerializeField] private FixedJoystick _joystick;
   [SerializeField] private Animator _animator;
   [SerializeField] private MediatorUi _mediator;
   [SerializeField] private CollectShoes _collectShoes;

   private float _rightAndLeftMoveSpeed = 15;
   private float _forwardMoveSpeed = 2f;

   private int _isWalkingHash;
   private int _isCatWalkingHash;

   private void Start()
   {
      _rigidbody = GetComponent<Rigidbody>();
      _isWalkingHash = Animator.StringToHash("IsWalking");
      _isCatWalkingHash = Animator.StringToHash("IsCatWalking");
   }

   private void Update()
   {
      CheckStartMove();
   }

   private void FixedUpdate()
   {
      ControlCharacter();
   }

   private void CheckStartMove()
   {
      bool checkTap = CheckTap();
      if (checkTap)
      {
         MoveCharacter();
      }
   }
   
   private bool CheckTap()
   {
      bool isWalking = _animator.GetBool(_isWalkingHash);
      bool input = Input.GetMouseButtonDown(0);

      if (!isWalking && input)
      {
         _animator.SetBool(_isWalkingHash,true);
         _mediator.PanelStart();
         return true;
      }
      else
      {
         return false;
      }
   }
   
   private void MoveCharacter()
   {
      _rigidbody.velocity = new Vector3(_forwardMoveSpeed, 0, 0);
   }

   private void ControlCharacter()
   {
      _rigidbody.AddForce(new Vector3(0,0,_joystick.Horizontal * -_rightAndLeftMoveSpeed));
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.CompareTag("Respawn"))
      {
         gameObject.transform.position += new Vector3(0, 0.45f, 0);
         _collectShoes.NewMethod();
      }
      if (other.gameObject.CompareTag("Finish"))
      {
         _animator.SetBool(_isWalkingHash,false);
         _animator.SetBool(_isCatWalkingHash,true);
         _rigidbody.velocity = new Vector3(0, 0, 0);
      }
   }
}
