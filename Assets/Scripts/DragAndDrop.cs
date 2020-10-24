using UnityEngine;
using UnityEngine.Rendering;

public class DragAndDrop : MonoBehaviour
{
    public GameObject selectedPiece;

    private int _orderInLayer = 1;

    private void Update() => GetInput();

    private void GetInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.transform.CompareTag("Puzzle"))
            {
                if (!hit.transform.GetComponent<PuzzlePieces>().inHoldBoxPosition)
                {
                    selectedPiece = hit.transform.gameObject;
                    selectedPiece.GetComponent<PuzzlePieces>().selected = true;
                    selectedPiece.GetComponent<SortingGroup>().sortingOrder = _orderInLayer;
                    _orderInLayer++;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (selectedPiece != null)
            {
                selectedPiece.GetComponent<PuzzlePieces>().selected = false;
                selectedPiece = null;
            }
        }

        if (selectedPiece != null)
        {
            Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            selectedPiece.transform.position = new Vector3(mousePoint.x, mousePoint.y, 0);
        }
    }
}
