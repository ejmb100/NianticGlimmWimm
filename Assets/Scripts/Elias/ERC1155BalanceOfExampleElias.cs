using System.Collections;
using System.Numerics;
using System.Collections.Generic;
using UnityEngine;

public class ERC1155BalanceOfExampleElias : MonoBehaviour
{
    public GameObject sphere;


    async void Start()
    {
        string chain = "avalanche";
        string network = "testnet";
        string contract = "0xbDF2d708c6E4705824dC024187cd219da41C8c81";
        string account = "0xdD4c825203f97984e7867F11eeCc813A036089D1";
        string tokenId = "2";

        BigInteger balanceOf = await ERC1155.BalanceOf(chain, network, contract, account, tokenId);
        print("balanceOf is: " + balanceOf);

        if (balanceOf > 0)
        {
            sphere.GetComponent<Renderer>().material.SetColor("_blue", Color.red);
            Debug.Log("executed color.red code");
        }
    }

    

}
