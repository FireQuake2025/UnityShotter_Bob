using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour
{
    private TextMeshPro ammoText;
    private PlayerShooting playerShooting;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        ammoText = GetComponent<TextMeshPro>();
        playerShooting = GetComponent<PlayerShooting>();
    }

    // Update is called once per frame
    void Update()
    {
       ammoText.text  = "Ammo: " + playerShooting.ammo.ToString("Ammo");
    }
}
