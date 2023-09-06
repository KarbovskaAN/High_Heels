using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public void PanelFinish()
    {
        _panelFinish.SetActive(true) ;
    }

    public void PanelLost()
    {
        _panelLost.SetActive(true);
    }
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    } 
    public void LastScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    private void CountingDiamond()
    {
        _textCountDiamond.GetComponentInChildren<TMP_Text>().text = _countDiamond._countDiamond.ToString();
    }
}
