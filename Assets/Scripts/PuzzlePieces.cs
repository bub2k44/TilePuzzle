using UnityEngine;
using UnityEngine.Rendering;

public class PuzzlePieces : MonoBehaviour
{
    public bool inHoldBoxPosition = false;
    public bool selected;

    private Vector3 _holdBoxPosition;
    
    private void Start() => SetPuzzle();

    private void Update() => CheckPuzzlePosition();

    public void SetPuzzle()
    {
        _holdBoxPosition = transform.position;

        transform.position = new Vector3(Random.Range(1.85f, 6.25f), Random.Range(1.0f, -2.50f));
    }

    private void CheckPuzzlePosition()
    {
        if (Vector3.Distance(transform.position, _holdBoxPosition) < 0.5f)
        {
            if (!selected)
            {
                if (inHoldBoxPosition == false)
                {
                    transform.position = _holdBoxPosition;
                    SoundManager.PlaySound("Teleport");           
                    inHoldBoxPosition = true;
                    GetComponent<SortingGroup>().sortingOrder = 0;
                    PermanentUI.perm.pieceCounter++;
                }
            }
        }
    }
}