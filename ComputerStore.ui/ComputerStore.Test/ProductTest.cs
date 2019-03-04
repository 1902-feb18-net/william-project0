using System;
using System.Collections.Generic;
using System.Text;
using ComputerStore.Library;
using Xunit;

namespace ComputerStore.Test
{
    public class ProductTest
    {
        readonly Product product = new Product();

        [Fact]
        public void Return_True_For_Assign_Name()
        {
            string name = "Cpu";
            product.Name = name;
            bool result = name == product.Name;
            Assert.True(result, "This is true if allocated properly");
        }


    }
}
