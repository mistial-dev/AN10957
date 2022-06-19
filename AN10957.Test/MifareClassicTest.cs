// <copyright file="MifareClassicTest.cs" company="Mistial Developer">
// Copyright (c) Mistial Developer. Some rights reserved.
// </copyright>
namespace AN10957.Test
{
    using Card.Emulator.Mifare;
    using Card.Emulator.Mifare.Card;
    using static Card.Emulator.Mifare.Card.ClassicCard;

    /// <summary>
    /// Tests Mifare Classic Emulation.
    /// </summary>
    public class MifareClassicTest
    {
        /// <summary>
        /// Sets up for unit testing.
        /// </summary>
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Test that the Mifare 1k Emulation uses correct sizes.
        /// </summary>
        [Test]
        public void Test1KSizes()
        {
            var card = new ClassicCard(CardType.CLASSIC_1K);
            Assert.That(card.Sectors, Has.Exactly(Mifare.CLASSIC1KNUMSECTORS).Items);
            foreach (var t1 in card.Sectors)
            {
                Assert.That(t1.Blocks, Has.Exactly(Mifare.CLASSIC1KSECTORSIZE).Items);
                foreach (var t in t1.Blocks)
                {
                    Assert.That(t.Data, Has.Exactly(Mifare.BLOCKSIZE).Items);
                }
            }
        }
    }
}
