using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repository.Concrete;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.DTOs.NewsLetters;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfNewsLetterRepository : Repository<NewsLetter>, INewsLetterDal
    {
        private readonly IUnitOfWork _unitOfWork;
        public EfNewsLetterRepository(AppDbContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<NewsLetter> GetByIdAsync(int id)
        {
            return await _unitOfWork.GetRepository<NewsLetter>().GetAsync(x => x.Id == id);

        }

        public async Task<string> SafeDeleteNewsLetterAsync(int newsLetterId)
        {
            var newsLetter = await _unitOfWork.GetRepository<NewsLetter>().GetAsync(x => x.Id == newsLetterId);

            newsLetter.IsDeleted = true;
            newsLetter.DeletedDate = DateTime.Now;

            await _unitOfWork.GetRepository<NewsLetter>().UpdateAsync(newsLetter);
            await _unitOfWork.SaveAsync();

            return newsLetter.EMail;
        }

        public async Task<string> UndoDeleteNewsLetterAsync(int newsLetterId)
        {
            var newsLetter = await _unitOfWork.GetRepository<NewsLetter>().GetAsync(x => x.Id == newsLetterId);

            newsLetter.IsDeleted = false;
            newsLetter.DeletedDate = null;

            await _unitOfWork.GetRepository<NewsLetter>().UpdateAsync(newsLetter);
            await _unitOfWork.SaveAsync();

            return newsLetter.EMail;
        }

        public void SendingBulkEmails(NewsLetterSendEmailDto newsLetterSendEmailDto, List<NewsLetterDto> Emails)
        {
            // E-posta gonderen hesap bilgileri
            string senderEmail = "atlaskolej@gmail.com";
            string senderPassword = "kojl dxtu qrwf uxme";

            // E-posta basligi ve icerigi
            string subject = newsLetterSendEmailDto.Subject;
            string body = newsLetterSendEmailDto.Message;

            // SMTP sunucu ve port bilgileri
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;

            // E-posta gonderme islemi
            using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
            {
                smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
                smtpClient.EnableSsl = true;

                foreach (var recipientEmail in Emails) // Gelen Emails listesinin icinde dolas
                {
                    using (MailMessage mailMessage = new MailMessage(senderEmail, recipientEmail.EMail, subject, body))
                    {
                        smtpClient.Send(mailMessage);
                    }
                }

            }
        }
    }
}
