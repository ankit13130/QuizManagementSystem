using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace QuizManagement.Core.Domain.Helper;

public class EmailSender
{
    public string sendOtpMail(string to, string otp, string ownerEmail, string ownerPassword, string smtp, int port)
    {
        try
        {
            MailMessage message = new MailMessage(ownerEmail, to, "Verify Your Email", $"Your 6 Digit Code : {otp} \nUse This code to verify your account");

            //if (upload.HasFile)
            //{
            //    HttpFileCollection fc = Request.Files;

            //    for (int i = 0; i <= fc.Count - 1; i++)
            //    {
            //        HttpPostedFile pf = fc[i];
            //        Attachment attach = new Attachment(pf.InputStream, pf.FileName);
            //        message.Attachments.Add(attach);
            //    }
            //}

            SmtpClient client = new SmtpClient(smtp, port);
            client.EnableSsl = true;
            //client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(ownerEmail, ownerPassword);

            client.Send(message);
            return "OTP sent successfully";
        }
        catch (Exception ex)
        {
            return ex.StackTrace;
        }
    }
    
    public string sendCongratulationMail(string to, string ownerEmail, string ownerPassword, string smtp, int port)
    {
        try
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("ID,Email");
            stringBuilder.AppendLine($"1,{to}");
            SmtpClient client = new SmtpClient(smtp, port);
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(ownerEmail,ownerPassword);
            
            MailMessage message = new MailMessage(ownerEmail, to, "📢 Account Verified Successfully", "📢 Account Verified Successfully.\n You can use our Quiz services now.");

            using (MemoryStream stream = new MemoryStream(Encoding.ASCII.GetBytes(stringBuilder.ToString())))
            {
                //Add a new attachment to the E-mail message, using the correct MIME type
                Attachment attachment = new Attachment(stream, new ContentType("application/vnd.ms-excel"));
                attachment.Name = "details.xlsx";
                message.Attachments.Add(attachment);
                client.Send(message);
            }
            return "Congratulations Mail sent successfully";
        }
        catch (Exception ex)
        {
            return ex.StackTrace;
        }
    }
}
