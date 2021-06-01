using System;
using System.IO;

namespace Drive
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variables para puebas
            Google.Apis.Drive.v3.Data.File filedelete = null; 
            GoogleDrive.DownLoadFile oDownLoadFile = new GoogleDrive.DownLoadFile();



            // Sector de Credenciales - Estos parametros deben venir de la DB para instanciar el Objeto de GoogleDrive
            // CUIDADO EL TOKEN ESTA ASOCIADO A MI CUENTA PERSONAL DE GOOGLE DRIVE

            var sCredentianl = "{'installed':{'client_id':'64489317776-pcca2h0u8ntbrilhnvs7r6ve20gq5ooc.apps.googleusercontent.com','project_id':'driveproject-312919','auth_uri':'https://accounts.google.com/o/oauth2/auth','token_uri':'https://oauth2.googleapis.com/token','auth_provider_x509_cert_url':'https://www.googleapis.com/oauth2/v1/certs','client_secret':'jbXTCyLXyT_T1aTPxXkMJlNy','redirect_uris':['urn:ietf:wg:oauth:2.0:oob','http://localhost']}}";
            var sToken = "{'access_token':'ya29.a0AfH6SMAlFh0lxWrVlXEp-SuGR-0pjf_oUQvcR3s7JyctfBJg-XhRSb3U5-M46XT5atuOk7OPYKJRMpA0u4_rbMVTz5M94wOV68WAvZmKknX5kAlx7jkb4AEQrOzBq3gY0uzIlyx73Ju2kjssVPSAh-t16Clg','token_type':'Bearer','expires_in':3599,'refresh_token':'1//0hFFrCWroVchWCgYIARAAGBESNwF-L9IrzIO8lgO7KIGzkdCvTD2F7hKfDNV7J2XremtKX8dY_18cLsty6y6C5e8lZK27TcyK66s','scope':'https://www.googleapis.com/auth/drive https://www.googleapis.com/auth/drive.file','Issued':'2021-05-07T15:21:34.232-03:00','IssuedUtc':'2021-05-07T18:21:34.232Z'}";

            // Si sCredential es null o vacio se genera una exception
            //sCredentianl = "";
            
            // Si sToken es null o vacio se pide autorizacion para generar el token
            //sToken = "";


            // Creacion de la instancia de la api de Google Drive
           
            GoogleDrive.Drive oDrive = new GoogleDrive.Drive(sToken, sCredentianl);
            
            sToken = "";
            OneDrive.Drive oOne = new OneDrive.Drive(sToken);
            

            


            byte[] File = System.IO.File.ReadAllBytes("01_Test.txt");
            oDrive.SubirArchivo("01_Test.txt", File);

            // Consulta de Archivos del Drive

            System.Collections.Generic.IList<Google.Apis.Drive.v3.Data.File> files = oDrive.ListarArchivos();

            Console.WriteLine("Files:");
            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    Console.WriteLine("{0} ({1})", file.Name, file.Id);

                    if (file.Name == "01_Test.txt")
                        filedelete = file;
                }

                /*
                 // Este es el codigo de prueba para el borrado.


                if (filedelete != null)
                    oDrive.Delete(filedelete);
                */


                if (filedelete != null)
                    oDownLoadFile = oDrive.BajarArchivo(filedelete.Id);
            }
            else
            {
                Console.WriteLine("No files found.");
            }


            /* 
             // Prueba de la subida de archivos con un archivo plano en al solucion


            byte[] File = System.IO.File.ReadAllBytes("01_Test.txt");
            oDrive.SubirArchivo("01_Test.txt", File);
            */

        }
    }
}
