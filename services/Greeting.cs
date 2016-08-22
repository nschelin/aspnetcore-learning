using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace AspNetCore.services
{
	public interface IGreeter {
		string GetGreeting();
	}
    public class Greeting : IGreeter
    {
    	private string _greeting;
        public Greeting(IConfiguration configuration)
        {
        	_greeting = configuration["greeting"];
        }

        public string GetGreeting() {
    		return _greeting;
        }
    }
}
