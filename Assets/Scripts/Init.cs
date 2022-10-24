using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    public Camera cam;
    public GameObject cube, playerSquad;
    private float cameraMoveSpeed = 3f;
    //private float xMouse;
    //private float yMouse;
    void Awake()
    {
        Debug.Log("Awake");
    }
    void Start()
    {
        Debug.Log("Init Start");
        playerSquad.transform.position = new Vector3(-9, -5);
        for (int i = -9; i <= 9; i++)
        {
            for (int j = -5; j <= 5; j++)
            {
                Instantiate(cube, new Vector3(i, j, 1), Quaternion.identity);
            }
        }
    }
    IEnumerator move(Vector3 finalPoint)
    {

        if (finalPoint.y > playerSquad.transform.position.y)
        {
            playerSquad.transform.position.Set(playerSquad.transform.position.x, playerSquad.transform.position.y + 1, playerSquad.transform.position.z);
        }
        else if (finalPoint.x > playerSquad.transform.position.x)
        {
            playerSquad.transform.position.Set(playerSquad.transform.position.x + 1, playerSquad.transform.position.y, playerSquad.transform.position.z);
        }
        if (finalPoint.y < playerSquad.transform.position.y)
        {
            playerSquad.transform.position.Set(playerSquad.transform.position.x, playerSquad.transform.position.y - 1, playerSquad.transform.position.z);
        }
        else if (finalPoint.x < playerSquad.transform.position.x)
        {
            playerSquad.transform.position.Set(playerSquad.transform.position.x - 1, playerSquad.transform.position.y, playerSquad.transform.position.z);
        }
        yield return new WaitForSeconds(1);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector2 mousePosition = Input.mousePosition;
            Vector2 pos = cam.ScreenToWorldPoint(mousePosition);
            Vector3 finalPoint = new Vector3(pos.x, pos.y, 0);
            while (finalPoint != playerSquad.transform.position)
            {
                if (finalPoint.y > playerSquad.transform.position.y)
                {
                    playerSquad.transform.position.Set(playerSquad.transform.position.x, playerSquad.transform.position.y + 1, playerSquad.transform.position.z);
                }
                else if (finalPoint.x > playerSquad.transform.position.x)
                {
                    playerSquad.transform.position.Set(playerSquad.transform.position.x + 1, playerSquad.transform.position.y, playerSquad.transform.position.z);
                }
                if (finalPoint.y < playerSquad.transform.position.y)
                {
                    playerSquad.transform.position.Set(playerSquad.transform.position.x, playerSquad.transform.position.y - 1, playerSquad.transform.position.z);
                }
                else if (finalPoint.x < playerSquad.transform.position.x)
                {
                    playerSquad.transform.position.Set(playerSquad.transform.position.x - 1, playerSquad.transform.position.y, playerSquad.transform.position.z);
                }
            }
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            Debug.Log("mouse pressed");
            Vector2 mousePosition = Input.mousePosition;
            Vector2 pos = cam.ScreenToWorldPoint(mousePosition);
            if (pos.x > cam.transform.position.x && pos.y > cam.transform.position.y)
            {
                cam.transform.position = new Vector3(cam.transform.position.x + cameraMoveSpeed * Time.deltaTime, cam.transform.position.y + cameraMoveSpeed * Time.deltaTime, -10f);
            }
            if (pos.x < cam.transform.position.x && pos.y < cam.transform.position.y)
            {
                cam.transform.position = new Vector3(cam.transform.position.x - cameraMoveSpeed * Time.deltaTime, cam.transform.position.y - cameraMoveSpeed * Time.deltaTime, -10f);
            }
            if (pos.x < cam.transform.position.x && pos.y > cam.transform.position.y)
            {
                cam.transform.position = new Vector3(cam.transform.position.x - cameraMoveSpeed * Time.deltaTime, cam.transform.position.y + cameraMoveSpeed * Time.deltaTime, -10f);
            }
            if (pos.x > cam.transform.position.x && pos.y < cam.transform.position.y)
            {
                cam.transform.position = new Vector3(cam.transform.position.x + cameraMoveSpeed * Time.deltaTime, cam.transform.position.y - cameraMoveSpeed * Time.deltaTime, -10f);
            }
        }
        /* while (finalPoint != playerSquad.transform.position)
         {
             if (finalPoint.y > playerSquad.transform.position.y)
             {
                 playerSquad.transform.position = new Vector2(playerSquad.transform.position.x, playerSquad.transform.position.y + 1);
             }
             else if (finalPoint.x > playerSquad.transform.position.x)
             {
                 playerSquad.transform.position = new Vector2(playerSquad.transform.position.x + 1, playerSquad.transform.position.y);

             }
             if (finalPoint.y < playerSquad.transform.position.y)
             {
                 playerSquad.transform.position = new Vector2(playerSquad.transform.position.x, playerSquad.transform.position.y - 1);
             }
             else if (finalPoint.x < playerSquad.transform.position.x)
             {
                 playerSquad.transform.position = new Vector2(playerSquad.transform.position.x - 1, playerSquad.transform.position.y);

             }
         }*/
    }
}
