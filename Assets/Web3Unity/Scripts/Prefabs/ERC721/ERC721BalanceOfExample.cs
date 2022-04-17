using System.Collections;
using System.Numerics;
using System.Collections.Generic;
using UnityEngine;

public class ERC721BalanceOfExample : MonoBehaviour
{
        [SerializeField] TerrainManager terrainManager;
        public int balance;
        async void Start()
        {
                string chain = "ethereum";
                string network = "rinkeby";
                string contract = "0xCE5901Ef315f31a692271Bc858a7C65b2e97ce96";
                string account = PlayerPrefs.GetString("Account");

                balance = await ERC721.BalanceOf(chain, network, contract, account);
                print(balance);
               // if( balance  > 0)
                //{
                        terrainManager.LoadTerrain(15);
                //}
        }
}
