﻿using System;
namespace JustInfo.Domain.Communications
{
    public abstract class BaseResponse
    {
        public bool Success { get; protected set; }
        public string Message { get; protected set; }

        protected BaseResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
