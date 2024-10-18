using System;

namespace KinderGartenApp.Core.Entities
{
	public class Son
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public Date BirthDate { get; set; }
        public int FatherId { get; set; }
    }
}