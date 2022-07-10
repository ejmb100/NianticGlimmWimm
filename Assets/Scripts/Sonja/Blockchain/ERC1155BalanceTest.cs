using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Numerics;

public class ERC1155BalanceTest : MonoBehaviour
{
    public GameObject Sphere;

    async void Start()
    {
        string chain = "avalanche";
        string network = "testnet";
        string contract = "0xbDF2d708c6E4705824dC024187cd219da41C8c81";
        string account = "0xdD4c825203f97984e7867F11eeCc813A036089D1";
        string tokenId = "2";

        BigInteger balanceOf = await ERC1155.BalanceOf(chain, network, contract, account, tokenId);
        print(balanceOf);

        if (balanceOf > 0)
        {
            Sphere.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        }
    }
}


/*
        string chain = "etherium";
        string network = "rinkeby";
        string contract = "0x88b48f654c30e99bc2e4a1559b4dcf1ad93fa656";
        string account = PlayerPrefs.GetString("Account");
        string tokenId = "44fb898bd8204c728c11943eb41866c6";

        BigInteger balanceOf = await ERC1155.BalanceOf(chain, network, contract, account, tokenId);
        print(balanceOf);

        
        if(balanceOf > 0)
        {
            Sphere.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        }
        */