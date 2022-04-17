using System.Collections;
using System.Numerics;
using System.Collections.Generic;
using UnityEngine;

public class ERC1155BalanceOfExample : MonoBehaviour
{
    async void Start()
    {
        string chain = "ethereum";
        string network = "rinkeby";
        string contract = "0xCE5901Ef315f31a692271Bc858a7C65b2e97ce96";
        string account = "0xdD4c825203f97984e7867F11eeCc813A036089D1";
        string tokenId = "2";

        BigInteger balanceOf = await ERC1155.BalanceOf(chain, network, contract, account, tokenId);
        print(balanceOf);
    }
}
