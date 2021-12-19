using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLibControl : Singleton<SpriteLibControl>
{
    public Sprite[] sprites;
    private Dictionary<string, Sprite> dicSprite= new Dictionary<string, Sprite>();
    // Start is called before the first frame update
    void Start()
    {
        foreach(Sprite e in sprites)
        {
            dicSprite.Add(e.name, e);
        }
    }

    public Sprite GetSpriteByName(string name)
    {
        Sprite sprite_ = null;
        dicSprite.TryGetValue(name, out sprite_);
        return sprite_;
    }
}
