﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BerTlv;
using HelloWord.Infrastructure;

namespace HelloWord.DataGroups
{
    public class DG1Data 
    {
        private readonly IBinary _dg1Data;

        public DG1Data(IBinary dg1Data)
        {
            _dg1Data = dg1Data;
        }

        public override string ToString()
        {

            ICollection<Tlv> tlvs = Tlv.ParseTlv(new Hex(_dg1Data).ToString());
            return Encoding.ASCII
                .GetString(
                    _dg1Data
                    .Bytes()
                    .Skip(5)
                    .ToArray()
                );
        }
    }
}