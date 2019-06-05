using System.Collections;
using UnityEngine;

public class spikes : MonoBehaviour
{
    public Sprite triggeredSprite;
    public Sprite normaleSprite;

    public bool inRange;
    public Collider2D spikeRange;

    public bool triggered = false;
    
    void Update()
    {
        inRange = spikeRange.IsTouchingLayers(LayerMask.GetMask("player"));

        if (inRange && !triggered)
        {
            triggered = true;
            GetComponent<SpriteRenderer>().sprite = triggeredSprite;
            GameObject.Find("GM").GetComponent<GM>().healthPlayer -= 1;
            StartCoroutine(triggeredCoroutine());
        }
    }

    IEnumerator triggeredCoroutine()
    {
        yield return new WaitForSeconds(2f);
        GetComponent<SpriteRenderer>().sprite = normaleSprite;
        yield return new WaitForSeconds(0.5f);
        triggered = false;
        StopCoroutine(triggeredCoroutine());
    }
}
