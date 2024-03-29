﻿using ErrorHandling.API.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ErrorHandling.API.Filters;

public static class FilterHelpers
{
    public static ContentResult BuildContentResult(Exception exception, string[] errors, bool addExceptionDetails = false)
    {
        ExceptionResultDto result = new ExceptionResultDto(exception.Message, exception.Data, errors);
        string s = "";
        foreach(System.Collections.DictionaryEntry d in exception.Data)
        {
           // ((System.Collections.DictionaryEntry)d).Key
            s +=d.Key+" : "+d.Value+"   -   " ;
        }
        if (addExceptionDetails)
        {
            result.Exception = exception.ToString();
        }

        return new ContentResult
        {
            Content = JsonSerializer.Serialize(result, new JsonSerializerOptions { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull })
        };
    }
}