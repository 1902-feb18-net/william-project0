using System;
using System.Linq;
using Xunit;
using ComputerStore.Library;

namespace ComputerStore.Test
{
    public class CustomerTest
    {
        readonly Customer customer = new Customer();
        [Fact]
        public void Return_True_for_Assign_FirstName()
        {
            string name = "william";
            customer.FirstName = name;
            bool result = name == customer.FirstName;
            Assert.True(result, "This is true if allocated properly");
        }

        [Fact]
        public void Return_True_for_Assign_LastName()
        {
            string name = "craig";
            customer.LastName = name;
            bool result = name == customer.LastName;
            Assert.True(result, "This is true if allocated properly");
        }

        [Fact]
        public void Return_True_for_Assign_Address()
        {
            string address = "123 st";
            customer.Address = address;
            bool result = address == customer.Address;
            Assert.True(result, "This is true if allocated properly");
        }

        [Fact]
        public void Return_True_for_Assign_PhoneNumber()
        {
            string phone = "217-710-5429";
            customer.PhoneNumber = phone;
            bool result = phone == customer.PhoneNumber;
            Assert.True(result, "This is true if allocated properly");
        }
    }
}
