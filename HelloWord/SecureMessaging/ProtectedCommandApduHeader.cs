﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.CommandAPDU;
using HelloWord.CommandAPDU.Header;
using HelloWord.Cryptography;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging
{
    public class ProtectedCommandApduHeader : IBinary
    {
        private readonly IBinary _commandApduHeader;
        public ProtectedCommandApduHeader(IBinary commandApduHeader)
        {
            _commandApduHeader = commandApduHeader;

        }
        public byte[] Bytes()
        {
            return
                new PadedCommandApduHeader(
                    new Binary(
                        new MaskedCLA(
                            new CLA(_commandApduHeader)
                        )
                        .Bytes()
                        .Concat(_commandApduHeader.Bytes().Skip(1))
                        .ToArray()
                    )
                 ).Bytes();
        }
    }
}