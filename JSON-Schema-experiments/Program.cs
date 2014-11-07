using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void RunTest()
        {
            //draft 3 json-schema is used.
            //to generate it from jsom use http://www.jsonschema.net/ or any site you like.
            var schema = JsonSchema.Parse(@"{    
            'type': 'object',
            'properties':
            {
                'names': {
                    'type':'array',
                    'items': { 'type': 'string' },
                    'minItems': 1
                },
                'ages': {'type': 'array'},
                'isGroup': {'type': 'boolean', 'required' : true},
                'inside': { 'type': 'object', 'properties': {'id': {'type':'integer'}}}}, 'additionalProperties': false
            }");

            var json = "{\"names\" : [\"Anton\",\"Andrey\",\"Maxim\"],\"ages\" : [23,24,25],\"isGroup\" : false,\"inside\" : {\"id\":1}}";//valid one.
            Console.WriteLine("IS VALID: {0}, JSON: {1} ", JObject.Parse(json).IsValid(schema), json);
            json = "{\"names\" : [\"Anton\",\"Andrey\",\"Maxim\"],\"ages\" : [23,24,25],\"isGroup\" : false, \"extraProperty\" : 1,\"inside\" : {\"id\":1}}";
            Console.WriteLine("IS VALID: {0}, JSON: {1} ", JObject.Parse(json).IsValid(schema), json);
            json = "{\"names\" : [\"Anton\",\"Andrey\",\"Maxim\"],\"ages\" : [23,24,25],\"inside\" : {\"id\":1}}";
            Console.WriteLine("IS VALID: {0}, JSON: {1} ", JObject.Parse(json).IsValid(schema), json);
            json = "{\"names\" : [\"Anton\",\"Andrey\",\"Maxim\"],\"ages\" : [23,24,25],\"isGroup\" : null,\"inside\" : {\"id\":1}}";
            Console.WriteLine("IS VALID: {0}, JSON: {1} ", JObject.Parse(json).IsValid(schema), json);
            json = "{\"names\" : [\"Anton\",\"Andrey\",null],\"ages\" : [23,24,25],\"isGroup\" : false,\"inside\" : {\"id\":1}}";
            Console.WriteLine("IS VALID: {0}, JSON: {1} ", JObject.Parse(json).IsValid(schema), json);
            json = "{\"names\" : null,\"ages\" : [23,24,25],\"isGroup\" : false,\"inside\" : {\"id\":1}}";
            Console.WriteLine("IS VALID: {0}, JSON: {1} ", JObject.Parse(json).IsValid(schema), json);
            json = "{\"names\" : [\"Anton\",\"Andrey\",\"Maxim\"],\"ages\" : [23,24,25],\"isGroup\" : false,\"inside\" : {\"id\":null}}";
            Console.WriteLine("IS VALID: {0}, JSON: {1} ", JObject.Parse(json).IsValid(schema), json);
            json = "{\"names\" : [\"Anton\",\"Andrey\",\"Maxim\"],\"ages\" : [23,24,25],\"isGroup\" : false,\"inside\" : null}";
            Console.WriteLine("IS VALID: {0}, JSON: {1} ", JObject.Parse(json).IsValid(schema), json);
        }

        private static void Main(string[] args)
        {
            RunTest();
            Console.ReadLine();
        }
    }
}