using System;
using Xunit;
using ComputerStore.Library;

namespace ComputerStore.Test
{
    public class StoreTest
    {
        readonly Store store = new Store();
        [Fact]
        public void Return_True_For_Assign_Address()
        {
            string address = "123 St";
            store.Address = address;
            bool result = address == store.Address;
            Assert.True(result, "This is true if allocated properly");
        }

        [Fact]
        public void Return_True_Fore_Assign_Name()
        {
            string name = "Best Buy";
            store.Name = name;
            bool result = name == store.Name;
            Assert.True(result, "This is true if allocated properly");
        }
    }
}
