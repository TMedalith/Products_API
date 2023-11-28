﻿using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace si730ebu20211F955.API.Shared.Extensions;

public static class ModelStateExtensions
{
    public static List<string> GetErrorMessages(this ModelStateDictionary dictionary)
    {
        return dictionary.SelectMany(m => m.Value.Errors).Select(m => m.ErrorMessage).ToList();
    }
}