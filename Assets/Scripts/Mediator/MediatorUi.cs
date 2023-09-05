using TMPro;
using UnityEngine;

public class MediatorUi : MonoBehaviour
{
    [SerializeField] private GameObject _textCountDiamond;
    [SerializeField] private GameObject _panelStart;
    [SerializeField] private GameObject _panelLost;
    [SerializeField] private GameObject _panelFinish;
    
    [SerializeField] private CollectDiamond _countDiamond;
    

    private void Update()
    {
        CountingDiamond();
    }
    public void PanelStart()
    {
        _panelStart.SetActive(false) ;
    }

    private void CountingDiamond()
    {
        _textCountDiamond.GetComponentInChildren<TMP_Text>().text = _countDiamond._countDiamond.ToString();
    }

    
}
