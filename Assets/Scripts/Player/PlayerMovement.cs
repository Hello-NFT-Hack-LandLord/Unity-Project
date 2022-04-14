using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
                float horizontal =Input.GetAxis("Horizontal");
                float vertical = Input.GetAxis("Vertical");
                Vector3 inputVector = new Vector3(horizontal, vertical,0);
                inputVector = Vector3.ClampMagnitude(inputVector, 1);
                Vector3 movement = inputVector * 1f;
                transform.position = transform.position + movement * Time.deltaTime; 
        }
}
