using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsgFiskDll
{
    public class EsgTools
    {

        public byte[] GenerateQrCode(string QrContent)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(QrContent, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(qrCodeImage, typeof(byte[]));

        }
    }
}
