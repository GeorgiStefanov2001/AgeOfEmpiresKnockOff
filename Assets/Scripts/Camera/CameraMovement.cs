using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    //EXPERIMENT WITH THOSE VALUES 
    public float speed = 0; //the speed of the camera's movement
    public float distance = 0; //the distance from the borders at which the camera is starting to move
    public float zoomSpeed = 0; //speed of the camera's zoom
    public float minFov = 0; //the minimal fov of the camera (max zoom)
    public float maxFov = 0; //the maximal fov of the camera (min zoom)
    public float startingFov; //this is the starting fov of the camera that we get when the game is launched (int Start())
    public float centerSpeed = 0; //the speed at which the camera will center itself back to the default fov


    void Start()
    {
        startingFov = GetComponent<Camera>().fieldOfView;
    }

    void Update()
    {
        PlayerPrefs.SetInt("Movement", 1); //for testing purposes
        if (PlayerPrefs.GetInt("Movement") == 1) //checking the player's desired camera movement method
        {
            MouseMovement();
        }else if(PlayerPrefs.GetInt("Movement") == 2)
        {
            ArrowMovement();
        }
        Zooming();

    }

    void MoveRight()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void MoveLeft() {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    void MoveForward()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Translate(Vector3.up * speed * Time.deltaTime); //the camera is at a 45 degree angle so moving it forward will cause it to go to the ground 
                                                                  //so we move it up at the same time to balance it and make it go straight
    }

    void MoveBack()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
        transform.Translate(Vector3.down * speed * Time.deltaTime); //same here but this time we pull it down
    }

    void MouseMovement()
    {
        //getting the X and Y position of the mouse
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;

        //if the mouse is close to the right edge of the screen we move it to the right
        if (mouseX >= (Screen.width - distance))
        {
            MoveRight();
        }
        //if the mouse is close to the left edge of the screen we move it to the left
        else if (mouseX <= distance)
        {
            MoveLeft();
        }
        //if the mouse is close to the top edge of the screen we move it up
        if (mouseY >= (Screen.height - distance))
        {
            MoveForward();
        }
        //if the mouse is close to the bottom edge of the screen we move it down
        else if (mouseY <= distance)
        {
            MoveBack();
        }
    }

    void ArrowMovement() {
        if(Input.GetAxis("Horizontal")>0)
        {
            MoveRight();
        }else if(Input.GetAxis("Horizontal") < 0)
        {
            MoveLeft();
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            MoveForward();
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            MoveBack();
        }

    }

    void Zooming()
    {
        float fov = GetComponent<Camera>().fieldOfView; //getting the fov of the camera
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && fov >= minFov) //if we scroll up and are above the minFov, we zoom
        {
            fov -= zoomSpeed;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0 && fov <= maxFov) //if we scroll down and are below the maxFov, we outzoom
        {
            fov += zoomSpeed;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            fov = CenterCamera(fov);
        }
        GetComponent<Camera>().fieldOfView = fov; //reassigning the fov to the camera
    }

    float CenterCamera(float curr)
    {
        return Mathf.Lerp(curr, startingFov, centerSpeed); //Lerping means that it takes the value of curr (which in this case is the current fov) and gradually makes it the startingFov. 
                                                           //The whole process takes {centerSpeed} amount of time
    }
}
