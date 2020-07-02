using System.Collections.Generic;
using VirtualPharmaRep.Data.Dtos.Interfaces;

namespace VirtualPharmaRep.Data.Dtos
{
	public class DrugCategoryDto : IDto
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<DrugDto> Drugs { get; set; }
    }
}