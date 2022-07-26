using System;
using System.Collections.Generic;

namespace _32_Classes
{
	class House
	{
		
		private float floorSpace;
		private int numberOfStories;
		private string style;
		private string nameOfOwner;
		private Person owner;

		public House(float floorSpace, int numberIfStories, string style, Person owner)
        {
            this.style = style;
            this.floorSpace = floorSpace;
            this.numberOfStories = numberIfStories;
            this.owner = owner;
            this.owner = owner;
        }

        public void ChangeStories(int number)
        {
			numberOfStories += number;
        }

		public void ChangeFloorSpace(float number)
        {
			floorSpace += number;
        }

		public void ChangeOwner(Person newOwner)
        {
			owner = newOwner;
        }

		 

		public void PrintInformation()
        {
			Console.WriteLine("This house is owned by: " + owner.firstName + " " + owner.lastName);
			Console.WriteLine("Style: " + style);
			Console.WriteLine("Floor space: " + floorSpace);
			Console.WriteLine("Stories: " + numberOfStories);
        }
	}
}





