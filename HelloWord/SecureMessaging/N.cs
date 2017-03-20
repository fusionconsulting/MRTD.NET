﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;
using Org.BouncyCastle.Ocsp;

namespace HelloWord.SecureMessaging
{
    public class N : IBinary
    {
        private readonly IBinary _incrementedSsc;
        private readonly IBinary _m;
        private readonly byte[] _pad = new byte[] { 0x80, 0x00, 0x00, 0x00, 0x00 };

        public N(
                IBinary incrementedSSC,
                IBinary m
            )
        {
            _incrementedSsc = incrementedSSC;
            _m = m;
        }
        public byte[] Bytes()
        {
            return _incrementedSsc
                .Bytes()
                .Concat(
                    _m.Bytes()
                )
                .Concat(_pad)
                .ToArray();
        }
    }
}

