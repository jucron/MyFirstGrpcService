using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Google.Rpc.Context.AttributeContext.Types;

namespace Tests.Helpers
{
    public class ResponseHelper
    {
        internal static async Task<string> getAsyncPropertyFromResponse(string property, HttpResponseMessage response)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();

            if (!string.IsNullOrEmpty(jsonResponse))
            {
                var jsonDoc = JsonDocument.Parse(jsonResponse);
                var propertyValue = jsonDoc.RootElement.GetProperty(property);

                if (IsJsonElementValid(propertyValue))
                {
                    return propertyValue.GetString();
                }
            }
               
            
            return "";

        }

        private static bool IsJsonElementValid(JsonElement propertyValue)
        {
            return (propertyValue.ValueKind == JsonValueKind.Null ||
                    propertyValue.ValueKind == JsonValueKind.Undefined ||
                    propertyValue.GetString() != null);
        }
    }
}
