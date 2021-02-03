using Dashboard_MK4.Models.V3_DataManager;
using Dashboard_MK4.Models.V3_Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Dashboard_MK4.Services
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;

        public MailService(IOptions<MailSettings> mailSettings)
        {
            this._mailSettings = mailSettings.Value;
            if (this._mailSettings.Port == null)
            {
                //this._mailSettings = Configuration.GetSection("MailSettings")
                /*"Mail": "brentwatch@BIndustries.co.za",
     "DisplayName": "Brent Becker",
     "Password": "",
     "Host": "smtp.deepbluecw.co.za",
     "Port": 587*/
                this._mailSettings.Host = "smtp.deepbluecw.co.za";
                this._mailSettings.Port = 587;
                this._mailSettings.Mail = "info@deepblue.co.za";
                this._mailSettings.Password = "bjD9cuuv69Z";
                this._mailSettings.DisplayName = "info";
            }
        }
        public async Task SendEmailAsync(Mail_Request mail_Request,JobCardV3 jobCard)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress(_mailSettings.Mail, _mailSettings.DisplayName);
            /*"toEmail": "brentwatch2021@gmail.com",
            "subject": "astroids",
            "jobCardID": null,
            "body": "lekker astroids for light years!!!"
            */
            mail_Request.Body = "lekker astroids for light years!!!";
            mail_Request.Subject = "astroids";


            /// TO EMAIL
            mail_Request.ToEmail = "brentwatch2021@gmail.com";

            message.To.Add(new MailAddress(mail_Request.ToEmail));
            message.Subject = mail_Request.Subject;

            // Input data from jobcard into html template
            ProcessDataIntoHtml(jobCard);
            // Convert HTML template into PDF
            CreatePDFFromHTMLTemplate();
            // Unprocess the HTML for template ready phase
            UnprocessDataFromHtml(jobCard);

            // attach PDF
            Attachment att = new Attachment("SimpleConversionLocalHtml.pdf");
            message.Attachments.Add(att);

            message.IsBodyHtml = false;
            message.Body = mail_Request.Body;
            smtp.Port = _mailSettings.Port;
            smtp.Host = _mailSettings.Host;
            smtp.EnableSsl = false;
            smtp.UseDefaultCredentials = false;
            _mailSettings.Mail = "info@deepbluecw.co.za";
            _mailSettings.Password = "bjD9cuuv69Z";
            smtp.Credentials = new NetworkCredential(_mailSettings.Mail, _mailSettings.Password);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            //await smtp.SendMailAsync(message);



            // Build a PDF file and save it on disk from a job card
            //Converter.Convert(new Uri("https://www.google.com"), "SimpleConversion.pdf");
            //ceTe.DynamicPDF.HtmlConverter.Converter.Convert(new Uri("https://www.google.com"), "SimpleConversion.pdf");
            //ceTe.DynamicPDF.HtmlConverter.Converter.Convert(new Uri("HTML/index.html"), "SimpleConversionLocalHtml.pdf");
            /*
            if (mail_Request.Attachments != null)
            {
                foreach (var file in mail_Request.Attachments)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            var fileBytes = ms.ToArray();
                            Attachment att = new Attachment(new MemoryStream(fileBytes), file.FileName);
                            message.Attachments.Add(att);
                        }
                    }
                }
            }
            */


        }

        private void UnprocessDataFromHtml(JobCardV3 jobCard)
        {
            string text = File.ReadAllText("C:\\temp\\Index.html");
            
            // Business Name
            text = text.Replace(jobCard.JobCardName, "{Business Name}");
            // Invoice Number
            //text = text.Replace(jobCard., "{B Name}");
            // Date

            // Bill to
            string BillTo = string.Empty;
            if (jobCard.JTFA_Client != null && jobCard.JTFA_Client.Name != null)
            {
                BillTo = jobCard.JTFA_Client.Name;
                text = text.Replace(BillTo, "{Bill To}");
            }
            // Model
            // Make
            string vehicleMake = string.Empty;
            if (jobCard.Vehicle != null && jobCard.Vehicle.Make != null)
            {
                vehicleMake = jobCard.Vehicle.Make;
                text = text.Replace(vehicleMake, "{Vehicle Make}");
            }
            // VIN
            string VIN = string.Empty;
            if (jobCard.Vehicle != null && jobCard.Vehicle.VIN != null)
            {
                VIN = jobCard.Vehicle.VIN;
                text = text.Replace(VIN, "{VIN}");
            }
            File.WriteAllText("C:\\temp\\Index.html", text);
        }

        private void ProcessDataIntoHtml(JobCardV3 jobCard)
        {
            // Get File and find and replace in files text
            string text = File.ReadAllText("C:\\temp\\Index.html");

            // Business Name
            text = text.Replace("{Business Name}", jobCard.JobCardName);
            // Bill to
            string BillTo = string.Empty;
            if (jobCard.JTFA_Client != null && jobCard.JTFA_Client.Name != null)
            {
                BillTo = jobCard.JTFA_Client.Name;
                text = text.Replace("{Bill To}", BillTo);
            }
            
            // Make
            string vehicleMake = string.Empty;
            if (jobCard.Vehicle != null && jobCard.Vehicle.Make != null)
            {
                vehicleMake = jobCard.Vehicle.Make;
                text = text.Replace("{Vehicle Make}", vehicleMake);
            }
            

            // Make

            // VIN
            string VIN = string.Empty;
            if (jobCard.Vehicle != null && jobCard.Vehicle.VIN != null)
            {
                VIN = jobCard.Vehicle.VIN;
                text = text.Replace("{VIN}", VIN);
            }
            
            File.WriteAllText("C:\\temp\\Index.html", text);
        }

        private void CreatePDFFromHTMLTemplate()
        {
            Uri site = new Uri("file:///C:\\temp\\Index.html");
            ceTe.DynamicPDF.HtmlConverter.Converter.Convert(site, "SimpleConversionLocalHtml.pdf");
        }

        private JobCardV3 GetJobCard(string jobCardID)
        {
            JobCardV3 jobCard = null;
            jobCardID = "00000000-0000-0000-0000-000000000012";
            if (!string.IsNullOrEmpty(jobCardID))
            {
                Task jobCardTask = GetJobCardFromController(jobCardID);
                
            }
            return jobCard;
        }

        private async Task GetJobCardFromController(string ID)
        {
            //JobCard_TaskDescriptions_Context context = new JobCard_TaskDescriptions_Context();
            //Guid idGuid = new Guid("00000000-0000-0000-0000-000000000012");
            //List<JobCardV3> jobCard = context.JobCardsV3.Where(p => p.JobCardID == idGuid).ToList();


            HttpClient client = new HttpClient();
            string json = client.GetStringAsync(string.Format("http://localhost:5050/api/1/JobCardV3/{0}", ID)).ToString();
            JobCardV3 jobCardTask = await Task.Run(() => JsonConvert.DeserializeObject<JobCardV3>(json));
            
        }
    }
}
