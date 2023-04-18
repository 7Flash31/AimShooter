using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageController : MonoBehaviour
{
    public string currentLanguage;

    public static LanguageController Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            currentLanguage = Yandex.GetLang();
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
