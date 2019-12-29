using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Models
{
    public class Result
    {
        private bool isSuccess = true;
        public bool IsSuccess
        {
            get
            {
                return isSuccess;
            }
            set
            {
                isSuccess = value;
            }
        }

        public string ResultDescription { get; set; }

        public void SetError(string errorMessage)
        {
            isSuccess = false;
            ResultDescription = errorMessage;
        }
    }
}
