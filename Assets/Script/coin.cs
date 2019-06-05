using UnityEngine;

public class coin : MonoBehaviour
{
    public bool inRange;

    public Collider2D Range;

    void Update()
    {
        inRange = Range.IsTouchingLayers(LayerMask.GetMask("player"));

        if (inRange)
        {
            GameObject.Find("GM").GetComponent<GM>().gold += 1;
            Destroy(this.gameObject);
        }
    }
}
