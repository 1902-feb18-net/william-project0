using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Library
{
    public class ProductGroup
    {
        private int? _productId;
        private int? _subProductId;

        public int Id { get; set; }
        public int? ProductId
        {
            get => _productId;
            set
            {
                _productId = value;
            }
        }

        public int? SubProductId
        {
            get => _subProductId;
            set
            {
                _subProductId = value;
            }
        }
    }
}
