using System;
using System.Collections.Generic;
using System.Text;

namespace TranslateApplication.Models
{
    public class YandexApiModel
    {
        public int code { get; set; }
        public string lang { get; set; }
        public string[] text { get; set; }
    }
}
