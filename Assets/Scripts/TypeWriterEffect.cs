using System.Collections;
using TMPro;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public TMP_Text welcomePhrase;

    string frase = "Carlitos:\n\nFeeling rich?\n\nBecause our tools are not CHEAP!";

    // Start is called before the first frame update
    void OnEnable()
    {
        Debug.Log("GameObject enabled and OnEnable called");
        StartCoroutine(Reloj());
    }

    IEnumerator Reloj()
    {
        welcomePhrase.text = ""; // Ensure the text starts empty
        foreach (char caracter in frase)
        {
            welcomePhrase.text += caracter;
            yield return new WaitForSeconds(0.06f);
        }
    }
}
