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
    [SerializeField]
    float charOffset;
    [SerializeField]
    float spaceLength;
    [SerializeField]
    GameObject charachter;
    [SerializeField]
    GameObject charachterHolder;
    [SerializeField]
    GameObject startPos;
    int i = 0;
    TextMeshProUGUI textBox;
    GameObject previousChar;
    GameObject currentChar;
    Transform spawnpoint;
    bool wobblyMode = false;
    // Start is called before the first frame update
    IEnumerator showTextFuntion()
    {
        for (i = 0; i < text.Length; i++)
        {
            if (text[i] == '*')
            {
                wobblyMode = !wobblyMode;
            }
            else
            {
                if (previousChar != null)
                    spawnpoint.position = new Vector3(previousChar.transform.position.x + (previousChar.GetComponentInChildren<TextMeshProUGUI>().preferredWidth) + charOffset, startPos.transform.position.y, startPos.transform.position.z);
                else
                    spawnpoint = startPos.transform;
                currentChar = Instantiate(charachter, spawnpoint);
                currentChar.gameObject.transform.SetParent(charachterHolder.transform, true);
                textBox = currentChar.GetComponentInChildren<TextMeshProUGUI>();
                RectTransform textBoxTransform = textBox.GetComponent<RectTransform>();
                if (text[i] != ' ')
                {
                    textBox.text = text[i].ToString();
                    textBoxTransform.sizeDelta = new Vector2(textBox.preferredWidth, textBoxTransform.sizeDelta.y);
                }
                else
                {
                    textBox.text = "";
                    textBoxTransform.sizeDelta = new Vector2(spaceLength, textBoxTransform.sizeDelta.y);
                }
                if (wobblyMode)
                {
                    currentChar.GetComponent<CharScript>().enabled = true;
                }
                previousChar = currentChar;
            }
            yield return new WaitForSeconds(timeBetweenChars);
        }
        yield return null;
    }
    void Start()
    {
        StartCoroutine(showTextFuntion());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  
}
