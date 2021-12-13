/*
 * Full Name        : Negin Saeidi
 * Student ID       : 101261395
 * Date Modified    : December 12, 2021
 * File             : UIController.cs
 * Description      : This is the UIController script - Has the events for JumpButtonDown and JumpButtonUp
 * Version          : V01
 * Revision History : Added jump button events
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [Header("On Screen Controls")]
 //   public GameObject onScreenControls;

    [Header("Button Control Events")]
    public static bool jumpButtonDown;

    // Start is called before the first frame update
    void Start()
    {
        CheckPlatform();
    }

    // PRIVATE METHODS

    private void CheckPlatform()
    {
        //switch (Application.platform)
        //{
        //    case RuntimePlatform.Android:
        //    case RuntimePlatform.IPhonePlayer:
        //    case RuntimePlatform.WindowsEditor:
        //        onScreenControls.SetActive(true);
        //        break;
        //    default:
        //        onScreenControls.SetActive(false);
        //        break;
        //}
    }

    // EVENT FUNCTIONS

    public void OnJumpButton_Down()
    {
        jumpButtonDown = true;
    }

    public void OnJumpButton_Up()
    {
        jumpButtonDown = false;
    }
}
