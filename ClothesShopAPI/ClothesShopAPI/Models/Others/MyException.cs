using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Models.Others
{
    [Serializable]
    public class MyException : Exception
    {
        public int StatusCode { get; set; }
        public int ErrorCode { get; set; }
        public string StatusMessage { get; set; }
        public MyException() 
        {
            this.StatusCode = 500;
        }
        public MyException(string message)
        : base(message)
        {
            this.StatusCode = 500;
        }

        public MyException(string message, Exception innerException)
            : base(message, innerException)
        {
            this.StatusCode = 500;
        }
        public MyException(int code)
        {
            this.StatusCode = code;
            this.StatusMessage = "";
        }
        public MyException(int code, int error)
        {
            this.StatusCode = code;
            this.ErrorCode = error;
            this.SetNewMessage();
        }
        public MyException(int code, string status)
        {
            this.StatusCode = code;
            this.StatusMessage = status;
        }
        public void SetNewMessage()
        {
            switch (this.ErrorCode)
            {
                case 1:
                    this.StatusMessage = "Użytkownik o podanym emailu już istnieje!";
                    break;
                case 2:
                    this.StatusMessage = "Użytkownik o podanej nazwie użytkownika już istnieje!";
                    break;
                default:
                    this.StatusMessage = "Error";
                    break;
            }
        }
    }
}
