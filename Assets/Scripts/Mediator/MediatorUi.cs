using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MediatorUi : MonoBehaviour
{
    [SerializeField] private GameObject _textCountDiamond;
    [SerializeField] private GameObject _panelStart;
    [SerializeField] private GameObject _panelLost;
    [SerializeField] private GameObject _panelFinish;
    [SerializeField] private List<GameObject> _board;
    
    [SerializeField] private CollectDiamond _countDiamond;
    [SerializeField] private TMP_Text _finishCountDiamond;
    

    private void Update()
    {
        CountingDiamond();
    }
    public void PanelOff()
    {
        _panelStart.SetActive(false) ;
    }
    public void PanelFinish()
    {
        _panelFinish.SetActive(true) ;
        _board[0].SetActive(false);
        _finishCountDiamond.text = PlayerPrefs.GetInt("CountFich").ToString();
    }
    public void PanelLost()
    {
        _panelLost.SetActive(true);
        _board[0].SetActive(false);
        _board[1].SetActive(false);
    } 
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    } 
    public void NextScene()
    {
        byte currentScene;
        currentScene = (byte) SceneManager.GetActiveScene().buildIndex;
        
        if (currentScene == 2)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
    private void CountingDiamond()
    {
        _textCountDiamond.GetComponentInChildren<TMP_Text>().text = _countDiamond._countDiamond.ToString();
    }
}
