using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBox : MonoBehaviour
{
    [SerializeField]
    string text;
    [SerializeField]
    public float timeBetweenChars = 1;
    string currentText = "";
    int i = 0;
    public TextMeshProUGUI textBox;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(showTextFuntion());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator showTextFuntion()
    {
        for (i = 0; i < text.Length; i++)
        {
            currentText = currentText + text[i].ToString();
            textBox.text = currentText;
            yield return new WaitForSeconds(timeBetweenChars);
        }
        yield return null;
    }
}
