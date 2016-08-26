using System;
using HostApi;

namespace PrivatePlugin
{
    internal class SecretPlugin : Plugin
    {
        public override void Run() =>
            Console.WriteLine(@"This plugin's source code is very precious: 
It was only possible thanks to 10+ years of intensive R&D in the domain of text output. 
It should definitely never make it into the wild!");
    }
}
