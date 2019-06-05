using System.Collections;
using UnityEngine;

public class hendel1 : MonoBehaviour
{
    public Sprite overgehaald;
    public bool inRange;
    public Collider2D hendelCollider;

    public GameObject trap;
    public GameObject trapEind;

    public bool gebruikt = false;
    
    void Update()
    {
        inRange = hendelCollider.IsTouchingLayers(LayerMask.GetMask("player"));

        if (inRange && !gebruikt && Input.GetKeyDown(KeyCode.E))
        {
            gebruikt = true;
            GetComponent<SpriteRenderer>().sprite = overgehaald;
            this.transform.position = new Vector3(101.14f, 17.91f, -0.25f);
            StartCoroutine(instatiate());
        }
    }

    IEnumerator instatiate()
    {
        Instantiate(trap, new Vector3(84.37f, 26.88f, -0.25f), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Instantiate(trap, new Vector3(84.37f, 25.67f, -0.25f), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Instantiate(trap, new Vector3(84.37f, 24.463f, -0.25f), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Instantiate(trap, new Vector3(84.37f, 23.26f, -0.25f), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Instantiate(trap, new Vector3(84.37f, 22.06f, -0.25f), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Instantiate(trap, new Vector3(84.37f, 20.85f, -0.25f), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Instantiate(trap, new Vector3(84.37f, 19.64f, -0.25f), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Instantiate(trap, new Vector3(84.37f, 18.46f, -0.25f), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Instantiate(trapEind, new Vector3(84.37f, 17.54f, -0.25f), Quaternion.identity);
        StopCoroutine(instatiate());
    }
}
