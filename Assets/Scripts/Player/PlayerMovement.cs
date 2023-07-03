using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento del personaje

    private CharacterController characterController;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (GameManager.Instance.IsPaused) return;
        
        Vector2 moventVector = GameInput.Instance.GetMovementVector();
        Vector3 move = new Vector3(moventVector.x, 0f, moventVector.y);
        characterController.Move(move * Time.deltaTime * moveSpeed);
    }
}
