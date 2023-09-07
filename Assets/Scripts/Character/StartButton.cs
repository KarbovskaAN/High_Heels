using UnityEngine;

public class StartButton : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
   
    public void StartGame()
    {
        _characterController.StartMove();
    }
}