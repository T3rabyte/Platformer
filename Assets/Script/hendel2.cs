using System.Collections;
using UnityEngine;

public class hendel2 : MonoBehaviour
{
    public Sprite overgehaald;
    public bool inRange;
    public Collider2D hendelCollider;

    public GameObject breakableSurface;

    public bool gebruikt = false;
    
    void Update()
    {
        inRange = hendelCollider.IsTouchingLayers(LayerMask.GetMask("player"));

        if (inRange && !gebruikt && Input.GetKeyDown(KeyCode.E))
        {
            gebruikt = true;
            GetComponent<SpriteRenderer>().sprite = overgehaald;
            this.transform.position = new Vector3(78.71f, 37.0693f, -0.25f);
            StartCoroutine(instatiate());
        }
    }

    IEnumerator instatiate()
    {
        Instantiate(breakableSurface, new Vector3(87.35f, 35.012f, 0f), Quaternion.identity);
        Instantiate(breakableSurface, new Vector3(93.55f, 35.012f, 0f), Quaternion.identity);
        yield return new WaitForSeconds(1);
        StopCoroutine(instatiate());
    }
}
