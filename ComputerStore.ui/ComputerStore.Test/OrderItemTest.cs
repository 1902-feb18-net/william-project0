using System;
using System.Collections.Generic;
using System.Text;
using ComputerStore.Library;
using Xunit;

namespace ComputerStore.Test
{
    public class OrderItemTest
    {
        readonly OrderItem orderItem = new OrderItem();
        [Fact]
        public void Return_True_For_Assign_Name()
        {
            string name = "Cpu";
            orderItem.Name = name;
            bool result = name == orderItem.Name;
            Assert.True(result, "This is true if allocated properly");
        }
    }
}
