using UnityEngine;
using TMPro;

public class Name : MonoBehaviour
{
    public string word = null;
    public int wordIndex = 0;
    public int wordIndexMax = 3;

    public TextMeshProUGUI myName = null;

    public void AlphabetAddFunction(string alphabet)
    {
        if (wordIndex < wordIndexMax)
        {
            wordIndex++;
            word = word + alphabet;
            myName.text = word;
        }
    }

    public void alphabetRemoveFunction()
    {
        if (wordIndex != 0)
        {
            wordIndex--;
            string wordMinus1 = word.Remove(word.Length - 1, 1);
            word = wordMinus1;
            myName.text = word;
        }
    }
}