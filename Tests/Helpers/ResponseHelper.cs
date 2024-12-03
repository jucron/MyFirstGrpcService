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
        internal static async Task<string> getPropertyFromResponse(string property, HttpResponseMessage response)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();

            if (! string.IsNullOrEmpty(jsonResponse))
            {
                var jsonDoc = JsonDocument.Parse(jsonResponse);
                var propertyValue = jsonDoc.RootElement.GetProperty(property);

                if (propertyValue.ValueKind == JsonValueKind.String && propertyValue.GetString() != null)
                {
                    return propertyValue.GetString();
                }
            }
               
            
            return "";

        }
    }
}
