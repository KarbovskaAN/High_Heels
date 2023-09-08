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
   [SerializeField] private GameObject _leftLeg;
   [SerializeField] private GameObject _leftKnee;
   [SerializeField] private GameObject _rightLeg;
   [SerializeField] private GameObject _rightKnee;

   private float _rightAndLeftMoveSpeed = 2;
   private float _forwardMoveSpeed = 2f;
   

   private int _isWalkingHash;
   private int _isDancingHash;
   private int _isCatWalkingHash;
   private int _isWalkingRopeHash;

   public bool _isActive;

   private void Start()
   {
      _isWalkingHash = Animator.StringToHash("IsWalking");
      _isDancingHash = Animator.StringToHash("IsDancing");
      _isCatWalkingHash = Animator.StringToHash("IsCatWalking");
      _isWalkingRopeHash = Animator.StringToHash("IsWalkingRope");
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
      _rigidbody.velocity = new Vector3(_forwardMoveSpeed, _rigidbody.velocity.y, _joystick.Horizontal * -_rightAndLeftMoveSpeed);
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
         _mediator.PanelFinish();
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
      if (other.gameObject.CompareTag("StartObstacle"))
      {
         _animator.enabled = false;
         _leftLeg.gameObject.transform.localEulerAngles = new Vector3(0,0,90);
         _leftKnee.gameObject.transform.localEulerAngles = new Vector3(0,0,0);
         _rightLeg.gameObject.transform.localEulerAngles = new Vector3(0,0,-90);
         _rightKnee.gameObject.transform.localEulerAngles = new Vector3(0,0,0);
      } 
      if (other.gameObject.CompareTag("Rope"))
      {
         _animator.SetBool(_isWalkingHash, false);
         _animator.SetBool(_isWalkingRopeHash, true);
      }

      if (other.gameObject.CompareTag("RopeFinish"))
      {
         
         _animator.SetBool(_isWalkingRopeHash, false);
         _animator.SetBool(_isWalkingHash, true);
      }

   }
}