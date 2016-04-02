using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace versionado_caeti_entity.entity
{
   public class Mail
    {
        private MailAddress _source;
        private MailAddress _destination;
        private String _subject;
        private String _body;

        public MailAddress source
        {
            get { return _source; }
            set { _source = value; }
        }

        public MailAddress destination
        {
            get { return _destination; }
            set { _destination = value; }
        }

        public String subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        public String body
        {
            get { return _body; }
            set { _body = value; }
        }

        /*
         * ----------------
            mail user
         * --------------
         * user : bando.user.client.lppa.2013@gmail.com
         * password : userclient123 
         */
    }
    
}
