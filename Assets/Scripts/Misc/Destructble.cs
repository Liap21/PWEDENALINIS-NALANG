using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destructible : MonoBehaviour, IDataPersistence
{
    [SerializeField] private GameObject destroyVFX;

    public void SaveData(ref GameData data)
    {
        // TODO - Save destructible objects
        //this.OnTriggerEnter2D = data.OnTriggerEnter2D;
    }

    public void LoadData(GameData data)
    {
        // TODO - Save destructible objects
        //OnTriggerEnter2D()
    }

   private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.GetComponent<DamageSource>() || other.gameObject.GetComponent<Projectile>()) {
            GetComponent<PickUpSpawner>().DropItems();
            Instantiate(destroyVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
