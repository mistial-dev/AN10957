// <copyright file="Sector.cs" company="Mistial Developer">
// Copyright (c) Mistial Developer. Some rights reserved.
// </copyright>

namespace Card.Emulator.Mifare;

/// <summary>
/// Represents a sector of data on a MIFARE card.
/// </summary>
public class Sector
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Sector"/> class.
    /// </summary>
    /// <param name="blocks">An array containing block data.</param>
    /// <param name="sectorNumber">The number of the sector, used to verify the correct number of blocks.</param>
    /// <exception cref="ArgumentException">Thrown when an invalid number of block is specified.</exception>
    public Sector(Block[] blocks, int sectorNumber)
    {
        var requiredSize = Mifare.SectorSize(sectorNumber);
        if (blocks.Length != requiredSize)
        {
            throw new ArgumentException($"MIFARE Sector {sectorNumber} must have a size of {requiredSize}.");
        }

        this.Blocks = blocks;
    }

    /// <summary>
    /// Gets the blocks of data in this Sector.
    /// </summary>
    public Block[] Blocks
    {
        get;
    }
}