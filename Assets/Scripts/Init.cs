using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    public Camera cam;
    public GameObject cube, playerSquad;
    private float cameraMoveSpeed = 3f;
    private float xMouse;
    private float yMouse;
    void Start()
    {
        playerSquad.transform.position = new Vector3(-9, -5);
        for (int i = -9; i <= 9; i++)
        {
            for (int j = -5; j <= 5; j++)
            {
                Instantiate(cube, new Vector3(i, j, 1), Quaternion.identity);
            }
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            xMouse = Input.mousePosition.x;
            yMouse = Input.mousePosition.y;
            Vector2 pos = cam.ScreenToWorldPoint(new Vector2((int)xMouse, (int)yMouse));
            Vector3 finalPoint = new Vector2(Mathf.Round(pos.x), Mathf.Round(pos.y));
            while(finalPoint != playerSquad.transform.position)
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
            }
        }

























        if(Input.GetKey(KeyCode.Mouse1))
        {
            xMouse = Input.mousePosition.x;
            yMouse = Input.mousePosition.y;
            Vector2 pos = cam.ScreenToWorldPoint(new Vector2(xMouse, yMouse));
            if(pos.x > cam.transform.position.x && pos.y > cam.transform.position.y)
            {
                cam.transform.position = new Vector3(cam.transform.position.x + cameraMoveSpeed * Time.deltaTime, cam.transform.position.y + cameraMoveSpeed * Time.deltaTime, -10f) ;
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
    }
}
