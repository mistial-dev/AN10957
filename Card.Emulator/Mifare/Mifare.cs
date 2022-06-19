// <copyright file="Mifare.cs" company="Mistial Developer">
// Copyright (c) Mistial Developer. Some rights reserved.
// </copyright>

// ReSharper disable MemberCanBePrivate.Global
namespace Card.Emulator.Mifare;

// ReSharper disable file InconsistentNaming

/// <summary>
/// Mifare Constants.
/// </summary>
public static class Mifare
{
    /// <summary>
    /// Size of MIFARE blocks.
    /// </summary>
    public const int BLOCKSIZE = 16;

    /// <summary>
    /// Size of MIFARE keys.
    /// </summary>
    public const int KEYSIZE = 6;

    /// <summary>
    /// Number of sectors on a Classic 1K card.
    /// </summary>
    public const int CLASSIC1KNUMSECTORS = 16;

    /// <summary>
    /// Number of sectors on a Classic 2K card.
    /// </summary>
    public const int CLASSIC2KNUMSECTORS = 32;

    /// <summary>
    /// Number of sectors on a Classic 4K card.
    /// </summary>
    public const int CLASSIC4KNUMSECTORS = 40;

    /// <summary>
    /// Sector Size for the sectors present in a 1K card.
    /// </summary>
    public const int CLASSIC1KSECTORSIZE = 4;

    /// <summary>
    /// Sector Size for the sectors present in a 2K card, excluding sectors present on a 1K card.
    /// </summary>
    public const int CLASSIC2KSECTORSIZE = 4;

    /// <summary>
    /// Sector Size for the sectors present in a 4K card, excluding sectors present on a 1K or 2K card.
    /// </summary>
    public const int CLASSIC4KSECTORSIZE = 16;

    /// <summary>
    /// Default Public Read Key used for Mifare Application Directory (MAD).
    /// </summary>
    public static readonly AccessKey PUBLICREADKEY = new AccessKey(new byte[] { 0xA5, 0xA4, 0xA3, 0xA2, 0xA1, 0xA0 });

    /// <summary>
    /// Returns the size of the sector with a given number.
    /// </summary>
    /// <param name="sectorNumber">The number of the sector.</param>
    /// <returns>The size of the sector.</returns>
    /// <exception cref="ArgumentException">Thrown when an invalid sector number is provided.</exception>
    public static int SectorSize(int sectorNumber)
    {
        return sectorNumber switch
        {
            < Mifare.CLASSIC1KNUMSECTORS => Mifare.CLASSIC1KSECTORSIZE,
            < Mifare.CLASSIC2KNUMSECTORS => Mifare.CLASSIC2KSECTORSIZE,
            < Mifare.CLASSIC4KNUMSECTORS => Mifare.CLASSIC4KSECTORSIZE,
            _ => throw new ArgumentException("Invalid sector number.")
        };
    }
}