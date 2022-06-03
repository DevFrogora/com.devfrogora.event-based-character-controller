using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterLocomotion : MonoBehaviour
{
    Animator animator;
    Vector2 input;
    InputActionMap landActionMap;

    //Camera Position on Car and plane or land or water
    //public CinemachineCameraOffset camera;
    //default Vector3(0.38,-0.15,-0.84)
    public Vector3 defaultCameraPos = new Vector3(0.38f, -0.15f, -0.84f);

    void Start()
    {
        animator = GetComponent<Animator>();
        landActionMap = ActionMapManager.playerInput.actions.FindActionMap(ActionMapManager.ActionMap.Land);

        GameManager.instance.changeActionMap += ChangeActionMap;
    }

    void ChangeActionMap(string actionMap)
    {
        if(actionMap == ActionMapManager.ActionMap.Land)
        {
            animator.SetLayerWeight((int)AnimatorManager.AnimatorLayer.Land, 1);
            RegisterActionMap();
        }
        else
        {
            animator.SetLayerWeight((int)AnimatorManager.AnimatorLayer.Land, 0);
            UnRegisterActionMap();
        }
    }

    void RegisterActionMap()
    {
        landActionMap["Move"].performed += Walk_performed;
        landActionMap["Move"].canceled += Walk_canceled;
    }

    private void Walk_performed(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
        Walk_animation(input);
    }

    private void Walk_canceled(InputAction.CallbackContext context)
    {
        input = Vector2.zero;
        Walk_animation(input);
    }

    void Walk_animation(Vector2 input)
    {
        animator.SetFloat("InputX", input.x);
        animator.SetFloat("InputY", input.y);
    }

    private void OnDisable()
    {
        UnRegisterActionMap();
    }

    void UnRegisterActionMap()
    {
        landActionMap["Move"].performed -= Walk_performed;
        landActionMap["Move"].canceled -= Walk_canceled;
        landActionMap.Disable();
    }


}
