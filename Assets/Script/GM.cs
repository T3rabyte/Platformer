using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GM : MonoBehaviour
{
    public int gold = 0;
    public Text goldText;

    public int healthPlayer = 5;
    public Text Hp;

    public bool levend = true;
    
    public GameObject skeletonObject;
    public GameObject breakableSurface;

    public Transform playerTransform;
    public Transform cameraTransform;

    GameObject[] enemy;
    GameObject[] breakingSurface;

    void Start()
    {
        breakingSurface = GameObject.FindGameObjectsWithTag("breaking");
        enemy = GameObject.FindGameObjectsWithTag("enemy");
        Hp.text = "Hp: " + healthPlayer;
        goldText.text = "Gold: " + gold;
        instantiate();
    }

   
    void Update()
    {
        Hp.text = "Hp: " + healthPlayer;
        goldText.text = "Gold: " + gold;

        if (healthPlayer == 0 && levend)
        {
            levend = false;
            healthPlayer = 5;
            GameObject.Find("MainCamera").GetComponent<cameraController>().enabled = false;
            breakingSurface = GameObject.FindGameObjectsWithTag("breaking");
            enemy = GameObject.FindGameObjectsWithTag("enemy");
            for (int i = 0; i < enemy.Length; i++)
            {
                Destroy(enemy[i]);
                enemy[i] = null;
            }
            for (int i = 0; i < breakingSurface.Length; i++)
            {
                Destroy(breakingSurface[i]);
                breakingSurface[i] = null;
            }
            playerTransform.transform.position = new Vector3(-1.36f, 14.6f, -0.35f);
            StartCoroutine(cameraReset());
            levend = true;
            instantiate();
        }
    }

    void instantiate()
    {
        Instantiate(skeletonObject, new Vector3(35.91f, 19.02f, -0.19f), Quaternion.identity);
        Instantiate(breakableSurface, new Vector3(52.90141f, 15.84f, 0f), Quaternion.identity);
        Instantiate(breakableSurface, new Vector3(92.87f, 30.8f, 0f), Quaternion.identity);
        Instantiate(breakableSurface, new Vector3(87.35f, 35.012f, 0f), Quaternion.identity);
    }

    IEnumerator cameraReset()
    {
        yield return new WaitForSeconds(0.1f);
        cameraTransform.transform.position = new Vector3(-1.26f, 15.84f, -10f);
        GameObject.Find("MainCamera").GetComponent<cameraController>().respawn();
        GameObject.Find("MainCamera").GetComponent<cameraController>().enabled = true;
        StopCoroutine(cameraReset());
    }
}
