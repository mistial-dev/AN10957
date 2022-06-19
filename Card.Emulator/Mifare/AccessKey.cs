// <copyright file="AccessKey.cs" company="Mistial Developer">
// Copyright (c) Mistial Developer. Some rights reserved.
// </copyright>

// ReSharper disable UnusedAutoPropertyAccessor.Local
namespace Card.Emulator.Mifare;

/// <summary>
/// Represents an access key used to access a block.
/// </summary>
public class AccessKey
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AccessKey"/> class.
    /// </summary>
    /// <param name="key">Key used to access a block.</param>
    public AccessKey(byte[] key)
    {
        if (key.Length != Mifare.KEYSIZE)
        {
            throw new ArgumentException("MIFARE keys must have a length of 6 bytes.");
        }

        this.Key = key;
    }

    /// <summary>
    /// Gets the key used to access the block.
    /// </summary>
    private byte[] Key
    {
        get;
    }
}