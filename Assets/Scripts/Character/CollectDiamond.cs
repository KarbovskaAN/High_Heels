using UnityEngine;

public class CollectDiamond : MonoBehaviour
{
    public int _countDiamond;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Diamond"))
        {
            _countDiamond += 1;
            Destroy(other.gameObject);
        } 
    }
    
}
