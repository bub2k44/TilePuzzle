using UnityEngine;
using UnityEngine.Rendering;

public class PuzzlePieces : MonoBehaviour
{
    public bool inHoldBoxPosition = false;
    public bool selected;
    private Collider2D coll;
    public SpriteRenderer sr;
    private Vector3 _holdBoxPosition;
    public float spriteBlinkingTimer = 0.0f;
    public float spriteBlinkingMiniDuration = 0.1f;
    public float spriteBlinkingTotalTimer = 0.0f;
    public float spriteBlinkingTotalDuration = .5f;//1.0f;
    public bool startBlinking = false;

    private void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        SetPuzzle();
    }

    private void Update()
    {
        CheckPuzzlePosition();

        if (startBlinking == true)
        {
            SpriteBlinkingEffect();
        }
    }

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
                    coll.enabled = false;
                    startBlinking = true;
                    transform.position = _holdBoxPosition;
                    SoundManager.PlaySound("Teleport");
                    inHoldBoxPosition = true;
                    GetComponent<SortingGroup>().sortingOrder = 0;
                    UIManager.instance.PieceCounter++;
                }
            }
        }
    }

    private void SpriteBlinkingEffect()
    {
        spriteBlinkingTotalTimer += Time.deltaTime;

        if (spriteBlinkingTotalTimer >= spriteBlinkingTotalDuration)
        {
            startBlinking = false;
            spriteBlinkingTotalTimer = 0.0f;
            sr.enabled = true;
            return;
        }

        spriteBlinkingTimer += Time.deltaTime;

        if (spriteBlinkingTimer >= spriteBlinkingMiniDuration)
        {
            spriteBlinkingTimer = 0.0f;

            if (sr.enabled == true)
            {
                sr.enabled = false;
            }
            else
            {
                sr.enabled = true;
            }
        }
    }
}