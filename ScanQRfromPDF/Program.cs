using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RasterEdge.XDoc.PDF;
using RasterEdge.Imaging.Basic;
using RasterEdge.XImage.BarcodeScanner;

namespace ScanQRfromPDF
{
    class Program
    {
        static void Main(string[] args)
        {
            // load PDF document
            PDFDocument doc = new PDFDocument(@"C:\Users\Edward\Documents\GitHub\scan-qr-pdf\ScanQRfromPDF\Documents\CódigoQR.pdf");

            // get the page you want to scan
            BasePage page = doc.GetPage(0);

            // set reader setting
            ReaderSettings setting = new ReaderSettings();

            // set type to read
            setting.AddTypesToRead(BarcodeType.QRCode);

            // read barcode from PDF page
            Barcode[] barcodes = BarcodeReader.ReadBarcodes(setting, page);

            // get each data
            foreach (Barcode barcode in barcodes)
            {
                // print the loaction of barcode on image
                //Console.WriteLine(barcode.BoundingRectangle.X + "  " + barcode.BoundingRectangle.Y);

                // output barcode data onto screen 
                Console.WriteLine(barcode.DataString);
            }

            // input data
            Console.Read();
        }
    }
}