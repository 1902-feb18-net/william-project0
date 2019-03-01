using System;
using System.Linq;
using Xunit;
using ComputerLib.Library;

namespace ComputerTest.Test
{
    public class UnitTest1
    {
        readonly Customer customer = new Customer();
        [Fact]
        public void Return_True_for_Allocation_FirstName()
        {
            string name = "william";
            customer.FirstName = name;
            bool result = name == customer.FirstName;
            Assert.True(result, "This is true if allocated properly");
        }

        [Fact]
        public void Return_True_for_Allocation_LastName()
        {
            string name = "craig";
            customer.LastName = name;
            bool result = name == customer.LastName;
            Assert.True(result, "This is true if allocated properly");
        }
    }
}
