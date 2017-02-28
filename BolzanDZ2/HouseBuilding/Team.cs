using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBuilding
{
    class Team
    {
        public TeamLeader teamLeader;
        public Worker[] workers;
        public Team(int numberOfWorker)
        {
            teamLeader = new TeamLeader("Leader");
            workers = new Worker[numberOfWorker];
            for (int i = 0; i < numberOfWorker; i++)
            {
                workers[i] = new Worker(String.Format("Worker {0}", i + 1));
            }
        }
    }
}
