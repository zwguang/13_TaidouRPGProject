using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testSpritePacker : MonoBehaviour {
    public Image image;
    void Start()
    {
        string str = "text";//Resources文件夹下面的名字  
                            //SpriteRenderer[] sp = Resources.LoadAll<SpriteRenderer>(str);  


        Sprite[] sprites = Resources.LoadAll<Sprite>(str);
        foreach (var item in sprites)
        {
            print(item.name);

        }
      //  image.sprite = sprites[2];
    }
}
