using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerLib.Library
{
    class Part
    {
        private string _partName;
        private int _partCost;

        public int Id { get; set; }
        public string Name
        {
            get => _partName;
            set
            {
                if(value.Length == 0)
                {
                    throw new ArgumentException("Name must not be empty", nameof(value));
                }
                _partName = value;
            }
        }
        public int Cost
        {
            get => _partCost;
            set
            {
                _partCost = value;
            }
        }
    }
}
