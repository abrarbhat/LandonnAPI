using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandonnAPI.Infrastructure
{
    public class IosOutputFormatter: TextOutputFormatter
    {
        private readonly JsonOutputFormatter _jsonOutputFormatter;
        public IosOutputFormatter(JsonOutputFormatter jsonOutputFormatter)
        {
            _jsonOutputFormatter = jsonOutputFormatter;
            if (jsonOutputFormatter == null)
                throw new ArgumentNullException(nameof(jsonOutputFormatter));

            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/ios+json"));
            SupportedEncodings.Add(Encoding.UTF8);
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding) => _jsonOutputFormatter.WriteResponseBodyAsync(context, selectedEncoding);            
    }
}
