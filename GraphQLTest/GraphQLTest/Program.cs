﻿using System;
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
                type Jedi {
                    name: String,
                    side: String,
                    id: ID
                }                    
                type Query {
                    hello: String,
                    jedis: [Jedi],
                    jedi(id: ID): Jedi
                }                    
            ", _ =>
            {
                _.Types.Include<Query>();
            });

            var root = new { Hello = "Hello World" };
            var json = schema.Execute(_ =>
            {
                //_.Query = "{ jedis { name, side}}";
                _.Query = "{ jedi(id: 1) { name}}";
                //_.Query = "{ hello}";

                //_.Root = root;
            });

            Console.WriteLine(json);
        }
    }
}
