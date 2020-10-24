using UnityEngine;
using UnityEngine.UI;

public class PuzzleSelect : MonoBehaviour
{
    public GameObject startPanel;

    public void SetPuzzlePhoto(Image photo)
    {
        if (PermanentUI.perm.pieceCounter == 0)
        {
            for (int i = 0; i < 18; i++)
            {
                GameObject.Find("Piece (" + i + ")").transform.Find("Puzzle")
                    .GetComponent<SpriteRenderer>().sprite = photo.sprite;
            }

            startPanel.SetActive(false);
        }
    }
}