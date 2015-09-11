using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BROWSit.Models
{
    public class UploadModel
    {
        public bool fileCheck;
        public bool typeCheck;
        public string fileName;
        public string typeName;

        public UploadModel()
        {
            fileCheck = false;
            typeCheck = false;
            fileName = "";
            typeName = "";
        }
    }
}
