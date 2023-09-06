using System;
using System.Collections.Generic;
using Unity.VisualScripting;
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
   [SerializeField] private List<GameObject> _step;
   [SerializeField] private RagdollController _ragdollController;

   private float _rightAndLeftMoveSpeed = 15;
   private float _forwardMoveSpeed = 2f;

   private int _isWalkingHash;
   private int _isDancingHash;
   private int _isCatWalkingHash;

   private void Start()
   {
      _rigidbody = GetComponent<Rigidbody>();
      _isWalkingHash = Animator.StringToHash("IsWalking");
      _isDancingHash = Animator.StringToHash("IsDancing");
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
         PlayerPrefs.DeleteAll();
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
      if (other.gameObject.CompareTag("Finish"))
      {
         _animator.SetBool(_isWalkingHash,false);
         _animator.SetBool(_isCatWalkingHash,true);
         _rigidbody.velocity = new Vector3(0, 0, 0);
         _joystick.gameObject.SetActive(false);
      }
      if (other.gameObject.CompareTag("Step"))
      {
         if (_collectShoes._colliderShoesList.Count == 0)
         {
            _ragdollController.Makephysical();
            _mediator.PanelLost();
         }
         else
         {
            _collectShoes.NewMethod();
         }
      }
      if (other.gameObject.CompareTag("Untagged"))
      {
         if (_collectShoes._colliderShoesList.Count >=1 )
         {
               _collectShoes.NewMethod();
            
         }
         else if (_collectShoes._colliderShoesList.Count==0 )
         {
            _rigidbody.velocity = new Vector3(0, 0, 0);
            _joystick.gameObject.SetActive(false);
            _animator.SetBool(_isWalkingHash, false);
            _animator.SetBool(_isDancingHash, true);
            _mediator.PanelFinish(); 
         }
      }
     
        
   }
   
}
