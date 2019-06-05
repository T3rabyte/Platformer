using UnityEngine;

public class heart : MonoBehaviour
{
    public bool inRange;

    public Collider2D Range;

    void Update()
    {
        inRange = Range.IsTouchingLayers(LayerMask.GetMask("player"));

        if (inRange)
        {
            if (GameObject.Find("GM").GetComponent<GM>().healthPlayer <= 4)
            {
                GameObject.Find("GM").GetComponent<GM>().healthPlayer += 1;
                Destroy(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}
