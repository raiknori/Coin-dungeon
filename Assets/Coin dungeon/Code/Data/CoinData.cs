using UnityEngine;

[CreateAssetMenu(fileName ="NewCoinData",menuName = "Coins/Create coin")]
public class CoinData:ScriptableObject
{
    [Range(0, 1f)]public float winChance;

    [Range(0, 5f)]public float goldX;

    public Sprite coinSpriteHead;
    public Sprite coinSpriteTail;
    public Sprite coinSpriteDeffault;

    public string name;
    public string description;
}
