﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging
{
    public class K : IBinary
    {
        private readonly IBinary _incrementedSsc;
        private readonly IBinary _do99_do87do99;

        public K(
                IBinary incrementedSsc,
                IBinary do99_do87do99
            )
        {
            _incrementedSsc = incrementedSsc;
            _do99_do87do99 = do99_do87do99;
        }
        public byte[] Bytes()
        {
            return new ConcatenatedBinaries(
                    _incrementedSsc,
                    _do99_do87do99
                ).Bytes();
        }
    }
}