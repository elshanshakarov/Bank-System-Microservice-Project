using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanDocumentService.Domain.Entities
{
    public class LoanDocument
    {  
        public int DocumentId { get; set; }
        public int CustomerId { get; set; }
        public string DocumentType { get; set; }
        public string FileUrl { get; set; }
        public string FileFormat { get; set; }
        public long FileSizeKb { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}
