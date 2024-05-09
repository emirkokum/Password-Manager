using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RecordDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Title { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Url { get; set; }
        public string Notes { get; set; }
    }
}
