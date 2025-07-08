using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Develop.CommonServices.SceneManagment
{
    public abstract class SceneBootstrap : MonoBehaviour
    {
        public abstract IEnumerator Run(IInputSceneArgs inputSceneArgs = null);
    }
}
