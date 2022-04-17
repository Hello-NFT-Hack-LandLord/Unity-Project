using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
        [SerializeField] public Transform player;

        // Update is called once per frame
        void Update()
        {
                transform.position = new Vector3(player.position.x, player.position.y, -10) ;
        }
}
