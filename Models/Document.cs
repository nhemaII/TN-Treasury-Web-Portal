﻿using System.ComponentModel.DataAnnotations.Schema;

namespace TN_Treasury_Web_Portal.Models
{
    public class Document
    {
        
     
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string Description { get; set; }


    }
}
