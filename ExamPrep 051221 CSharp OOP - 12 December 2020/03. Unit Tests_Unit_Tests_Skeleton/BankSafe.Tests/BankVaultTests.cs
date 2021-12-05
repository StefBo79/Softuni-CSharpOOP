using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault vault;
        private Item item;
        private Item item2;

        [SetUp]
        public void Setup()
        {
            vault = new BankVault();
            item = new Item("me", "1");
            item2 = new Item("you", "2");
        }

        [Test]
        public void WhenCellDoesNotExist_ShouldThrowExeption()
        {            
            Assert.Throws<ArgumentException>(() => vault.AddItem("you", item));
        }

        [Test]
        public void WhenCellIsAlreadyTaken_ShouldThrowExeption()
        {
            vault.AddItem("A2", item);            
            Assert.Throws<ArgumentException>(() => vault.AddItem("A2", item));
        }

        [Test]
        public void WhenItemAlreadyExists_ThrowExeption()
        {
            vault.AddItem("A2", item);
            Assert.Throws<InvalidOperationException>(() => vault.AddItem("B3", item));
        }

        [Test]
        public void WhenItemIsAdded_ShoudReturnCorrectMessage()
        {
            string result = vault.AddItem("A2", item);
            Assert.AreEqual(result, $"Item:{item.ItemId} saved successfully!");
        }

        [Test]
        public void WhenRemovedCellDoesNotExist_ShoudThrowExeption()
        {
            vault.AddItem("A2", item);
            Assert.Throws<ArgumentException>(() => vault.RemoveItem("B3", item));
        }

        [Test]
        public void WhenRemovedItemDoesNotExist_ShoudThrowExeption()
        {
            vault.AddItem("A2", item);            
            Assert.Throws<ArgumentException>(() => vault.RemoveItem("A2", item2));
        }

        [Test]
        public void WhenItemIsRemoved_ShoudReturnCorrectMessage()
        {
            vault.AddItem("A2", item);
            string removed = vault.RemoveItem("A2", item);
            Assert.AreEqual(removed, $"Remove item:{item.ItemId} successfully!");
        }
    }
}