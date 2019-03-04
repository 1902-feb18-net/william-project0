using System;

namespace ComputerStore.Library
{
    public class SubProduct
    {
        private string _name;

        public int Id { get; set; }

        public string Name
        {
            get => _name;
            set
            {
                if(value.Length == 0)
                {
                    throw new ArgumentException("Name must not be empty", nameof(value));
                }
                _name = value;
            }
        }
    }
}
