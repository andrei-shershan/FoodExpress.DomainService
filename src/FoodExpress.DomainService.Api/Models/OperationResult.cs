﻿namespace FoodExpress.DomainService.Api.Models
{
    public class OperationResult<TResult, TErrorEnum> 
        where TResult : class
        where TErrorEnum : Enum
    {
        public TResult Result { get; set; }

        public bool IsSuccess { get; set; }

        public TErrorEnum ErrorCode { get; set; }

        public static OperationResult<TResult, TErrorEnum> Success(TResult result)
        {
            return new OperationResult<TResult, TErrorEnum>()
            {
                IsSuccess = true,
                Result = result,
            };
        }

        public static OperationResult<TResult, TErrorEnum> Failure(TErrorEnum errorCode)
        {
            return new OperationResult<TResult, TErrorEnum>()
            {
                IsSuccess = false,
                ErrorCode = errorCode,
            };
        }
    }
}
