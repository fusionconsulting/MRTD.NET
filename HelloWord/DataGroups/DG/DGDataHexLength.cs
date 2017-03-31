using System.Linq;
using HelloWord.Infrastructure;
using HelloWord.SecureMessaging;
using HelloWord.SmartCard;

namespace HelloWord.DataGroups.DG
{
    public class DGDataHexLength : IBinary
    {
        private readonly IBinary _applicationIdentifier;
        private readonly IBinary _kSenc;
        private readonly IBinary _kSmac;
        private readonly IBinary _ssc;
        private readonly IReader _reader;

        private readonly int firstFourByteForDGStructureLength = 5;

        public DGDataHexLength(
                IBinary applicationIdentifier,
                IBinary kSenc,
                IBinary kSmac,
                IBinary ssc,
                IReader reader
            )
        {
            _applicationIdentifier = applicationIdentifier;
            _kSenc = kSenc;
            _kSmac = kSmac;
            _ssc = ssc;
            _reader = reader;
        }
        public byte[] Bytes()
        {
            var firstFourBytes = new SecureMessagingPipe(
                        _applicationIdentifier,
                        firstFourByteForDGStructureLength,
                        _kSenc,
                        _kSmac,
                        _ssc,
                        _reader
                   ).Bytes();

            var parsedBerTLV = new BerTLV(
                                    firstFourBytes
                                       
                                        .Take(firstFourByteForDGStructureLength)
                                );
            var tagBytesCount = parsedBerTLV.Tag.Length / 2;
            var lenBytesCount = parsedBerTLV.Len.Length / 2;

            var berTlvValueLength = new Hex(
                                        new BinaryHex(
                                            parsedBerTLV.Len
                                        )
                                    ).ToInt();

            return new HexInt(
                       tagBytesCount + lenBytesCount + berTlvValueLength
                   ).Bytes();
        }
    }
}
