using System;
using System.Collections.Generic;
using System.Text;

namespace Aapartment.Business.Dto
{
    public class PasswordChangeDto
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
