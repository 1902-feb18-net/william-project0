using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Library
{
    public class Product
    {
        private string _name;
        private decimal _cost;

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

        public decimal Cost
        {
            get => _cost;
            set
            {
                _cost = value;
            }
        }

    }
} 
