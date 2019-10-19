using System;
using GraphQL;
using GraphQL.Types;


namespace GraphQLTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var schema = Schema.For(@"
                    type Query {
                        hello: String,
                        jedis: [Jedi]
                    }

                    type Jedi {
                        name: String,
                        side: String
                    }
            ");

            var root = new { Hello = "Hello World" };
            var json = schema.Execute(_ =>
            {
                _.Query = "{ hello}";
                _.Root = root;
            });

            Console.WriteLine(json);
        }
    }
}
