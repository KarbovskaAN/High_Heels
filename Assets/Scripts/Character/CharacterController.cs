using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class CharacterController : MonoBehaviour
{
   [SerializeField] private Rigidbody _rigidbody;
   [SerializeField] private VariableJoystick _joystick;
   [SerializeField] private Animator _animator;
   [SerializeField] private MediatorUi _mediator;
   [SerializeField] private CollectShoes _collectShoes;
   [SerializeField] private RagdollController _ragdollController;

   private float _rightAndLeftMoveSpeed = 2;
   private float _forwardMoveSpeed = 2f;
   

   private int _isWalkingHash;
   private int _isDancingHash;
   private int _isCatWalkingHash;

   public bool _isActive;

   private void Start()
   {
      _rigidbody = GetComponent<Rigidbody>();
      _isWalkingHash = Animator.StringToHash("IsWalking");
      _isDancingHash = Animator.StringToHash("IsDancing");
      _isCatWalkingHash = Animator.StringToHash("IsCatWalking");
   }

   private void FixedUpdate()
   {
      if (_isActive)
      {
         ControlCharacter();  
      }
   }

   public void StartMove()
   {
      _animator.SetBool(_isWalkingHash,true);
      _mediator.PanelOff();
      _isActive = true;
      _joystick.enabled = true;
      
      PlayerPrefs.DeleteAll();
   }
   
   private void ControlCharacter()
   {
      _rigidbody.velocity = new Vector3(_forwardMoveSpeed, 0, _joystick.Horizontal * -_rightAndLeftMoveSpeed);
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.CompareTag("Finish"))
      {
         _animator.SetBool(_isWalkingHash,false);
         _animator.SetBool(_isCatWalkingHash,true);
         _rigidbody.velocity = new Vector3(0, 0, 0);
         _joystick.gameObject.SetActive(false);
         _isActive = false;
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
      if (other.gameObject.CompareTag("Steps"))
      {
         if (_collectShoes._colliderShoesList.Count >=1 )
         {
               _collectShoes.NewMethod();
            
         }
         else if (_collectShoes._colliderShoesList.Count==0 )
         {
            _rigidbody.velocity = new Vector3(0, 0, 0);
            _joystick.gameObject.SetActive(false);
            _isActive = false;
            _animator.SetBool(_isWalkingHash, false);
            _animator.SetBool(_isDancingHash, true);
            _mediator.PanelFinish(); 
         }
      }
   }
}