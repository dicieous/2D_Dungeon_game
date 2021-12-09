using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : collidable
{
    public GameObject closedDoor;
    public string[] sceneNames;
    private int i = 1;
    protected override void onCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            string sceneName = sceneNames[i];
            Destroy(closedDoor);
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
            GameManager.instance.saveState();
            i++;
            Debug.Log(i);
        }
    }
}
