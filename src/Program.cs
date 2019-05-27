using System;
using System.Security.Cryptography.X509Certificates;
using System.IO.Packaging;
using iTextSharp.text.pdf;

namespace validador
{
    class Program
    {
        static void Main(string[] args)
        {
            PdfReader reader = new PdfReader("../sample-docs/my_signed_doc.pdf");
            foreach(string signatureName in reader.AcroFields.GetSignatureNames()){
                
                 var signatureDict = reader.AcroFields.GetSignatureDictionary(signatureName);
                 PdfPkcs7 pk  =  reader.AcroFields.VerifySignature(signatureName);
                 var certs = pk.Certificates;

                 Console.WriteLine("Firmado por: "+pk.SignName);
                 Console.WriteLine("Firma Verificada: "+pk.Verify());
                

                 
            }
            
           
        }



    }
}
