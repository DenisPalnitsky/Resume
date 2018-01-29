using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleDocPublish.Models
{
    public class ResumeViewModel
    {
        enum Formats
        {
            pdf,
            doc
        }
        
        const string URL_PATTERN = "https://docs.google.com/document/export?format={0}&id={1}";

        string _docId;

        public string PdfDownloadLink => BuildUrl(Formats.pdf, _docId);

        public string WordDownloadLink => BuildUrl(Formats.doc, _docId);

        static string BuildUrl(Formats format, string docId)
        {
            return string.Format(URL_PATTERN, format, docId);
        }

        public string ResumeHtml { get; private set; }

        public ResumeViewModel (string docId, string html)
        {
            ResumeHtml = html;
            this._docId = docId;

        }

    }
}
