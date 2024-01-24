using System.Text;
using System.Xml.Serialization;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace ShippingCompany;

public class XmlNoNameSpaceInputFormatter : XmlSerializerInputFormatter
{
    private const string ContentType = "application/xml";
    public XmlNoNameSpaceInputFormatter(MvcOptions options) : base(options)
    {
        SupportedMediaTypes.Add(ContentType);
    }

    public override bool CanRead(InputFormatterContext context)
    {
        var contentType = context.HttpContext.Request.ContentType;
        return contentType.StartsWith(ContentType);
    }

    public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
    {
        var type = GetSerializableType(context.ModelType);
        var request = context.HttpContext.Request;

        using (var reader = new StreamReader(request.Body))
        {
            var content = await reader.ReadToEndAsync();

            // The namespace in Biztalk cause crashing the deserialization
            // this should not be done in production and only for demo purposes
            content = content.Replace("ns0:", "").Replace("xmlns:ns0=\"http://EAISchemas.Order\"", "");
            Stream s = new MemoryStream(Encoding.UTF8.GetBytes(content));

            XmlTextReader rdr = new XmlTextReader(s)
            {
                Namespaces = false
            };

            var serializer = new XmlSerializer(type);
            var result = serializer.Deserialize(rdr);
            return await InputFormatterResult.SuccessAsync(result);
        }
    }
}