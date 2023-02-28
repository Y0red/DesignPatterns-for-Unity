using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.FactoryPattern
{
    public class ProductA : MonoBehaviour,IProduct
    {
        [SerializeField] private string productName = "Product";

        public string ProductName { get => productName; set => productName = value; }

        private ParticleSystem particleSystem;

        public void Initialize()
        {
            // any uniqu logic to this product
            gameObject.name = productName;
            particleSystem = GetComponentInChildren<ParticleSystem>();
            particleSystem?.Stop();
            particleSystem?.Play();
        }
    }


    public class ConcreteFactoryA : Factory
    {
        [SerializeField] private ProductA productPrifab;

        public override IProduct GetProduct(Vector3 position)
        {
            //create a prifab instance and get the product components

            GameObject instance = Instantiate(productPrifab.gameObject, position, Quaternion.identity);

            ProductA newProduct = instance.GetComponent<ProductA>();

            //each product contains its own logic

            newProduct.Initialize();

            return newProduct;
        }
    }
}