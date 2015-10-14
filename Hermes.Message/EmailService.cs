/*********************************************************************************
 * CLASS NAME:      EmailService.cs
 * PROGRAMMER:      Michael Hughes
 * PURPOSE:         Create an Email Message and send the email
 * VERSION:         1.0.0.0
 * CREATED DATE:    2/15/2014
*********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Hermes.Message.Image_Methods;
using System.IO;
using System.Diagnostics;
using Hughes.Common.Logging;

namespace Hermes.Message
{
    /// <summary>
    /// Creates an Email Message and send the email
    /// <remarks>
    /// It inherits the IMessage Interface
    /// </remarks>
    /// </summary>
    public class EmailService : IMessage
    {
        #region Members and Properties
        /// <summary>
        /// Create a new Mail message
        /// </summary>
        private MailMessage message;

       // private LogEventLog log = new LogEventLog();
        
        

        #endregion

        #region Public Methods
        /// <summary>
        /// Creates the Email Message
        /// </summary>
        /// <param name="body">string result from RenderViewToString</param>
        /// <param name="recipients">Email address from shuttle</param>
        public void CreateMessage(string body, string recipients)
        {
           
            string[] bcc = new string[] { "accounting@kica.us", "shuttle@kica.us" };
            message = new MailMessage();

            
            message.From = new MailAddress("shuttle@kica.us");



            //message.To.Add("michael.hughes@kica.us"); 


            //Uncomment when we go live
            message.To.Add(recipients);
            foreach (string address in bcc) {
                message.Bcc.Add(address);
            }

            message.Subject = "Kiawah Shuttle";
            message.Body = "<p> <img src=cid:companyLogo /> </p><br />" + body;
            message.IsBodyHtml = true;
            Send();
        } 
        #endregion

        #region Private Methods
        /// <summary>
        /// Create a new Stmp Client and Send the message
        /// </summary>
        public void Send()
        {

            SmtpClient server = new SmtpClient("outbound.att.net");

            try {
                server.Send(message);
                //log.Information("Email Sent");
            }
            catch (SmtpException e) {
                throw e.InnerException;
                //log.FatalError(e.Message);

                
            }
        } 
        #endregion
    }
}
