using ObjectClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_UI
{
    public class BadgeDoorDatabase
    {
        private Dictionary<int, List<string>> _badgeDoorDatabase = new Dictionary<int, List<string>>();
        
        //create a dictionary of badges
        //The key for the dictionary will be the badgeID
        //The Value for the dictionary will be the List of Door Names
        //Create
        public void AddBadge(Badge badge)
        {
            _badgeDoorDatabase.Add(badge.BadgeID,badge.DoorList);
        }
        
        //Read
        public Dictionary<int,List<string>> GetBadges()
        {
            return _badgeDoorDatabase;
        }


        public Badge GetBadge(int badgeid)
        {
            if (_badgeDoorDatabase.ContainsKey(badgeid))
            {
                Badge badge = new Badge();
                badge.BadgeID = badgeid;
                badge.DoorList = _badgeDoorDatabase[badgeid];

                return badge;
            }
            return null;
        }
        //Update
        public bool UpdateBadge(int currentBadgeID, Badge newbadge)
        {
            Badge currentBadge = GetBadge(currentBadgeID);

            if(currentBadge != null)
            {
                DeleteBadge(currentBadgeID);
                AddBadge(newbadge);
                
                return true;
            }
            
            return false;
        }

        //Delete

        public bool DeleteBadge(int badgeID)
        {
            bool deleteBadge = _badgeDoorDatabase.Remove(badgeID);   
            return deleteBadge;
        }
    }
}
