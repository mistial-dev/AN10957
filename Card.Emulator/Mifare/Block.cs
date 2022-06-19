// <copyright file="Block.cs" company="Mistial Developer">
// Copyright (c) Mistial Developer. Some rights reserved.
// </copyright>

namespace Card.Emulator.Mifare;

/// <summary>
/// Represents a block of data (16 bytes).
/// </summary>
public class Block
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Block"/> class.
    /// </summary>
    /// <param name="data">Data present in this block.</param>
    public Block(byte[] data)
    {
        if (data.Length != Mifare.BLOCKSIZE)
        {
            throw new ArgumentException("MIFARE blocks must have a length of 16 bytes.");
        }

        this.Data = data;
    }

    /// <summary>
    /// Gets the data in this block.
    /// </summary>
    public byte[] Data
    {
        get;
    }
}