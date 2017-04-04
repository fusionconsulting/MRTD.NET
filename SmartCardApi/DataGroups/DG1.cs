﻿using SmartCardApi.DataGroups.Content;
using SmartCardApi.Infrastructure;
using SmartCardApi.SmartCard.Reader;

namespace SmartCardApi.DataGroups
{
    public class DG1 : IDataGroup<DG1Content>
    {
        private readonly IBinary _fid = new BinaryHex("0101");
        private readonly IBinary _dgData;
        public DG1(IBacReader bacReader)
        {
            _dgData = bacReader.DGData(_fid);
        }
        public byte[] Bytes()
        {
            return _dgData.Bytes();
        }

        public DG1Content Content()
        {
            return new DG1Content(_dgData);
        }
    }
}
