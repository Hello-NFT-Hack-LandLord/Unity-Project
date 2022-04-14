using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
        [SerializeField] DungeonManager dungeonManager;
        bool canUpdate = false;
        public void Start()
        {
                Invoke("StartUpdating", 0.25f);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
                if (canUpdate)
                {
                        string cTag = collision.tag;

                        int tileIndex = cTag[0] - '0' ;
                        Debug.Log(tileIndex.ToString() + " TE TAG " + cTag); 
                        dungeonManager.dungeon.UpdateLocation(tileIndex);
                        canUpdate = false;
                        Invoke("StartUpdating", 0.2f);
                }
                
        }
        public void StartUpdating()
        {
                canUpdate = true;
        }
}
