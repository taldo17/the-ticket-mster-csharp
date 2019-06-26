using System;
using System.Text;
using Amazon.S3;
using Amazon.S3.Model;

namespace Ticket_Master
{
    public class S3TicketsDao
    {
        private static S3TicketsDao _instance;
        private S3TicketsDao()
        {
        }

        public static S3TicketsDao GetInstance()
        {
            if (_instance == null)
            {
                _instance = new S3TicketsDao();
            }
            return _instance;
        }


        public void UploadObject(string reportString)
        {
            Console.WriteLine("uploading report string to AWS s3 bucket");
            try
            {
                AmazonS3Client amazonS3Client = new AmazonS3Client();
                byte[] bytesToWrite = Encoding.UTF8.GetBytes(reportString);
                amazonS3Client.PutObject(new PutObjectRequest());
            }
            catch (Exception e)
            {
                //            System.out.println("We are not really connected to Amazon");
            }

        }

    }
}