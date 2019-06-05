using UnityEngine;

public class cameraController : MonoBehaviour
{
    public GameObject player;

    public GameObject eersteStiltepunt;
    public float eersteStiltepuntY;

    public float oudelocatie;
    public float nieuwelocatie;

    public Collider2D endOfCamera;
    public bool inRange;

    public float borderLocatie;
    public float yLocatie;

    public float maxSpeed = 5f;

    void Update()
    {

        locatie();

        inRange = endOfCamera.IsTouchingLayers(LayerMask.GetMask("player"));

        borderLocatie = this.transform.position.x;
        borderLocatie -= 13.69f;

        if (player.transform.position.x <= borderLocatie)
        {
            endOfCamera.enabled = true;
        }
        if (player.transform.position.x > borderLocatie)
        {
            endOfCamera.enabled = false;
        }
    }

    void locatie()
    {
        if (GameObject.Find("GM").GetComponent<GM>().healthPlayer >= 1)
        {
            if (player.transform.position.x >= 77.31 && player.transform.position.x <= 102.68)
            {
                yLocatie = player.transform.position.y;
                yLocatie += 2.04411f;
                transform.position = new Vector3(90.02f, yLocatie, -3.191406f);
            }
            if (player.transform.position.x <= 77.31 || player.transform.position.x >= 102.68)
            {
                if (GameObject.Find("Player").GetComponent<playerControllerScript>().facingRight == true && nieuwelocatie >= oudelocatie)
                {
                    yLocatie = player.transform.position.y;
                    yLocatie += 2.04411f;
                    transform.position = new Vector3(player.transform.position.x, yLocatie, -10);
                    oudelocatie = transform.position.x;
                    nieuwelocatie = player.transform.position.x;
                }
                else if (GameObject.Find("Player").GetComponent<playerControllerScript>().facingRight == true)
                {
                    yLocatie = player.transform.position.y;
                    yLocatie += 2.04411f;
                    transform.position = new Vector3(oudelocatie, yLocatie, -10);
                    oudelocatie = transform.position.x;
                    nieuwelocatie = player.transform.position.x;
                }
                else if (GameObject.Find("Player").GetComponent<playerControllerScript>().facingRight == false)
                {
                    yLocatie = player.transform.position.y;
                    yLocatie += 2.04411f;
                    transform.position = new Vector3(oudelocatie, yLocatie, -10);
                    nieuwelocatie = player.transform.position.x;
                }
            }
        }
    }

    public void respawn()
    {
        yLocatie = player.transform.position.y;
        yLocatie += 2.04411f;
        transform.position = new Vector3(player.transform.position.x, yLocatie, -10);
        oudelocatie = transform.position.x;
        nieuwelocatie = player.transform.position.x;
    }
}