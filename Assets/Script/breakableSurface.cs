using System.Collections;
using UnityEngine;

public class breakableSurface : MonoBehaviour
{

    public Collider2D surface;
    public bool inRange;

    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    

    void Update()
    {
        inRange = surface.IsTouchingLayers(LayerMask.GetMask("player"));

        if (inRange)
        {
            StartCoroutine(breaking());
        }
    }

    IEnumerator breaking()
    {
        yield return new WaitForSeconds(0.9f);
        anim.SetBool("val", true);
        yield return new WaitForSeconds(0.95f);
        Destroy(this.gameObject);
    }
}
