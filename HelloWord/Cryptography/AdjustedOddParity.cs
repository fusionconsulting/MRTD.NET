﻿using System;

namespace HelloWord.Cryptography
{
    public class AdjustedOddParity : IParity
    {
        private readonly byte _b;
        public AdjustedOddParity(byte b)
        {
            _b = b;
        }

        public IParity Adjusted()
        {
            return this;
        }

        public byte Result()
        {
            return (byte)(this._b | 1);
        }
    }
}