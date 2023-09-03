using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MediatorUi : MonoBehaviour
{
    [SerializeField] private GameObject _textCountDiamond;
    [SerializeField] private CollectDiamond _countDiamond;

    private void Update()
    {
        _textCountDiamond.GetComponentInChildren<TMP_Text>().text = _countDiamond._countDiamond.ToString();
    }
}
