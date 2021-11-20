using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hahn.Application.Services.Asset.Dto
{
	public class AssetDto: IEquatable<AssetDto>
	{
		public string Id { get; set; }
		public string Symbol { get; set; }
		public string Name { get; set; }

        public bool Tracked { get; set; }

        public bool Equals(AssetDto other)
        {
            return other != null 
                && other.Id.ToLower() == Id.ToLower() 
                && other.Name.ToLower() == Name.ToLower() 
                && other.Symbol.ToLower() == Symbol.ToLower();
        }
    }
}
