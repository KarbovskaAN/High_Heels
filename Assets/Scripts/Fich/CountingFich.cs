using UnityEngine;

public class CountingFich : MonoBehaviour
{
    public int NumbStep;
    
    [SerializeField] private CollectDiamond _countDiamond;
    [SerializeField] private int countFich;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Untagged") )
        {
            countFich = _countDiamond._countDiamond * NumbStep;
            PlayerPrefs.SetInt("CountFich",countFich);
        }

        int result = PlayerPrefs.GetInt("CountFich");
        Debug.Log(result);
    }
}
