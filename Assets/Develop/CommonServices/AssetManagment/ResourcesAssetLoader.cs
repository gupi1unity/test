using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesAssetLoader
{
    public T LoadResource<T>(string resourcePath) where T : Object => Resources.Load<T>(resourcePath);
}
