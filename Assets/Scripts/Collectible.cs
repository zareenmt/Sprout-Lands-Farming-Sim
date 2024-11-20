using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Item))]
public class Collectible : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D collision)
   {
      
      Player player = collision.GetComponent<Player>();

      if (player)
      {
         Item item = GetComponent<Item>();
         if (item)
         {
            player.inventory.Add(item);
            Destroy(this.gameObject);
         }
         
      }
   }
}

