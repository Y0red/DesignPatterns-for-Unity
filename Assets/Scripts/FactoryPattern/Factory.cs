using System.Collections;
using UnityEngine;

namespace Assets.Scripts.FactoryPattern
{
    /// <summary>
    ///  The Factory pattern creates different products that share a common interface.
    ///  Each product is a different class with its own construction logic.
    /// </summary>
    public abstract class Factory : MonoBehaviour
    {
        public abstract IProduct GetProduct(Vector3 position);

        // shared method with all factories
       
    }
}