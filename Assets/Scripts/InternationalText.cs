using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InternationalText : MonoBehaviour
{
    [SerializeField] private string ru;
    [SerializeField] private string en;

    private void Start()
    {
        if(LanguageController.Instance.currentLanguage == "ru")
        {
            GetComponent<TMP_Text>().text = ru;
        }
        if(LanguageController.Instance.currentLanguage == "en")
        {
            GetComponent<TMP_Text>().text = en;
        }
    }
}
