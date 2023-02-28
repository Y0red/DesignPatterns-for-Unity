namespace Assets.Scripts.FactoryPattern
{
    public interface IProduct
    {
        public string ProductName { get; set; }

        public void Initialize();
    }
}