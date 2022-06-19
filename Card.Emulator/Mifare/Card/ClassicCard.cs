// <copyright file="ClassicCard.cs" company="Mistial Developer">
// Copyright (c) Mistial Developer. Some rights reserved.
// </copyright>
namespace Card.Emulator.Mifare.Card;

// ReSharper disable file InconsistentNaming

/// <summary>
/// Represents an emulated MIFARE Classic card.
/// </summary>
public class ClassicCard
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ClassicCard"/> class.
    /// </summary>
    /// <param name="type">Indicates the type of classic card (1k, 2k, or 4k).</param>
    public ClassicCard(CardType type)
    {
        Sector[] newSectors;

        switch (type)
        {
            case CardType.CLASSIC_1K:
                newSectors = new Sector[Mifare.CLASSIC1KNUMSECTORS];
                break;
            case CardType.CLASSIC_2K:
                newSectors = new Sector[Mifare.CLASSIC2KNUMSECTORS];
                break;
            case CardType.CLASSIC_4K:
                newSectors = new Sector[Mifare.CLASSIC4KNUMSECTORS];
                break;
            default:
                throw new ArgumentException("Invalid card type specified.");
        }

        // Fill the sectors
        for (var i = 0; i < newSectors.Length; i++)
        {
            // Create an empty set of blocks
            var blocks = new Block[Mifare.SectorSize(i)];

            // Fill the blocks
            for (var j = 0; j < blocks.Length; j++)
            {
                var data = new byte[Mifare.BLOCKSIZE];
                Array.Fill(data, (byte)0x00);
                blocks[j] = new Block(data);
            }

            newSectors[i] = new Sector(blocks, i);
        }

        this.Sectors = newSectors;
    }

    /// <summary>
    /// Specifies the type of MIFARE classic card.
    /// </summary>
    public enum CardType
    {
        /// <summary>
        /// Mifare Classic 1K
        /// </summary>
        CLASSIC_1K = 1,

        /// <summary>
        /// Mifare Classic 2K
        /// </summary>
        CLASSIC_2K = 2,

        /// <summary>
        /// Mifare Classic 4K
        /// </summary>
        CLASSIC_4K = 4,
    }

    /// <summary>
    /// Gets the cards data sectors.
    /// </summary>
    public Sector[] Sectors
    {
        get;
    }
}