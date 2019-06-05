using UnityEngine;

public class instaDeath : MonoBehaviour
{
    public bool inRange = false;
    public Collider2D deathTrigger;

    void Start()
    {
        
    }
    
    void Update()
    {
        inRange = deathTrigger.IsTouchingLayers(LayerMask.GetMask("player"));

        if (inRange)
        {
            GameObject.Find("GM").GetComponent<GM>().healthPlayer = 0;
        }
    }
}
