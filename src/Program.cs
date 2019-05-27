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
            foreach (string signatureName in reader.AcroFields.GetSignatureNames())
            {

                var signatureDict = reader.AcroFields.GetSignatureDictionary(signatureName);
                PdfPkcs7 pk = reader.AcroFields.VerifySignature(signatureName);
                var certs = pk.Certificates;

                string nombreCertificado = pk.Certificates[0].SubjectDN.GetValueList(new Org.BouncyCastle.Asn1.DerObjectIdentifier(Constantes.OID_COMMON_NAME))[0].ToString();
                string cedula = pk.Certificates[0].SubjectDN.GetValueList(new Org.BouncyCastle.Asn1.DerObjectIdentifier(Constantes.OID_SERIAL_NUMBER))[0].ToString();
                string nombre = pk.Certificates[0].SubjectDN.GetValueList(new Org.BouncyCastle.Asn1.DerObjectIdentifier(Constantes.OID_GIVEN_NAME))[0].ToString();
                string apellidos = pk.Certificates[0].SubjectDN.GetValueList(new Org.BouncyCastle.Asn1.DerObjectIdentifier(Constantes.OID_SURNAME))[0].ToString();

                Console.WriteLine("Firma Verificada: " + pk.Verify());
                Console.WriteLine($"Nombre del certificado: {nombreCertificado}");
                Console.WriteLine($"Cedula: {cedula}");
                Console.WriteLine($"Nombre: {nombre}");
                Console.WriteLine($"Apellidos: {apellidos}");
            }


        }



    }
}
