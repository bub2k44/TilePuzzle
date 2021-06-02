using UnityEngine;
using TMPro;

public class Name : MonoBehaviour
{
    public string word = null;
    public int wordIndex = 0;
    public int wordIndexMax = 3;

    public TextMeshProUGUI myName = null;

    public GameObject error;

    public void AlphabetAddFunction(string alphabet)
    {
        error.SetActive(false);

        if (wordIndex < wordIndexMax)
        {
            wordIndex++;
            word = word + alphabet;
            myName.text = word;
        }
    }

    public void alphabetRemoveFunction()
    {
        error.SetActive(false);

        if (wordIndex != 0)
        {
            wordIndex--;
            string wordMinus1 = word.Remove(word.Length - 1, 1);
            word = wordMinus1;
            myName.text = word;
        }
    }

    public void alphabetRemoveAllFunction()
    {
        error.SetActive(false);

        if (wordIndex != 0)
        {
            wordIndex = 0;
            string minusAll = word.Remove(word.Length - 2);
            word = minusAll;
            myName.text = word;
        }
    }
}