using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
        [SerializeField] Transform target;
        public DungeonGraph dungeon;
        // Start is called before the first frame update
        void Start()
        {
                //recibo todo
                int mySeed = "0x491a9e632afecb932050e06f9832c427dcf00d00b728c2cadec7f9d09dc1806f".GetHashCode();
                Debug.Log(mySeed);
                Random.InitState( mySeed );
                dungeon = new DungeonGraph();
        }


}
