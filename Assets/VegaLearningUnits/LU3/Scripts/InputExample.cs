using System;
using UnityEngine;

public class InputExample : MonoBehaviour
{
    private void Awake()
    {
        print("anyKey - Checks for any valid Keyboard or Mouse Input");
        print("GetButton|Down|Up -  Checks for Unity Defined String Representations of Buttons. You can view these in the Project Settings under Input.");
        print("GetMouseButton|Down|Up - Checks for Mouse Button Input - 0 => Left Button ; 1 => Right Button ; 2 => Middle Button");
        print("GetAxis + GetAxisRaw - Gets the Horizontal or Vertical Input from the Keyboard or Controller. These values range from [-1, 1].");
        print("GetKey|Down|Up - Checks for a specific input button. For example KeyCode.A is the A button on the Keyboard, etc");
    }

    private void Update()
    {
        ProcessInput();
    }

    /// <summary>
    /// OnMouseDown is called when the user has pressed the mouse button while over the Collider. This function can be a coroutine
    /// </summary>
    private void OnMouseDown()
    {
        print("OnMouseDown is called when the user has pressed the mouse button while over the Collider");
    }

    /// <summary>
    /// OnMouseUp is called when the user has released the mouse button. This function can be a coroutine
    /// </summary>
    private void OnMouseUp()
    {
        print("OnMouseUp is called when the user has released the mouse button");
    }

    /// <summary>
    /// OnMouseUpAsButton is only called when the mouse is released over the same Collider as it was pressed. This function can be a coroutine
    /// </summary>
    private void OnMouseUpAsButton()
    {
        print("OnMouseUpAsButton is only called when the mouse is released over the same Collider as it was pressed");
    }

    /// <summary>
    /// Called when the mouse enters the Collider. This function can be a coroutine
    /// </summary>
    private void OnMouseEnter()
    {
        print("Called when the mouse enters the Collider");
    }

    /// <summary>
    /// Called every frame while the mouse is over the Collider. This function can be a coroutine.
    /// </summary>
    private void OnMouseOver()
    {
        print("Called every frame while the mouse is over the Collider");
    }

    /// <summary>
    /// Called when the mouse is not any longer over the Collider. This function can be a coroutine
    /// </summary>
    private void OnMouseExit()
    {
        print("Called when the mouse is not any longer over the Collider");
    }

    /// <summary>
    /// OnMouseDrag is called when the user has clicked on a Collider and is still holding down the mouse. This function can be a coroutine
    /// </summary>
    private void OnMouseDrag()
    {
        print("OnMouseDrag is called when the user has clicked on a Collider and is still holding down the mouse");
    }

    private void ProcessInput()
    {
        if (Input.anyKey)
        {
            print("Any Mouse or Keyboard Interaction");
        }

        if (Input.anyKeyDown)
        {
            print("Any Mouse or Keyboard Interaction Pressed Down");
        }

        if (Input.GetButton("Fire1"))
        {
            print("Get Button - Continuously Held Down - Fire1");
        }

        if (Input.GetButtonDown("Fire1"))
        {
            print("Get Button Down - Button Pressed - Fire1");
        }

        if (Input.GetButtonUp("Fire1"))
        {
            print("Get Button Up - Button Released - Fire1");
        }

        if (Input.GetButtonDown("Fire2"))
        {
            print("Fire2 Button");
        }

        if (Input.GetButtonDown("Fire3"))
        {
            print("Fire3 Button");
        }

        if (Input.GetButton("Horizontal"))
        {
            print("Horizontal Axis - Left and Right Arrow || A and D Buttons - Values [-1, 1]");
        }

        if (Input.GetButtonDown("Vertical"))
        {
            print("Vertical Axis - Up and Down Arrow || W and S Buttons - Values [-1, 1]");
        }

        if (Input.GetButtonDown("Jump"))
        {
            print("Jump Button");
        }

        if (Input.GetButtonDown("Submit"))
        {
            print("Submit Button");
        }

        if (Input.GetButtonDown("Cancel"))
        {
            print("Cancel");
        }

        if (Input.GetMouseButton(0))
        {
            print("Left Mouse Button");
        }

        if (Input.GetMouseButton(1))
        {
            print("Right Mouse Button");
        }

        if (Input.GetMouseButton(2))
        {
            print("Middle Mouse Button");
        }

        if (Input.GetKey(KeyCode.Z))
        {
            print("Pressing the KeyCode.Z");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            print("Pressed the KeyCode.A");
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            print("Released the KeyCode.Space");
        }

        print($"Horizontal Axis - {Input.GetAxis("Horizontal")}");
        print($"Horizontal Axis Raw - {Input.GetAxisRaw("Horizontal")}");
        print($"Vertical Axis - {Input.GetAxisRaw("Vertical")}");
        print($"Horizontal Axis Raw - {Input.GetAxis("Vertical")}");
    }
}