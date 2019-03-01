using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ComputerLib.Library
{
    public class Part
    {
        private string _partName;
        private int _partCost;
        private int _inventory;

        [XmlAttribute]
        public int Id { get; set; }

        [XmlAttribute("Name")]
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

        [XmlAttribute("Cost")]
        public int Cost
        {
            get => _partCost;
            set
            {
                _partCost = value;
            }
        }

        [XmlAttribute("Inventory Carried")]
        public int Inventory
        {
            get => _inventory;
            set
            {
                _inventory = value;
            }
        }
    }
} 
