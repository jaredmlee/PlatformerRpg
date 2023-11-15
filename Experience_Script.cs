using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Experience_Script : MonoBehaviour
{
    public Text xpText;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        int experience = player.GetComponent<Player_script>().experience;
        changeXpNum(experience);
    }
    public void changeXpNum(int xp)
    {
        xpText.text = xp.ToString();
    }
}
